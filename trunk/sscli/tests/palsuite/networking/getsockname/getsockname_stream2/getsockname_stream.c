/*=============================================================
**
** Source: getsockname_stream.c
**
** Purpose: Positive test the getsockname function to retrieve 
**          the local name for a bound stream socket 
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
    WORD VersionRequested = MAKEWORD(2,2);
    WSADATA WsaData;
    int err;
    int socketID;
    struct sockaddr_in mySockaddr;
    int size;
    struct sockaddr_in OutSockaddr_in;

    /*Initialize the PAL environment*/
    err = PAL_Initialize(argc, argv);
    if(0 != err)
    {
        return FAIL;
    }

    /*initialize to use winsock2.dll*/
    err = WSAStartup(VersionRequested,&WsaData);

    if(err != 0)
    {
        Fail("\nFailed to find a usable WinSock DLL!, error code=%d\n",
                GetLastError());
    }

    /*Confirm that the WinSock DLL supports 2.2.*/
    if(LOBYTE( WsaData.wVersion ) != 2 ||
            HIBYTE( WsaData.wVersion ) != 2)
    {
        Trace("\nFailed to find a usable WinSock DLL!, error code=%d\n",
                GetLastError());
        err = WSACleanup();
        if(SOCKET_ERROR == err)
        {
            Trace("\nFailed to call WSACleanup API!, error code=%d\n",
                GetLastError());
        }
        Fail("");
    }

    /*
    here the AF_INET is the same as PF_INET
    create a stream socket in AF_INET domain
    */
    socketID = socket(AF_INET,SOCK_STREAM,0);

    if(INVALID_SOCKET == socketID)
    {
        Trace("\nFailed to call socket API to create a "
            "stream socket!, the error code=%d\n", GetLastError());
        err = WSACleanup();
        if(SOCKET_ERROR == err)
        {
            Trace("\nFailed to call WSACleanup API!, error code=%d\n",
                GetLastError());
        }
        Fail("");
    }

    /*prepare the sockaddr_in structure*/
    mySockaddr.sin_family = AF_INET;
    mySockaddr.sin_port = getRotorTestPort();
    mySockaddr.sin_addr.S_un.S_addr = inet_addr("127.0.0.1");
    memset( &(mySockaddr.sin_zero), 0, 8);

    /*bind the local address to the created socket*/
    err = bind(socketID, (struct sockaddr *)&mySockaddr,
            sizeof(struct sockaddr));
    if(SOCKET_ERROR == err)
    {
        Trace("\nFailed to call bind API to bind the stream socket "
                "local address!, error code=%d\n", GetLastError());
        err = closesocket(socketID);
        if(SOCKET_ERROR == err)
        {    
            Trace("\nFailed to call closesocket API!, error code=%d\n",
                GetLastError());
        }
        err = WSACleanup();
        if(SOCKET_ERROR == err)
        {
            Trace("\nFailed to call WSACleanup API!, error code=%d\n",
                GetLastError());
        }
        Fail("");
    }


    size = sizeof(struct sockaddr);

    /*retrieve the local name for the socket */
    err = getsockname(socketID, (struct sockaddr *)&OutSockaddr_in, &size);
    if(SOCKET_ERROR == err)
    {
        Trace("\nFailed to call getsockname API to "
            "retrieve socket name!, error code=%d\n", GetLastError());
        err = closesocket(socketID);
        if(SOCKET_ERROR == err)
        {    
            Trace("\nFailed to call closesocket API!, error code=%d\n",
                GetLastError());
        }
        err = WSACleanup();
        if(SOCKET_ERROR == err)
        {
            Trace("\nFailed to call WSACleanup API!, error code=%d\n",
                GetLastError());
        }
        Fail("");
    }

    /*further check if the returned sockaddr_in struct contains valid value*/
    if(OutSockaddr_in.sin_addr.S_un.S_addr != inet_addr("127.0.0.1"))
    {
        Trace("\nFailed to call getsockname to retrieve the local host info, "
                    "the retrieved sockaddr_in struct dose not contain correct"
                    " local IP address\n");

        err = closesocket(socketID);
        if(SOCKET_ERROR == err)
        {
            Trace("\nFailed to call closesocket API!, error code=%d\n",
                    GetLastError());
        }
        err = WSACleanup();
        if(SOCKET_ERROR == err)
        {
            Trace("\nFailed to call WSACleanup API!, error code=%d\n",
                GetLastError());
        }
        Fail("");
    }
    err = closesocket(socketID);
    if(SOCKET_ERROR == err)
    {
        Trace("\nFailed to call closesocket API!, error code=%d\n",
                GetLastError());
    }

    err = WSACleanup();
    if(SOCKET_ERROR == err)
    {
        Fail("\nFailed to call WSACleanup API!, error code=%d\n",
                GetLastError());
    }

    PAL_Terminate();
    return PASS;
}
