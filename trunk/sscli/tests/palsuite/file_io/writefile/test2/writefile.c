/*=====================================================================
**
** Source:  WriteFile.c (test 2)
**
** Purpose: Tests the PAL implementation of the WriteFile function.
**          Creates a number of files and writes different amounts of
**          data and verifies the writes.
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
**===================================================================*/


#include <palsuite.h>


char* writeBuffer;
const char* szWritableFile = "Writeable.txt";
const char* szResultsFile = "Results.txt";
const int PAGESIZE = 4096;

BOOL writeTest(DWORD dwByteCount, DWORD dwBytesWrittenResult, BOOL bResult)
{
    HANDLE hFile = NULL;
    DWORD dwBytesWritten;
    BOOL bRc = FALSE;

    /* create the test file */
    DeleteFile(szWritableFile);
    hFile = CreateFile(szWritableFile, GENERIC_WRITE, FILE_SHARE_WRITE,    
                       NULL, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, NULL);

    if(hFile == INVALID_HANDLE_VALUE)
    {
        Trace("WriteFile: ERROR -> Unable to create file \"%s\".\n", 
            szWritableFile);
        return FALSE;
    }
    
    bRc = WriteFile(hFile, writeBuffer, dwByteCount, &dwBytesWritten, NULL);
    CloseHandle(hFile);

    if ((bRc != bResult) || (dwBytesWrittenResult != dwBytesWritten))
    {
        Trace("WriteFile returned BOOL:%d and dwWritten:%d what we do expect is"
              " BOOL:%d and dwWritten:%d\n", bRc, dwBytesWritten, bResult, 
              dwBytesWrittenResult);
        return FALSE;
    }

    return TRUE;
}

int __cdecl main(int argc, char *argv[])
{
    const char * testString = "The quick fox jumped over the lazy dog's back.";
    const int testStringLen = strlen(testString);
    
    DWORD dwByteCount[4] =   {-1,    10,   testStringLen, 0};
    DWORD dwByteWritten[4] = {0,     10,   testStringLen, 0};
    BOOL bResults[] =        {FALSE, TRUE, TRUE,          TRUE};
    
    const int BUFFER_SIZE = 2 * PAGESIZE;
    int j;
    BOOL bRc = FALSE;
    DWORD oldProt;

    if (0 != PAL_Initialize(argc,argv))
    {
        return FAIL;
    }

    /* allocate read-write memery for writeBuffer */
    if (!(writeBuffer = (char*) VirtualAlloc(NULL, BUFFER_SIZE, MEM_COMMIT, 
                                             PAGE_READWRITE)))
	{
		Fail("VirtualAlloc failed: GetLastError returns %d\n", GetLastError());
		return FAIL;
	}
	
    memset((void*) writeBuffer, '.', BUFFER_SIZE);
    strcpy(writeBuffer, testString);
    
    /* write protect the second page of writeBuffer */
	if (!VirtualProtect(&writeBuffer[PAGESIZE], PAGESIZE, PAGE_NOACCESS, &oldProt))
	{
		Fail("VirtualProtect failed: GetLastError returns %d\n", GetLastError());
		return FAIL;
	}
    
    for (j = 0; j< 4; j++)
    {
        bRc = writeTest(dwByteCount[j], dwByteWritten[j], bResults[j]);
        if (bRc != TRUE)
        {
            Fail("WriteFile: ERROR -> Failed on test[%d]\n", j);
        }
    }

    PAL_Terminate();
    return PASS;
}
