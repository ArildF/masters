/*=====================================================================
**
** Source:    test2.c (DuplicateHandle)
**
** Purpose:   Tests the PAL implementation of the DuplicateHandle function.
**            This will test duplication of an CreateEvent handle. Test an
**            event in a signaled state to wait, and then set the duplicate
**            to nonsignaled state and perform the wait again. The wait on
**            the event should fail. Test the duplication of closed and NULL
**            events, these should fail.  
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

int __cdecl main(int argc, char **argv)
{
    HANDLE hEvent;
    HANDLE hDupEvent;

    /*Initalize the PAL.*/
    if ((PAL_Initialize(argc,argv)) != 0)
    {
        return (FAIL);
    }

    /*Create an Event, and set it in the signaled state.*/
    hEvent = CreateEvent(0, TRUE, TRUE, 0);
    if (hEvent == NULL)
    {
        Fail("ERROR: %u :unable to create event\n", 
             GetLastError());
    }

    /*Create a duplicate Event handle.*/
    if (!(DuplicateHandle(GetCurrentProcess(),
                          hEvent,GetCurrentProcess(),
                          &hDupEvent,
                          GENERIC_READ|GENERIC_WRITE,
                          FALSE, DUPLICATE_SAME_ACCESS)))
    {
        Trace("ERROR: %u :Fail to create the duplicate handle"
                " to hEvent=0x%lx\n",
                GetLastError(),
                hEvent);
        CloseHandle(hEvent);
        Fail("");
    }

    /*Perform wait on Event that is in signaled state.*/
    if ((WaitForSingleObject(hEvent, 1000)) != WAIT_OBJECT_0)
    {
        Trace("ERROR: %u :WaitForSignalObject on Event=0x%lx set to "
                " signaled state failed",
                GetLastError(),
                hEvent);
        CloseHandle(hEvent);
        CloseHandle(hDupEvent);
        Fail("");
    }

    /*Set the Duplicate Event handle to nonsignaled state.*/
    if ((ResetEvent(hDupEvent)) == 0)
    {
        Trace("ERROR: %u :unable to reset dup event\n",
              GetLastError());
        CloseHandle(hEvent);
        CloseHandle(hDupEvent);
        Fail("");
    }

    /*Perform wait on Event that is in signaled state.*/
    if ((WaitForSingleObject(hEvent, 1000)) == WAIT_OBJECT_0)
    {
        Trace("ERROR: %u: WaitForSignalObject succeeded on Event=0x%lx "
                    " when Duplicate Event=0x%lx set to nonsignaled state"
                    " succeeded\n",
                    GetLastError(),
                    hEvent,
                    hDupEvent);
        CloseHandle(hEvent);
        CloseHandle(hDupEvent);
        Fail("");
    }

    /*Close handles to events.*/
    CloseHandle(hEvent);
    CloseHandle(hDupEvent);

    PAL_Terminate();
    return (PASS);
}
