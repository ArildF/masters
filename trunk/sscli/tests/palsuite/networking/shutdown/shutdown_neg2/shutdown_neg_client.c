/*=============================================================
**
** Source: shutdown_neg_client.c
**
** Purpose: Negatively test the shutdown API to disable the read of
**          a stream socket before calling WSAStartup or after
**          calling WSACleanup.
**          This is a client routine. This client routine must be 
**          be started after the related server is started.
**          This test case is for stream socket.
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
**============================================================*/
#include <palsuite.h>



int __cdecl main(int argc, char *argv[])
{
    WORD VersionRequested = MAKEWORD(2, 2);
    WSADATA WsaData;
    int err;
    int socketID;
    struct sockaddr_in mySockaddr;

    /*Initialize the PAL environment*/
    err = PAL_Initialize(argc, argv);
    if(0 != err)
    {
        return FAIL;
    }

    /*to disable the read of a stream socket*/
    /*before calling the WSAStartup*/
    err = shutdown(socketID, SD_RECEIVE);
    /*only check WSANOTINITIALSED error code*/
    if(WSANOTINITIALISED != GetLastError() || SOCKET_ERROR != err)
    {
        Fail("\nFailed to call shutdown API for a negative test, "
                "Call shutdown API before calling WSAStartup,"
                "an error is expected, but no error or no expected error "
                "is detected, error code=%u\n", GetLastError());    
    }

    /*initialize to use winsock2.dll*/
    err = WSAStartup(VersionRequested, &WsaData);
    if(err != 0)
    {
        Fail("\nFailed to find a usable WinSock DLL!\n");
    }

    /* Confirm that the WinSock DLL supports 2.2.*/
    if(LOBYTE( WsaData.wVersion ) != 2 ||
            HIBYTE( WsaData.wVersion ) != 2)
    {
        Trace("\nFailed to find a usable WinSock DLL!\n");
        err = WSACleanup();
        if(SOCKET_ERROR == err)
        {
            Trace("\nFailed to call WSACleanup API!\n");
        }
        Fail("");
    }

    /*create a stream socket in AF_INET domain*/
    socketID = socket(AF_INET, SOCK_STREAM, 0);
    if(INVALID_SOCKET == socketID)
    {
        Trace("\nFailed to call socket API to create a stream socket!\n");
        err = WSACleanup();
        if(SOCKET_ERROR == err)
        {
            Trace("\nFailed to call WSACleanup API!\n");
        }
        Fail("");
    }

    /*prepare the sockaddr structure*/
    mySockaddr.sin_family = AF_INET;
    mySockaddr.sin_port = getRotorTestPort();
    mySockaddr.sin_addr.S_un.S_addr = inet_addr("127.0.0.1");
    memset( &(mySockaddr.sin_zero), 0, 8);
    /*connect to a stream server*/
    err = connect(socketID,(struct sockaddr *)&mySockaddr,
            sizeof(struct sockaddr));
    if(SOCKET_ERROR == err)
    {
        Trace("\nFailed to call connect API to connect a stream server!\n");
        err = closesocket(socketID);
        if(SOCKET_ERROR == err)
        {    
            Trace("\nFailed to call closesocket API!\n");
        }
        err = WSACleanup();
        if(SOCKET_ERROR == err)
        {
            Trace("\nFailed to call WSACleanup API!\n");
        }
        Fail("");
    }

    /*terminate the use of WinSock DLL*/
    /*and let shutdown generate error*/
    err = WSACleanup();
    if(SOCKET_ERROR == err)
    {
        Fail("\nFailed to call WSACleanup API!\n");
    }

    /*to disable the read of a connected stream socket*/
    /*after calling the WSACleanup*/
    err = shutdown(socketID, SD_RECEIVE);
    /*only check WSANOTINITIALSED error code*/
    if(WSANOTINITIALISED != GetLastError() || SOCKET_ERROR != err)
    {
        Fail("\nFailed to call shutdown API for a negative test, "
                "Call shutdown API after calling WSACleanup,"
                "an error is expected, but no error or no expected error "
                "is detected, error code=%u\n", GetLastError());    
    }

    PAL_Terminate();
    return PASS;
}
