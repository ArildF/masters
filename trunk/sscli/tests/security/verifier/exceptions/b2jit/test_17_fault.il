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
.assembly test_17_fault {}
.class TestClass{
.method public static void test_17_fault(){
.locals init(int32 locInt1)
  ldc.i4.1
  stloc locInt1
  ldstr      "Test is running"
  call       void [mscorlib]System.Console::WriteLine(class System.String)  
lbl_17_startTry:
  lbl_17_1: nop
  leave lbl_17_exitSEH
lbl_17_endTry:
lbl_17_startFault:
   endfault
lbl_17_endFault:
lbl_17_startCatch1:
   leave lbl_17_exitSEH
lbl_17_endCatch1:
.try  lbl_17_startTry to lbl_17_endTry fault  handler lbl_17_startFault to lbl_17_endFault
.try  lbl_17_startTry to lbl_17_endTry catch ['mscorlib']System.Exception  handler lbl_17_startCatch1 to lbl_17_endCatch1
lbl_17_exitSEH:
  ret
}
.method public static void Main(class ['mscorlib']System.String[] arg)
{
    call void TestClass::test_17_fault()
    .entrypoint
    ret
}
  .method public specialname rtspecialname instance void .ctor() il managed
  {
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void ['mscorlib']System.Object::.ctor()
    IL_0006:  ret
  } 
}
