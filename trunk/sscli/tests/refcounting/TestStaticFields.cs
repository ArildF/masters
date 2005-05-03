using System;

public class Fields
{
    public static TestStaticFields Field;
}

[ReferenceCounted]
public class TestStaticFields
{
    public TestStaticFields()
    {
        Count++;
    }

    ~TestStaticFields()
    {
        Count--;
    }

    public static void Main()
    {
        TestStaticFields obj = new TestStaticFields();

        Assert( 1, Count );
        Assert( 1, GC.ReferenceCount(obj) ); 

        Fields.Field = obj; 

        Assert( 1, Count );
        Assert( 2, GC.ReferenceCount(obj) );

        Fields.Field = null;

        Assert( 1, Count );
        Assert( 1, GC.ReferenceCount(obj) ); 
        
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