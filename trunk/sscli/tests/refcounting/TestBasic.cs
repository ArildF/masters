using System;

// a struct that's large
public struct LargeStruct
{
    public decimal d1, d2, d3, d4;
}



[ReferenceCounted]
public class TestBasic
{  
    public LargeStruct Struct;

    public static void Main()
    {
        TestBasic b = new TestBasic();
        b.Struct.d1 = 42;
        b.Struct.d2 = 84;
        b.Struct.d3 = 21;
        b.Struct.d4 = 69;
      
        FailUnlessEquals( 42, b.Struct.d1 );
        FailUnlessEquals( 84, b.Struct.d2 );
        FailUnlessEquals( 21, b.Struct.d3 );
        FailUnlessEquals( 69, b.Struct.d4 );
    }

    private static void FailUnlessEquals( decimal expected, decimal actual )
    {
        if ( expected != actual )
        {
            Console.WriteLine( "Expected {0}, got {1}", expected, actual );
            Environment.Exit( 1 );
        }
    }
}