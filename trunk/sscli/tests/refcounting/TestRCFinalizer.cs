using System;

[ReferenceCounted]
public class TestRCFinalizer
{
    private TestRCFinalizer Next;
    private static int Count = 0;

    public TestRCFinalizer()
    {
        Count++;
    }

    ~TestRCFinalizer()
    {
        Count--;
    }

    public static void Main()
    {
        TestRCFinalizer test = new TestRCFinalizer();
        test.Next = new TestRCFinalizer();
        test.Next.Next = new TestRCFinalizer();

        Assert( 3, Count );

        test = null;
        Assert( 0, Count );

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
}