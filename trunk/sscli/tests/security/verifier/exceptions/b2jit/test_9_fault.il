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
.assembly test_9_fault {}
.class TestClass{
.method public static void test_9_fault(){
.locals init(int32 locInt1)
  ldc.i4.1
  stloc locInt1
  ldstr      "Test is running"
  call       void [mscorlib]System.Console::WriteLine(class System.String)  
lbl_9_startTry:
  lbl_9_1: nop
   newobj     instance void [mscorlib]System.Exception::.ctor()
   throw
  leave lbl_9_exitSEH
lbl_9_endTry:
lbl_9_startFault:
  ldstr      "inside fault"
  call       void [mscorlib]System.Console::WriteLine(class System.String)  
 rethrow  
   endfault
lbl_9_endFault:
.try  lbl_9_startTry to lbl_9_endTry fault  handler lbl_9_startFault to lbl_9_endFault
lbl_9_exitSEH:
  ret
}
.method public static void Main(class ['mscorlib']System.String[] arg)
{
    call void TestClass::test_9_fault()
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
