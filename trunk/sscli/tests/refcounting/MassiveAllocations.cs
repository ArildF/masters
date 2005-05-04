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
        Count++;
    }

    ~MassiveAllocations()
    {
        Count--;        
    }

    public void Method()
    {
        this.big.L2 = this.big.L1;
    }

    public static void Main()
    {
        for( int i = 0; i < 10000; i++ )
        {
            MassiveAllocations m = new MassiveAllocations();
            m.Method();
            if ( Count != 1 )
            {
                Console.WriteLine( "Expected count to be 1, was {0}", Count );
                Environment.Exit(1);
            }
        }
    }

    private Big big;
    private static int Count;
}