// ==++==
//
//   
//    Copyright (c) 2002 Microsoft Corporation.  All rights reserved.
//   
//    The use and distribution terms for this software are contained in the file
//    named license.txt, which can be found in the root of this distribution.
//    By using this software in any fashion, you are agreeing to be bound by the
//    terms of this license.
//   
//    You must not remove this notice, or any other, from this software.
//   
//
// ==--==

// Tests KeepAlive() for array of objects

using System;

public class Test {

	public class Dummy {

		public static bool visited;
		~Dummy() {
			//Console.WriteLine("In Finalize() of Dummy");	
			visited=true;
		}
	}

	public static void Main() {

		Dummy[] obj = new Dummy[100];

		for(int i=0;i<100;i++) {
			obj[i]= new Dummy();
		}
			
		GC.Collect();
		GC.WaitForPendingFinalizers();
		
				
		if(Dummy.visited == false) {  // has not visited the Finalize()
			Environment.ExitCode = 0;
			Console.WriteLine("Test for KeepAlive() passed!");
		}
		else {
			Environment.ExitCode = 1;
			Console.WriteLine("Test for KeepAlive() failed!");
		}
	
		GC.KeepAlive(obj);	// will keep alive 'obj' till this point
	}
}
