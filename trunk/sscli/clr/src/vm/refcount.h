#ifndef _REFCOUNT_H_
#define _REFCOUNT_H_
#include "gmheap.hpp"

class ReferenceCountedHeap
{
public:
    ReferenceCountedHeap()
    {;}

    HRESULT Initialize();
    Object* Alloc(DWORD size);
    void Free(void* ptr);
private:
    gmallocHeap* m_Heap;
};

class ReferenceCountHeader
{
public:
    ReferenceCountHeader() : m_RefCount(0)
    {;}

    ULONG AddRef();
    ULONG Release();
    ULONG ReferenceCount()
    {
        return m_RefCount;
    }

    Object* GetObject();
private:
    void Finalize();
    LONG m_RefCount;
};

OBJECTREF RCAllocateObject( MethodTable* pMT );

#endif