using System;

public struct Big
{
    public long L1, L2, L3, L4, L5, L6, L7, L8, L9;
}

[ReferenceCounted]
public class MassiveAllocations
{
    public MassiveAllocations()
    {
        this.big.L1 = 42;
    }

    public void Method()
    {
        this.big.L2 = this.big.L1;
    }

    public static void Main()
    {
        for( int i = 0; i < 10000; i++ )
        {
            Console.WriteLine( "Allocation no {0}", i );
            MassiveAllocations m = new MassiveAllocations();
            m.Method();
        }
    }

    private Big big;
}