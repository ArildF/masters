/*============================================================
**
** Source : test.c
**
** Purpose: Test for FormatMessageW() function
**
** 
**  Copyright (c) 2002 Microsoft Corporation.  All rights reserved.
** 
**  The use and distribution terms for this software are contained in the file
**  named license.txt, which can be found in the root of this distribution.
**  By using this software in any fashion, you are agreeing to be bound by the
**  terms of this license.
** 
**  You must not remove this notice, or any other, from this software.
** 
**
**=========================================================*/

#define UNICODE
#include <palsuite.h>

WCHAR OutBuffer[1024];

int __cdecl main(int argc, char *argv[]) 
{
    
    WCHAR *  TheString;
    WCHAR* TheArray[3];
    int ReturnResult;

    /*
     * Initialize the PAL and return FAILURE if this fails
     */

    if(0 != (PAL_Initialize(argc, argv)))
    {
        return FAIL;
    }

    TheString = convert("Pal %1 %2 %3 Testing");
    TheArray[0] = convert("Foo");
    TheArray[1] = convert("Bar");
    TheArray[2] = convert("FooBar");

    /* This should just use the 3 strings in the array to replace
       inserts in the given string.
    */

    ReturnResult = FormatMessage(
        FORMAT_MESSAGE_FROM_STRING | 
        FORMAT_MESSAGE_ARGUMENT_ARRAY,      /* source and processing options */
        TheString,                       /* message source */
        0,                               /* message identifier */
        0,                               /* language identifier */
        OutBuffer,                       /* message buffer */
        1024,                            /* maximum size of message buffer */
        TheArray                             /* array of message inserts */
        );
  
    if(ReturnResult == 0) 
    {
        Fail("ERROR: The return value was 0, which indicates failure.  "
             "The function failed when trying to Format a simple string, "
             "usin gthe ARGUMENT_ARRAY flag.");
    }
  
    if(memcmp(OutBuffer,
              convert("Pal Foo Bar FooBar Testing"),
              wcslen(OutBuffer)*2+2) != 0) 
    {
        Fail("ERROR:  Since the FORMAT_MESSAGE_ARGUMENT_ARRAY flag was set, "
             "the result should have been 'Pal Foo Bar FooBar Testing' but was"
             " really '%s'.",convertC(OutBuffer));
    }
  
    
    PAL_Terminate();
    return PASS;
 
}


