using System;

[ReferenceCounted]
public class TestParameterPassing2
{
    public static int Count = 0;

    public TestParameterPassing2()
    {
        Count++;
    }

    ~TestParameterPassing2()
    {
        Count--;
    }

    public static void Main()
    {

        TestParameterPassing2 obj = new TestParameterPassing2();
        Func( obj );
        Assert( 1, Count );
        Assert( 1, GC.ReferenceCount(obj) );
    }

    private static void Func( TestParameterPassing2 obj )
    {
        Assert( 2, GC.ReferenceCount(obj) );
        obj = new TestParameterPassing2();
        Assert( 1, GC.ReferenceCount(obj) );
        Assert( 2, Count );

        Func2( obj );
    }

    private static void Func2( TestParameterPassing2 obj )
    {
        Assert( 2, GC.ReferenceCount(obj) );
        TestParameterPassing2 o2 = obj;
        Assert( 3, GC.ReferenceCount(o2) );
        obj = null;
        Assert( 2, GC.ReferenceCount(o2) );
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