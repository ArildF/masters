.assembly extern mscorlib {}

.module 'another.dll'

.assembly 'another' // as "another.dll"
 { 
.custom instance void [mscorlib]System.Security.AllowPartiallyTrustedCallersAttribute::.ctor() = ( 01 00 00 00 )
 
  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
 

.class public auto ansi A extends [mscorlib]System.Object
{
  .field public static int32 iStaticPublic
  .field static family int32 iStaticFamily
  .field static assembly int32 iStaticAssembly
  .field static famorassem int32 iStaticFamAssembly
  .field static famandassem int32 iStaticFamAndAssembly
  .field private static int32 iStaticPrivate

  .field family int32 iFamily
  .field public int32 iPublic
  .field private int32 iPrivate
  .field assembly int32 iAssembly
  .field famorassem int32 iAssFamily
  .field famandassem int32 iAssAndFamily
  .method public instance void Foo() il managed
  {
    // Code size       29 (0x1d)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldc.i4.2
    IL_0002:  stfld      int32 A::iPrivate
    IL_0007:  ldarg.0
    IL_0008:  ldfld      int32 A::iPrivate
    IL_000d:  call       void [mscorlib]System.Console::WriteLine(int32)
    IL_0012:  ldsfld     int32 A::iStaticPrivate
    IL_0017:  call       void [mscorlib]System.Console::WriteLine(int32)
    IL_001c:  ret
  } // end of method 'A::Foo'

  .method public specialname rtspecialname instance void .ctor() il managed
  {
    // Code size       14 (0xe)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldc.i4.2
    IL_0002:  stfld      int32 A::iPrivate
    IL_0007:  ldarg.0
    IL_0008:  call       instance void [mscorlib]System.Object::.ctor()
    IL_000d:  ret
  } // end of method 'A::.ctor'

} // end of class 'A'

//*********** DISASSEMBLY COMPLETE ***********************
