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
namespace Microsoft.JScript 
{
  using System;

  [AttributeUsage(AttributeTargets.Method | AttributeTargets.Field)]
  public class Override : Attribute{
    public Override() {} 
  }

  [AttributeUsage(AttributeTargets.Method | AttributeTargets.Field)]
  public class Hide : Attribute{
    public Hide() {}
  }

}
