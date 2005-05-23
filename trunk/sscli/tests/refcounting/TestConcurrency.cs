using System;
using System.Threading;
using System.Collections;

[ReferenceCounted]
public class TestConcurrency
{
    public void InstanceMethod()
    {
        // just do something here
        dummyField += 2;
    }
    

    public static void Main()
    {
        // make sure we deal with exceptions thrown on the threads
        AppDomain.CurrentDomain.UnhandledException += 
            new UnhandledExceptionEventHandler(ExceptionHandler);


        test = new TestConcurrency();
        for( int i = 0; i < NumThreads; i++ )
        {
            Thread t = new Thread( new ThreadStart(ThreadProc) );
            t.Start();
        }
        int remainingThreads = 0;
        while ( remainingThreads < NumThreads )
        {
            Interlocked.Exchange( ref remainingThreads, liveThreads );
            Thread.Sleep(50);
        }

        while( true )
        {
            remainingThreads = int.MaxValue;
            Interlocked.Exchange( ref remainingThreads, liveThreads );
            Console.WriteLine( remainingThreads );
            if ( remainingThreads <= 0 )
                break;

            // make the allocator work a little too
            TestConcurrency t3 = new TestConcurrency();

            Thread.Sleep( 50 );
        }

        int refcount = GC.ReferenceCount(test);
        Console.WriteLine( "Final reference count: {0}", refcount);
        if ( refcount != 1 )
        {
            Console.WriteLine( "Expected reference count to be 1, is {0}", refcount );
            Environment.Exit(1);
        }
    }

    private static void ExceptionHandler(object sender, UnhandledExceptionEventArgs args)
    {
        Exception e = (Exception) args.ExceptionObject;
        Console.WriteLine("ExceptionHandler caught {0} with message {1}.\nExiting: ", e, 
            e.Message);
        Environment.Exit(1);
    }


    private static void ThreadProc()
    {
        lock( syncObject )
        {
            Interlocked.Increment( ref liveThreads );
            Console.WriteLine( "Starting thread {0}", liveThreads );
        }
        ThreadWorker();     
        Console.WriteLine( "Exiting thread {0}", Thread.CurrentThread );
        Interlocked.Decrement( ref liveThreads );
        
    }

    private static void ThreadWorker()
    {
        TestConcurrency t = test;
        for ( int i = 0; i < NumCalls; i++ )
            HelperMethod( t ); 
    }

    private static void HelperMethod( TestConcurrency t )
    {
        TestConcurrency t2 = t;         
        TestConcurrency t3 = t2;
        for ( int i = 0; i < NumIterations; i++ )
        {
            t = t3;
            t2 = t;
            t3 = t2;
        }
    }

    private int dummyField; // just to give the type some weight
    private static TestConcurrency test;
    private static int liveThreads;
    private const int NumThreads = 50;
    private const int NumIterations = 1000;
    private const int NumCalls = 10;
    private static object syncObject = new object();
}

