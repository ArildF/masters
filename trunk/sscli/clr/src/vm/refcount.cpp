
#include "common.h"
#include "refcount.h"

#define HEAP_SIZE 0x1000000
#define SEGMENT_SIZE 0x1000

// TODO: gcscan uses the _LOGALLOC define here
#ifdef  _DEBUG
// 
// Logging for reference counted heap allocations.
// (Taken from gcscan.cpp)
//
inline void RCLogAlloc(MethodTable *pMT, Object* object)
{
#ifdef LOGGING
    if (LoggingOn(LF_REFCOUNT, LL_INFO10))
    {
        DWORD size = pMT->GetBaseSize();
        LogSpewAlways("Allocated %5d bytes on reference counted heap for %s_TYPE" FMT_ADDR FMT_CLASS "\n",
                      size,
                      pMT->GetClass()->IsValueClass() ? "VAL" : "REF", 
                      DBG_ADDR(object),
                      DBG_CLASS_NAME_MT(pMT));

        if (LoggingOn(LF_REFCOUNT, LL_INFO100000))
            {
                void LogStackTrace();
                LogStackTrace();
            }
        }
#endif
}
#else
#define RCLogAlloc(size, pMT, object)
#endif

//This function clears a piece of memory
// size has to be Dword aligned
// (Taken from gcsmp.cpp)
inline
void memclr ( BYTE* mem, size_t size)
{
   assert ((size & (sizeof (DWORD)-1)) == 0);
   DWORD* m= (DWORD*)mem;
   for (size_t i = 0; i < size / sizeof(DWORD); i++)
       *(m++) = 0;
}  

HRESULT ReferenceCountedHeap::Initialize()
{
    m_Heap = new gmallocHeap;
    m_Heap->Init("Reference counted heap");

#ifdef LOGGING
    if (LoggingOn(LF_REFCOUNT, LL_INFO10))
    {
        LogSpewAlways("\nInitialized reference counted heap. ");
    }
#endif
    return S_OK;
}

Object* ReferenceCountedHeap::Alloc(DWORD size)
{
    // we need some space for our accounting needs too
    DWORD realSize = size + sizeof(ReferenceCountHeader);

    // get the space for it on the heap
    BYTE* newAlloc = (BYTE*)m_Heap->Alloc(realSize);
    memclr((BYTE*)newAlloc, realSize);

    // initial refcount is 1
    ((ReferenceCountHeader*)newAlloc)->AddRef();

    // account for the space allocated for the ObjHeader and the 
    // ReferenceCountHeader
    return (Object*) (newAlloc + sizeof(ReferenceCountHeader) + sizeof(ObjHeader));
}

ULONG ReferenceCountHeader::AddRef()
{
    m_RefCount++;
    return m_RefCount;
}

ULONG ReferenceCountHeader::Release()
{
    m_RefCount--;
    return m_RefCount;
}

// 
// Allocate an object from the reference counted heap.
//
OBJECTREF RCAllocateObject( MethodTable* pMT )
{
    // TODO: locking
    THROWSCOMPLUSEXCEPTION();

    // allocate memory for it
    Object* orObject = (Object*)g_pRCHeap->Alloc(pMT->GetBaseSize());

    // verify that the memory is zeroed out.
    _ASSERTE( ! orObject->HasSyncBlockIndex() );
    
    // make sure it has a method table
    orObject->SetMethodTable(pMT);

    RCLogAlloc(pMT, orObject);

    return( ObjectToOBJECTREF(orObject) );    
}

