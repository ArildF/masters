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
using System.IO;
using System.Text;
using System;
public class Co4244NextBytes
{
 internal static String strName = "Random.Co4244NextBytes";
 internal static String strTest = "Co4244NextBytes";
 public virtual bool runTest()
   {
   int iCountTestcases = 0;
   int iCountErrors = 0; 
   Console.Error.WriteLine( strName + ": " + strTest+ " runTest started..." );
   Random rdm = null;
   byte [] retVal = null;
   iCountTestcases++;
   rdm = new Random();
   try {
   rdm.NextBytes (null);
   print ("E_643d");
   iCountErrors++;
   }
   catch (ArgumentException ) {
   }
   catch (Exception exc) {
   iCountErrors++;
   print ("I_536l");
   printexc (exc);
   }
   retVal = new byte[10];
   iCountTestcases++;
   try {
   rdm.NextBytes (retVal);
   Console.Error.Write ("Returned Bytes: ");
   }
   catch (Exception exc) {
   print ("E_87fy");
   iCountErrors++;
   printexc (exc);
   }
   if ( iCountErrors == 0 )
     {
     Console.Error.WriteLine( "paSs. " + strTest + "   iCountTestCases == " + iCountTestcases);
     return true;
     }
   else
     {
     Console.Error.WriteLine( "FAiL. " + strTest + "    iCountErrors==" + iCountErrors);
     return false;
     }
   }
 private void printexc(Exception exc)
   {
   String output = "EXTENDEDINFO: "+exc.ToString();
   Console.Error.WriteLine(output);
   }
 private void print(String error)
   {
   StringBuilder output = new StringBuilder("POINTTOBREAK: find ");
   output.Append(error);
   output.Append(" (" + strTest + ")");
   Console.Error.WriteLine(output.ToString());
   }
 public static void Main( String[] args )
   {
   bool bResult = false;	
   Co4244NextBytes oCbTest = new Co4244NextBytes();
   try
     {
     bResult = oCbTest.runTest();
     }
   catch( Exception ex )
     {
     bResult = false;
     Console.Error.Write( strTest );
     Console.Error.WriteLine(  ": Main() Uncaught exception" );
     Console.Error.WriteLine( ex.ToString() );
     }
   if ( bResult == true ) Environment.ExitCode = 0; else Environment.ExitCode = 1;
   }
} 
