/*============================================================================
**
** Source:  test1.c
**
** Purpose:
** Concatenate three strings into one string.  Each time, check to ensure 
** the pointer returned was what we expected.  When finished, compare the 
** newly formed string to what it should be to ensure no characters were 
** lost.
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
**==========================================================================*/

#include <palsuite.h>


int __cdecl main(int argc, char *argv[])
{
    char dest[80];
    char *test = "foo bar baz";
    char *str1 = "foo ";
    char *str2 = "bar ";
    char *str3 = "baz";
    char *ptr;

    
    if (PAL_Initialize(argc, argv))
    {
        return FAIL;
    }


    dest[0] = 0;

    ptr = strcat(dest, str1);
    if (ptr != dest)
    {
        Fail("ERROR: Expected strcat to return ptr to %p, got %p", dest, ptr);
    }

    ptr = strcat(dest, str2);
    if (ptr != dest)
    {
        Fail("ERROR: Expected strcat to return ptr to %p, got %p", dest, ptr);
    }

    ptr = strcat(dest, str3);
    if (ptr != dest)
    {
        Fail("ERROR: Expected strcat to return ptr to %p, got %p", dest, ptr);
    }

    if (strcmp(dest, test) != 0)
    {
        Fail("ERROR: Expected strcat to give \"%s\", got \"%s\"\n", 
            test, dest);
    }

    PAL_Terminate();

    return PASS;
}
