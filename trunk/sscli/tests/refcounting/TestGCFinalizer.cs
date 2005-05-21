using System;

public class NonRefCounted
{
    public RefCounted Field;
}

[ReferenceCounted]
public class RefCounted
{
    public RefCounted()
    {
        Count++;
    }

    ~RefCounted()
    {
        Count--;
    }

    public static int Count;
}

public class Test
{
    public static void Main()
    {
        Func();
        
        GC.Collect();
        GC.WaitForPendingFinalizers();

        Assert( 0, RefCounted.Count );

    }

    static void Func()
    {
        NonRefCounted obj = new NonRefCounted();
        obj.Field = new RefCounted();

        obj = new NonRefCounted();
        obj.Field = new RefCounted();

        obj = new NonRefCounted();
        obj.Field = new RefCounted();

        obj = new NonRefCounted();
        obj.Field = new RefCounted();

        Assert( 1, GC.ReferenceCount(obj.Field) );
        Assert( 4, RefCounted.Count );
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