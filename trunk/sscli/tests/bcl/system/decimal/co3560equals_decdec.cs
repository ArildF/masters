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
using System;
public class Co3560Equals_decdec
{
 static String strName = "Decimal.Equals";
 static String strTest = "Co3560Equals_decdec.cs";
 static String strPath = "";
 public Boolean runTest()
   {
   int iCountErrors = 0;
   int iCountTestcases = 0;
   String strLoc="123_er";
   String strInfo = null;
   Console.Out.Write( strName );
   Console.Out.Write( ": " );
   Console.Out.Write( strPath + strTest );
   Console.Out.WriteLine( " runTest started..." );
   Decimal cncy1;
   Decimal[] dcmlFirstValues = {Decimal.MaxValue, Decimal.MinusOne, Decimal.Parse("123456789012345.98765432101234"), 
				new Decimal(0.00000000000000000001), Decimal.Zero, new Decimal(Int32.MaxValue),
				Decimal.MaxValue, new Decimal(1234.5678)};
   Decimal[] dcmlSecondValues = {Decimal.One, Decimal.MinValue, Decimal.Parse("-123456789012345.98765432101234"), 
				 new Decimal(-0.0000000000000000001), new Decimal(-0.0001), new Decimal(Int32.MinValue),
				 Decimal.MinValue, new Decimal(-1234.5678)};
   Decimal[] dcmlExceptions = {}; 
   int ina;
   try
     {
     LABEL_860_GENERAL:
     do
       {
       for (int aa = 0; aa < dcmlFirstValues.Length; aa++)
	 {
	 ++iCountTestcases;
	 if ( Decimal.Equals(dcmlFirstValues[aa], dcmlSecondValues[aa]) != false)
	   {
	   ++iCountErrors;
	   Console.Error.WriteLine(  "POINTTOBREAK: Error E_972qr_" + aa + "  Decimal.Equals(dcmlFirstValues[aa], dcmlSecondValues[aa] ==" + Decimal.Equals(dcmlFirstValues[aa], dcmlSecondValues[aa]) );
	   }
	 }
       for (int aa = 0; aa < dcmlFirstValues.Length; aa++)
	 {
	 ++iCountTestcases;
	 if ( Decimal.Equals(dcmlSecondValues[aa], dcmlFirstValues[aa]) != false)
	   {
	   ++iCountErrors;
	   Console.Error.WriteLine(  "POINTTOBREAK: Error E_346mk_" + aa + "  Decimal.Equals(dcmlSecondValues[aa], dcmlFirstValues[aa]) ==" + Decimal.Equals(dcmlSecondValues[aa], dcmlFirstValues[aa])  );
	   }
	 }
       for (int aa = 0; aa < dcmlFirstValues.Length; aa++)
	 {
	 ++iCountTestcases;
	 if ( Decimal.Equals(dcmlFirstValues[aa], dcmlFirstValues[aa]) != true)
	   {
	   ++iCountErrors;
	   Console.Error.WriteLine(  "POINTTOBREAK: Error E_934qm_" + aa + "  Decimal.Equals(dcmlFirstValues[aa], dcmlFirstValues[aa]) ==" + Decimal.Equals(dcmlFirstValues[aa], dcmlFirstValues[aa])  );
	   }
	 }
       for (int aa = 0; aa < dcmlSecondValues.Length; aa++)
	 {
	 ++iCountTestcases;
	 if ( Decimal.Equals(dcmlSecondValues[aa], dcmlSecondValues[aa]) != true)
	   {
	   ++iCountErrors;
	   Console.Error.WriteLine(  "POINTTOBREAK: Error E_134ak_" + aa + "  Decimal.Equals(dcmlSecondValues[aa], dcmlSecondValues[aa]) ==" + Decimal.Equals(dcmlSecondValues[aa], dcmlSecondValues[aa])  );
	   }
	 }
       } while ( false );
     }
   catch (Exception exc_general)
     {
     ++iCountErrors;
     Console.Error.WriteLine ( "POINTTOBREAK: Error Err_103! strLoc=="+ strLoc + " ,exc_general=="+exc_general  );
     }
   if ( iCountErrors == 0 )
     {
     Console.Error.WriteLine( "paSs. " + strPath + strTest + "  iCountTestcases==" + iCountTestcases );
     return true;
     }
   else
     {
     Console.Error.WriteLine( "FAiL! " + strPath + strTest + "   iCountErrors==" + iCountErrors );
     return false;
     }
   }
 public static void Main( String[] args ) 
   {
   Boolean bResult = false;	
   Co3560Equals_decdec oCbTest = new Co3560Equals_decdec();
   try
     {
     bResult = oCbTest.runTest();
     }
   catch ( Exception exc_main )
     {
     bResult = false;
     Console.Error.WriteLine(  "POINTTOBREAK:  FAiL!  Error Err_999zzz! (" + strTest + ") Uncaught Exception caught in main(), exc_main==" + exc_main  );
     }
   if ( ! bResult )
     Console.Error.WriteLine(  "PATHTOSOURCE:  " + strPath + strTest + "   FAiL!"  );
   if ( bResult == true ) Environment.ExitCode = 0; else Environment.ExitCode = 1; 
   }
}
