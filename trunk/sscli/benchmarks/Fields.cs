using System;

[ReferenceCounted]
public class ReferenceCounted
{
    public int i;
}

public class TracingGC
{
    public int i;
}

public class Benchmark
{
    public static void Main()
    {
        for ( int i = 0; i < 10; i++ )
            DoBenchmark();
    }
    
    private static void DoBenchmark()
    {
        Timer t = new Timer();
        
        t.Start();
        rc = new ReferenceCounted();
        for( int i = 0; i < NumIterations; i++ )
        {
            rc2 = rc;
            rc3 = rc2;
            rc = rc3;
            rc3 = rc;
            
        }        
        t.End();
        Console.WriteLine( "Reference counted: {0}", t.Interval );
        
        t.Start();
        gc = new TracingGC();
        for( int i = 0; i < NumIterations; i++ )
        {
            gc2 = gc;
            gc3 = gc2;
            gc = gc3;
            gc3 = gc;
        }
        t.End();
        Console.WriteLine( "Tracing GC: {0}", t.Interval ); 
    }
    
    private static ReferenceCounted rc, rc2, rc3;
    private static TracingGC gc, gc2, gc3;
    
    private const int NumIterations = 10000000;
    
}