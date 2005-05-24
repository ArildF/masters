using System;

public struct Big
{
    public long L1, L2, L3, L4, L5, L6, L7, L8, L9;
}

[ReferenceCounted]
public class ReferenceCounted
{
    public ReferenceCounted()
    {
        this.big.L1 = 42;
        Count++;
    }

    ~ReferenceCounted()
    {
        Count--;        
    }

    public void Method()
    {
        this.big.L2 = this.big.L1;
    }
    private Big big;
    private static int Count;
}


public class TracingGC
{
    public TracingGC()
    {
        this.big.L1 = 42;
        Count++;
    }

    ~TracingGC()
    {
        Count--;        
    }

    public void Method()
    {
        this.big.L2 = this.big.L1;
    }
    private Big big;
    private static int Count;
}

public class Benchmark
{
    public static void Main()
    {
        for( int i = 0; i < 10; i++ )
            DoBenchmark();
    }
    
    public static void DoBenchmark()
    {
        Timer t = new Timer();
        
        //~ t.Start();
        //~ for( int i = 0; i < NumIterations; i++ )
        //~ {
            //~ ReferenceCounted rc = new ReferenceCounted();
            //~ rc.Method();            
        //~ }
        //~ t.End();
        //~ Console.WriteLine( "Reference counted: {0}", t.Interval );
        
        t.Start();
        for( int i = 0; i < NumIterations; i++ )
        {
            TracingGC gc = new TracingGC();
            gc.Method();            
        }
        t.End();
        Console.WriteLine( "Tracing GC: {0}", t.Interval );
    }    
    
    private const int NumIterations = 100000;
}