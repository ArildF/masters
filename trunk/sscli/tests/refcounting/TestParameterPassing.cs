using System;

[ReferenceCounted]
public class TestParameterPassing
{
    public static int Count = 0;

    public TestParameterPassing()
    {
        Count++;
    }

    ~TestParameterPassing()
    {
        Count--;
    }

    public static void Main()
    {
        Func();
        Assert( 0, Count );
    }

    private static void Func()
    {
        TestParameterPassing obj = new TestParameterPassing();
        Assert( 1, GC.ReferenceCount(obj) );
        Assert( 1, Count );

        Func2( obj );
    }

    private static void Func2( TestParameterPassing obj )
    {
        Assert( 2, GC.ReferenceCount(obj) );
        obj.MemberFunc(obj);
    }

    private void MemberFunc( TestParameterPassing obj )
    {
        Assert( 3, GC.ReferenceCount(obj) );
        Assert( 1, Count );
    }

    private static void Assert( int expected, int actual )
    {
        if ( expected != actual )
        {
            System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(true);
            Console.WriteLine( "Expected {0}, got {1}", expected, actual );
            Console.WriteLine( trace );
            Environment.Exit(1);
        }
    }
}