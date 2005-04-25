using System;

[ReferenceCounted]
public class TestGCReferenceCount
{
    public static int Main()
    {
        TestGCReferenceCount obj = new TestGCReferenceCount();
        int count = GC.ReferenceCount(obj);
        if ( count != 1 )
        {
            Console.WriteLine( "Expected a reference count of 1, got {0}", count );
            return 1;
        }

        return 0;
    }
}