/*============================================================================
**
** Source:  test4.c
**
** Purpose: Test #4 for the wcstoul function
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

/*
 * Notes: wcstoul should depend on the current locale's LC_NUMERIC category, 
 * this is not currently tested.
 */

int __cdecl main(int argc, char *argv[])
{
    WCHAR maxstr[] = {'4','2','9','4','9','6','7','2','9','5',0};
    unsigned long max =    4294967295ul;
    WCHAR *end;
    unsigned long l;

    if (0 != PAL_Initialize(argc, argv))
    {
        return FAIL;
    }


    errno = 0;

    l = wcstoul(maxstr, &end, 10);
    if (l != max)
    {
        Fail("ERROR: Expected wcstoul to return %d, got %d\n", max, l);
    }
    if (end != maxstr + 10)
    {
        Fail("ERROR: Expected wcstoul to give an end value of %p, got %p\n",
            maxstr + 10, end);
    }
    if (errno != 0)
    {
        Fail("ERROR: wcstoul set errno to non-zero (%d)\n", errno);
    }

    PAL_Terminate();
    return PASS;
}
