#ifndef _REFCOUNT_H_
#define _REFCOUNT_H_

class ReferenceCountedHeap
{
public:
    ReferenceCountedHeap()
    {;}

    HRESULT Initialize();
};

#endif