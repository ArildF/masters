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

OBJECTREF RCAllocateObject( MethodTable* pMT );

#endif