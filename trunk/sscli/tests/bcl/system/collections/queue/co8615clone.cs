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
using System.Collections;
using System.Globalization;
using System.IO;
public class Co8615Clone
{
    public static String s_strActiveBugNums = "";
    public static String s_strDtTmVer       = "";
    public static String s_strClassMethod   = "Queue.Clone()";
    public static String s_strTFName        = "Co8615Clone.cs";
    public static String s_strTFAbbrev      = s_strTFName.Substring(0,6);
    public static String s_strTFPath        = Environment.CurrentDirectory;
    public bool runTest()
    {
        Console.WriteLine(s_strTFPath + "\\" + s_strTFName + " , for " + s_strClassMethod + " , Source ver " + s_strDtTmVer);
        String strLoc = "Loc_000oo";
        String strValue = String.Empty;
        int iCountErrors = 0;
        int iCountTestcases = 0;
        Queue que;		
        Queue queClone;		
        A a1;
        A a2;
        try
        {
            strLoc = "Loc_384sdg";
            iCountTestcases++;
            que = new Queue();
            for(int i=0; i<100; i++)
                que.Enqueue(i);
            queClone = (Queue)que.Clone();
            if(queClone.Count!=100)
            {
                iCountErrors++;
                Console.WriteLine( "Err_93745sdg! wrong value returned");
            }
            for(int i=0; i<100; i++)
            {
                if(!queClone.Contains(i))
                {
                    iCountErrors++;
                    Console.WriteLine( "Err_93475sdg! wrong value returned");
                }
            }
            strLoc = "Loc_384sdg";
            iCountTestcases++;
            que = new Queue();
            que.Enqueue(new A(10));
            queClone = (Queue)que.Clone();
            if(queClone.Count!=1)
            {
                iCountErrors++;
                Console.WriteLine( "Err_93745sdg! wrong value returned");
            }
            a1 = (A)que.Dequeue();
            a1.I=50;
            if(queClone.Count!=1)
            {
                iCountErrors++;
                Console.WriteLine( "Err_93745sdg! wrong value returned");
            }
            a2 = (A)queClone.Dequeue();
            if(a2.I!=50)
            {
                iCountErrors++;
                Console.WriteLine( "Err_93745sdg! wrong value returned, " + a2.I);
            }
        } 
        catch (Exception exc_general ) 
        {
            ++iCountErrors;
            Console.WriteLine (s_strTFAbbrev + " : Error Err_8888yyy!  strLoc=="+ strLoc +", exc_general=="+exc_general.ToString());
        }
        if ( iCountErrors == 0 )
        {
            Console.WriteLine( "paSs. "+s_strTFName+" ,iCountTestcases=="+iCountTestcases.ToString());
            return true;
        }
        else
        {
            Console.WriteLine("FAiL! "+s_strTFName+" ,inCountErrors=="+iCountErrors.ToString()+" , BugNums?: "+s_strActiveBugNums );
            return false;
        }
    }
    public static void Main(String[] args)
    {
        bool bResult = false;
        Co8615Clone cbA = new Co8615Clone();
        try 
        {
            bResult = cbA.runTest();
        } 
        catch (Exception exc_main)
        {
            bResult = false;
            Console.WriteLine(s_strTFAbbrev + " : FAiL! Error Err_9999zzz! Uncaught Exception in main(), exc_main=="+exc_main.ToString());
        }
        if (!bResult)
        {
            Console.WriteLine ("Path: "+s_strTFPath+"\\"+s_strTFName);
            Console.WriteLine( " " );
            Console.WriteLine( "FAiL!  "+ s_strTFAbbrev);
            Console.WriteLine( " " );
        }
        if (bResult) Environment.ExitCode = 0; else Environment.ExitCode = 1;
    }
}
class A
{
    int i;
    public A(int i)
    {
        this.i=i;
    }
    internal Int32 I
    {
        set{i=value;}
        get{return i;}
    }
}
