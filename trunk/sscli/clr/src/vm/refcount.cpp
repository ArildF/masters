
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
#define RCLogAlloc(pMT, object)
#endif

#ifdef  _DEBUG
inline void RCLogFree(MethodTable *pMT, Object* object)
{
#ifdef LOGGING
    if (LoggingOn(LF_REFCOUNT, LL_INFO10))
    {
        DWORD size = pMT->GetBaseSize();
        LogSpewAlways("Object at" FMT_ADDR" has 0 references. Freeing %5d bytes on reference counted heap for %s_TYPE " FMT_CLASS "\n",
                      DBG_ADDR(object),
                      size,
                      pMT->GetClass()->IsValueClass() ? "VAL" : "REF",                       
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
#define RCLogFree(pMT, object)
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
        LogSpewAlways("\nInitialized reference counted heap.\n");
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

    // account for the space allocated for the ObjHeader and the 
    // ReferenceCountHeader
    return (Object*) (newAlloc + sizeof(ReferenceCountHeader) + sizeof(ObjHeader));
}

void ReferenceCountedHeap::Free(void* ptr)
{
    m_Heap->Free(ptr);
}

LONG ReferenceCountHeader::AddRef()
{    
    return InterlockedIncrement(&m_RefCount);;
}

LONG ReferenceCountHeader::Release()
{
    LONG refcount;

    if ((refcount = InterlockedDecrement(&m_RefCount)) == 0)
    {
        RCLogFree(GetObject()->GetMethodTable(), GetObject());

        // finalize if we have a finalizer
        Finalize();
 
        // free memory associated with the object
        g_pRCHeap->Free(this);
    }
    return refcount;
}

void ReferenceCountHeader::Finalize()
{
    Object* obj = GetObject();
    if (obj->GetMethodTable()->HasFinalizer())
        MethodTable::CallFinalizer(obj);
}

Object* ReferenceCountHeader::GetObject()
{
    return (Object*) ((ObjHeader*)(this + 1) + 1);
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

