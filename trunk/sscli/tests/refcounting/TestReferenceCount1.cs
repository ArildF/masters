using System;

[ReferenceCounted]
public class TestReferenceCount1
{
    public TestReferenceCount1()
    {
        Count++;
    }

    ~TestReferenceCount1()
    {
        Count--;
    }

    public static void Main()
    {
        TestReferenceCount1 t1, t2;
        t1 = new TestReferenceCount1();
        Assert( 1, GC.ReferenceCount(t1) );
        Assert( 1, Count );

        // two vars pointing to the same object
        t2 = t1;
        Assert( 2, GC.ReferenceCount(t1) );
        Assert( 2, GC.ReferenceCount(t2) );
        Assert( 1, Count );

        // point the second var to a new object
        t2 = new TestReferenceCount1();
        Assert( 1, GC.ReferenceCount(t1) );
        Assert( 1, GC.ReferenceCount(t2) );
        Assert( 2, Count );

        // point the first var to the second object
        t1 = t2;
        Assert( 1, Count );
        Assert( 2, GC.ReferenceCount(t1) );
        Assert( 2, GC.ReferenceCount(t2) );

        // set one of the vars to null
        t1 = null;
        Assert( 1, Count );
        Assert( 1, GC.ReferenceCount(t2) );

    }

    private static void Assert( int expected, int actual, string msg )
    {
        if ( expected != actual )
        {
            System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(true);
            Console.WriteLine( "{0}: Expected {1}, got {2}", msg, expected, actual );
            Console.WriteLine( trace );
            Environment.Exit(1);
        }
    }

    private static void Assert( int expected, int actual )
    {
        Assert( expected, actual, "Failure" );
    }



    private static int Count = 0;
}