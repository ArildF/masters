.assembly extern mscorlib {}
//do a lot of assign. eventually try to access invisible field. Should get VE

.module 'scope4-1.exe'

.assembly 'scope4-1' // as "scope4-1.exe"
 { 
.custom instance void [mscorlib]System.Security.AllowPartiallyTrustedCallersAttribute::.ctor() = ( 01 00 00 00 )
 
  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
 

.class public auto ansi A extends [mscorlib]System.Object
{
  .field family int32 i
  .method public specialname rtspecialname instance void .ctor() il managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ret
  } // end of method 'A::.ctor'

} // end of class 'A'

.class public auto ansi B extends A
{
  .field public int32 j
  .method public specialname rtspecialname instance void .ctor() il managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void A::.ctor()
    IL_0006:  ret
  } // end of method 'B::.ctor'

} // end of class 'B'

.class public auto ansi TestClass extends A
{
  .method public static void  Main(class ['mscorlib']System.String[] args) il managed
  {
    .entrypoint
    // Code size       41 (0x29)
    .maxstack  2
    .locals init (class A V_0,
             class B V_1,
             class TestClass V_2)
    IL_0000:  newobj     instance void B::.ctor()
    IL_0005:  stloc.1
    IL_0006:  ldloc.1
    IL_0007:  stloc.0
    IL_0008:  ldloc.1
    IL_0009:  ldc.i4.5
    IL_000a:  stfld      int32 B::j
    IL_000f:  ldloc.0
    //IL_0010:  castclass  TestClass
    IL_0015:  stloc.2
    IL_0016:  ldloc.2
    IL_0017:  ldc.i4.7
    IL_0018:  stfld      int32 A::i
    IL_001d:  ldloc.2
    IL_001e:  ldfld      int32 A::i
    IL_0023:  call       void [mscorlib]System.Console::WriteLine(int32)
    IL_0028:  ret
  } // end of method 'TestClass::Main'

  .method public specialname rtspecialname instance void .ctor() il managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void A::.ctor()
    IL_0006:  ret
  } // end of method 'TestClass::.ctor'

} // end of class 'TestClass'

//*********** DISASSEMBLY COMPLETE ***********************
