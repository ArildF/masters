//# ==++== 
//# 
//#   
//#    Copyright (c) 2002 Microsoft Corporation.  All rights reserved.
//#   
//#    The use and distribution terms for this software are contained in the file
//#    named license.txt, which can be found in the root of this distribution.
//#    By using this software in any fashion, you are agreeing to be bound by the
//#    terms of this license.
//#   
//#    You must not remove this notice, or any other, from this software.
//#   
//# 
//# ==--== 
//####################################################################################
@cc_on


import System;

var NULL_DISPATCH = null;
var apGlobalObj;
var apPlatform;
var lFailCount;


var iTestID = 228383;

/*






*/
///////////////////////////////////////////////////////////////////////////////////


@if(!@aspx)
  import System
@end

function populate(invar:Array){
  invar[0] = 2
  invar[1] = 4
  invar[2] = 1
  invar[3] = 3
}


function test1(invar:Array):String{
  return invar
}

function test2(invar:System.Int32[]):Array{
  return invar
}

///////////////////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
function arraywrap02() {

  apInitTest("ArrayWrap01");
  var res

  var nativearray : System.Int32[]
  var secondarray : System.Int32[]
  var JSArray     : Array



  apInitScenario("creating array wrappers using the Array constructor")
  nativearray = new System.Int32[4];  populate(nativearray)

  JSArray = new Array(nativearray)
  if (JSArray != "2,4,1,3") apLogFailInfo("wrong value", "2,4,1,3", JSArray, "")



  apInitScenario("creating array wrappers using Array conversion")
  nativearray = new System.Int32[4];  populate(nativearray)

  JSArray = nativearray
  if (JSArray != "2,4,1,3") apLogFailInfo("wrong value", "2,4,1,3", JSArray, "")

  JSArray = Array(nativearray)
  if (JSArray != "2,4,1,3") apLogFailInfo("wrong value", "2,4,1,3", JSArray, "")
  


  apInitScenario("creating array wrappers using typed params")
  nativearray = new System.Int32[4];  populate(nativearray)

  res = test1(nativearray)
  if (res != "2,4,1,3") apLogFailInfo("wrong value", "2,4,1,3", res, "")
  
  res = test2(nativearray)
  if (res != "2,4,1,3") apLogFailInfo("wrong value", "2,4,1,3", res, "")


  apEndTest();

}

arraywrap02();


if(lFailCount >= 0) System.Environment.ExitCode = lFailCount;
else System.Environment.ExitCode = 1;

function apInitTest(stTestName) {
    lFailCount = 0;

    apGlobalObj = new Object();
    apGlobalObj.apGetPlatform = function Funca() { return "Rotor" }
    apGlobalObj.LangHost = function Funcb() { return 1033;}
    apGlobalObj.apGetLangExt = function Funcc(num) { return "EN"; }

    apPlatform = apGlobalObj.apGetPlatform();
    var sVer = "1.0";  //navigator.appVersion.toUpperCase().charAt(navigator.appVersion.toUpperCase().indexOf("MSIE")+5);
    apGlobalObj.apGetHost = function Funcp() { return "Rotor " + sVer; }
    print ("apInitTest: " + stTestName);
}

function apInitScenario(stScenarioName) {print( "\tapInitScenario: " + stScenarioName);}

function apLogFailInfo(stMessage, stExpected, stActual, stBugNum) {
    lFailCount = lFailCount + 1;
    print ("***** FAILED:");
    print ("\t\t" + stMessage);
    print ("\t\tExpected: " + stExpected);
    print ("\t\tActual: " + stActual);
}

function apGetLocale(){ return 1033; }
function apWriteDebug(s) { print("dbg ---> " + s) }
function apEndTest() {}
