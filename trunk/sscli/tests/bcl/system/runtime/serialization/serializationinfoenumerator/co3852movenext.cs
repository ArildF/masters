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
using System;
using System.Runtime.Serialization;
using System.IO;
public class Co3852MoveNext
{
	public static String s_strActiveBugNums = "";
	public static String s_strDtTmVer       = "";
	public static String s_strClassMethod   = "SerializationInfo.MoveNext()";
	public static String s_strTFName        = "Co3852MoveNext.cs";
	public static String s_strTFAbbrev      = s_strTFName.Substring(0, 6);
	public static String s_strTFPath        = Environment.CurrentDirectory;
	public bool runTest()
	{
		Console.WriteLine(s_strTFPath + " " + s_strTFName + " , for " + s_strClassMethod + " , Source ver : " + s_strDtTmVer);
		int iCountErrors = 0;
		int iCountTestcases = 0;
		String strLoc = "Loc_000oo";
		SerializationInfo serinfo1 = null;
		Type tpName = null;
		Int32 iNumberOfMembers;
		String[] arrNames = null;
		Object[] arrValues = null;
		Int32 iNum = 0;
		SerializationInfoEnumerator serenum1 = null;
		try {
			do
			{
				tpName = Type.GetType("System.Int32");
				serinfo1 = new SerializationInfo(tpName, new FormatterConverter());
				iNumberOfMembers = 50;
				arrNames = new String[iNumberOfMembers];
				arrValues = new Object[iNumberOfMembers];
				for(int i=0; i<iNumberOfMembers;i++)
				{
					arrNames[i] = i.ToString();
					arrValues[i] = i;
					serinfo1.AddValue(arrNames[i], arrValues[i], typeof(Int32));
				}
				serenum1 = serinfo1.GetEnumerator();
				serenum1 = serinfo1.GetEnumerator();
				iNum = 0;
				while(serenum1.MoveNext())
				{
					iCountTestcases++;
					if(!arrValues[iNum].Equals(serenum1.Value))
					{
						iCountErrors++;
						Console.WriteLine("Err_0246wd_" + iNum.ToString() + "! Wrong value, " + arrValues[iNum].ToString());
					}
					iCountTestcases++;
					if(!arrNames[iNum].Equals(serenum1.Name))
					{
						iCountErrors++;
						Console.WriteLine("Err_0246wd_" + iNum.ToString() + "! Wrong value, " + arrValues[iNum].ToString());
					}
					iCountTestcases++;
					if(!typeof(Int32).Equals(serenum1.ObjectType))
					{
						iCountErrors++;
						Console.WriteLine("Err_0246cds_" + iNum.ToString() + "! Wrong value, " + serenum1.ObjectType);
					}
					iNum++;
				}
				iCountTestcases++;
				if(serenum1.MoveNext())
				{
					iCountErrors++;
					Console.WriteLine("Err_925ca! most peculiar, MoveNext returned true!");
				}
				tpName = Type.GetType("System.Int16");
				serinfo1 = new SerializationInfo(tpName, new FormatterConverter());
				serenum1 = serinfo1.GetEnumerator();
				iCountTestcases++;
				if(serenum1.MoveNext())
				{
					iCountErrors++;
					Console.WriteLine("Err_03576bfd! most peculiar, MoveNext returned true!");
				}
			} while (false);
			} catch (Exception exc_general ) {
			++iCountErrors;
			Console.WriteLine (s_strTFAbbrev + " : Error Err_8888yyy!  strLoc=="+ strLoc +", exc_general==\n"+exc_general.StackTrace);
		}
		if ( iCountErrors == 0 )
		{
			Console.WriteLine( "paSs.   "+s_strTFPath +" "+s_strTFName+" ,iCountTestcases=="+iCountTestcases.ToString());
			return true;
		}
		else
		{
			Console.WriteLine("FAiL!   "+s_strTFPath+" "+s_strTFName+" ,iCountErrors=="+iCountErrors.ToString()+" , BugNums?: "+s_strActiveBugNums );
			return false;
		}
	}
	public static void Main(String[] args)
	{
		bool bResult = false;
		Co3852MoveNext cbA = new Co3852MoveNext();
		try {
			bResult = cbA.runTest();
			} catch (Exception exc_main){
			bResult = false;
			Console.WriteLine(s_strTFAbbrev + " : FAiL! Error Err_9999zzz! Uncaught Exception in main(), exc_main=="+exc_main.ToString());
		}
		if (!bResult)
		{
			Console.WriteLine ("Path: "+s_strTFName + s_strTFPath);
			Console.WriteLine( " " );
			Console.WriteLine( "FAiL!  "+ s_strTFAbbrev);
			Console.WriteLine( " " );
		}
		if (bResult) Environment.ExitCode = 0; else Environment.ExitCode = 1;
	}
}
