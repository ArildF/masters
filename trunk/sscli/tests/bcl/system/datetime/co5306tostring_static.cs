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
using System.Threading;
using System;
public class Co5306ToString_static
{
 public static readonly String s_strActiveBugNums = "";
 public static readonly String s_strDtTmVer       = "";
 public static readonly String s_strClassMethod   = "DateTime.ToString()";
 public static readonly String s_strTFName        = "Co5306ToString_static.cs";
 public static readonly String s_strTFAbbrev      = "Co5306";
 public static readonly String s_strTFPath        = "";
 public virtual Boolean runTest()
   {
   Console.Error.WriteLine(s_strTFPath + " " + s_strTFName + " , for " + s_strClassMethod + " , Source ver " + s_strDtTmVer);
   int iCountErrors = 0;
   int iCountTestcases = 0;
   String strLoc = "Loc_000oo";
   DateTime dt1 ;
   DateTime dt2 ;
   DateTime dt3 ;
   TimeSpan ts1 ;
   String strOut;
   String strDate1;
   String strDate2;
   int inYear = 0;
   int inMonth = 0;
   int inDay = 0;
   int inHour = 0;
   int inMinute = 0;
   int inSecond = 0;
   try {
   LABEL_860_GENERAL:
   do
     {
     DateTime dttmNow = DateTime.Now;
     Random rand = new Random( ( ( dttmNow.Second * 1000 ) + dttmNow.Millisecond ) );
     String str1;
     strLoc = "Loc_128wi";
     inYear = 1999;
     inMonth = 12;
     inDay = 31;
     inHour = 23;
     inMinute = 59;
     inSecond = 59;
     dt1 = new DateTime( inYear, inMonth, inDay, inHour, inMinute, inSecond );
     dt2 = DateTime.Parse(dt1.ToString());
     iCountTestcases++;
     if(! dt1.ToString().Equals( dt2.ToString() ))
       {
       iCountErrors++;
       Console.WriteLine( s_strTFAbbrev+ "Err_819ni! dt1=="+dt1.ToString());
       }
     strLoc = "Loc_840ji";
     strDate1 = "12/31/99 11:59:59";
     strDate2 = "12/31/1999 11:59:59";
     dt1 = DateTime.Parse(strDate1);
     dt2 = DateTime.Parse(strDate2);
     iCountTestcases++;
     if(!dt1.ToString().Equals(dt2.ToString()))
       {
       iCountErrors++;
       Console.WriteLine( s_strTFAbbrev+ "Err_978mq! ");
       }
     strLoc = "Loc_987he";
     strDate1 = "12/31/00 11:59:59 PM";
     dt1 = DateTime.Parse(strDate1);
     dt2 = DateTime.Parse(dt1.ToString());
     iCountTestcases++;
     if(!dt1.ToString().Equals(dt2.ToString()))
       {
       iCountErrors++;
       Console.WriteLine( s_strTFAbbrev+ "Err_982jw! dt1=="+dt1.ToString());
       }
     strLoc = "Loc_5092s";
     int iMaxCounter = 200;
     for(int i = 0 ; i < iMaxCounter ; i++)
       {
       inYear = rand.Next(100, 9999);
       inMonth = rand.Next(1, 12);
       inDay = rand.Next(1, 28);
       inHour = rand.Next(0, 23);
       inMinute = rand.Next(0, 59);
       inSecond = rand.Next(0, 59);
       str1 = inYear+"/"+inMonth+"/"+inDay+" "+inHour+":"+inMinute+":"+inSecond;
       dt1 = new DateTime(inYear, inMonth, inDay, inHour, inMinute, inSecond);
       dt2 = DateTime.Parse(str1);
       iCountTestcases++;
       if(!dt1.ToString().Equals(dt2.ToString()))
	 {
	 Console.WriteLine("Error_11111! dt1=="+dt1.ToString()+"    , dt2=="+dt2.ToString());
	 iCountErrors++;
	 }
       }
     } while (false);
   } catch (Exception exc_general ) {
   ++iCountErrors;
   Console.WriteLine(s_strTFAbbrev +" Error Err_8888yyy!  strLoc=="+ strLoc +", exc_general=="+exc_general);
   }
   if ( iCountErrors == 0 )
     {
     Console.Error.WriteLine( "paSs.   "+s_strTFPath +" "+s_strTFName+" ,iCountTestcases=="+iCountTestcases);
     return true;
     }
   else
     {
     Console.Error.WriteLine("FAiL!   "+s_strTFPath+" "+s_strTFName+" ,iCountErrors=="+iCountErrors+" , BugNums?: "+s_strActiveBugNums );
     return false;
     }
   }
 public static void Main(String[] args)
   {
   Boolean bResult = false;
   Co5306ToString_static cbA = new Co5306ToString_static();
   try {
   bResult = cbA.runTest();
   } catch (Exception exc_main){
   bResult = false;
   Console.WriteLine(s_strTFAbbrev+ "FAiL! Error Err_9999zzz! Uncaught Exception in main(), exc_main=="+exc_main);
   }
   if (!bResult)
     {
     Console.WriteLine(s_strTFName+ s_strTFPath);
     Console.Error.WriteLine( " " );
     Console.Error.WriteLine( "FAiL!  "+ s_strTFAbbrev);
     Console.Error.WriteLine( " " );
     }
   if (bResult) Environment.ExitCode = 0; else Environment.ExitCode = 1;
   }
}
