using System;

[ReferenceCounted]
public class TestDestructor
{
    public TestDestructor()
    {
        Count++;
    }

    ~TestDestructor()
    {
        Count--;
    }

    public static void Main()
    {
        Create();
        if ( Count != 0 )
        {
            Console.WriteLine( "Expected 0 instances remaining, had {0}", Count );
            Environment.Exit( 1 );
        }
    }

    private static void Create()
    {
        TestDestructor t1 = new TestDestructor();
        TestDestructor t2 = new TestDestructor();
        TestDestructor t3 = new TestDestructor();
        TestDestructor t4 = new TestDestructor();
        TestDestructor t5 = new TestDestructor();
        TestDestructor t6 = new TestDestructor();
        TestDestructor t7 = new TestDestructor();
        TestDestructor t8 = new TestDestructor();
        TestDestructor t9 = new TestDestructor();
        TestDestructor t10 = new TestDestructor();

        if ( Count != 10 )
        {
            Console.WriteLine( "Expected 10 instances, had {0}", Count );
            Environment.Exit( 1 );
        }
    }

    private static long l1 = 0, l2 = 0;

    private static int Count;

    
}