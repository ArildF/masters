/*============================================================
**
** Source: test1.c
**
** Purpose: Tests that FlushInstructionCache returns the correct value for a 
**          number of different inputs.
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
** Note :
** For this function, what constitutes "invalid parameters" will depend entirely
** on the platform; because of this we can't simply test values on Windows and 
** then ask for the same results everywhere. Because of this, this test can 
** ensure that the function succeeds for some "obviously" valid values, but 
** can't make sure that it fails for invalid values.
**
**=========================================================*/

#include <palsuite.h>

void DoTest(void *Buffer, int Size, int Expected)
{
    int ret;
    
    SetLastError(0);
    ret = FlushInstructionCache(GetCurrentProcess(), Buffer, Size);
    if (!ret && Expected)
    {
        Fail("Expected FlushInstructionCache to return non-zero, got zero!\n"
            "region: %p, size: %d, GetLastError: %d\n", Buffer, Size, 
            GetLastError());
    }
    else if (ret && !Expected)
    {
        Fail("Expected FlushInstructionCache to return zero, got non-zero!\n"
            "region: %p, size: %d, GetLastError: %d\n", Buffer, Size, 
            GetLastError());
    }

    if (!Expected && ERROR_NOACCESS != GetLastError())
    {
        Fail("FlushInstructionCache failed to set the last error to "
            "ERROR_NOACCESS!\n");
    }

}

int __cdecl main(int argc,char *argv[]) 
{
    char ValidPtr[256];

    if(PAL_Initialize(argc, argv))
    {
        return FAIL;
    }

    /* with valid pointer, zero-size and valid size must succeed */
    DoTest(ValidPtr, 0, 1);
    DoTest(ValidPtr, 42, 1);

    PAL_Terminate();
    return PASS;
}
