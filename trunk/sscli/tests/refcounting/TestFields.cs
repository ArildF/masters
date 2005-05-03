using System;

public class Fields
{
    public TestFields Field;
}

[ReferenceCounted]
public class TestFields
{
    public TestFields()
    {
        Count++;
    }

    ~TestFields()
    {
        Count--;
    }

    public static void Main()
    {
        Fields fields = new Fields();
        TestFields obj = new TestFields();

        Assert( 1, Count );
        Assert( 1, GC.ReferenceCount(obj) ); 

        fields.Field = obj;            

        Assert( 1, Count );
        Assert( 2, GC.ReferenceCount(obj) );
        
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