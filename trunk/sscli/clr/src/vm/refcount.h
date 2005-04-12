#ifndef _REFCOUNT_H_
#define _REFCOUNT_H_

class ReferenceCountedHeap
{
public:
    ReferenceCountedHeap()
    {;}

    HRESULT Initialize();
    Object* Alloc(DWORD size);
private:
    BYTE* m_HeapStart;
    BYTE* m_HeapPointer;
};

OBJECTREF RCAllocateObject( MethodTable* pMT );

#endif