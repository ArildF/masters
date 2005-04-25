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
private:
    gmallocHeap* m_Heap;
};

class ReferenceCountHeader
{
public:
    ULONG AddRef();
    ULONG Release();
    ULONG ReferenceCount()
    {
        return m_RefCount;
    }
private:
    ULONG m_RefCount;
};

OBJECTREF RCAllocateObject( MethodTable* pMT );

#endif