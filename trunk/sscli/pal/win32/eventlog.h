 /*
    
     Copyright (c) 2002 Microsoft Corporation.  All rights reserved.
    
     The use and distribution terms for this software are contained in the file
     named license.txt, which can be found in the root of this distribution.
     By using this software in any fashion, you are agreeing to be bound by the
     terms of this license.
    
     You must not remove this notice, or any other, from this software.
    

    MODULE: eventlog.mc

    This file contains the message definition the Rotor PAL
 */
//
//  Values are 32 bit values layed out as follows:
//
//   3 3 2 2 2 2 2 2 2 2 2 2 1 1 1 1 1 1 1 1 1 1
//   1 0 9 8 7 6 5 4 3 2 1 0 9 8 7 6 5 4 3 2 1 0 9 8 7 6 5 4 3 2 1 0
//  +---+-+-+-----------------------+-------------------------------+
//  |Sev|C|R|     Facility          |               Code            |
//  +---+-+-+-----------------------+-------------------------------+
//
//  where
//
//      Sev - is the severity code
//
//          00 - Success
//          01 - Informational
//          10 - Warning
//          11 - Error
//
//      C - is the Customer code flag
//
//      R - is a reserved bit
//
//      Facility - is the facility code
//
//      Code - is the facility's status code
//
//
// Define the facility codes
//


//
// Define the severity codes
//


//
// MessageId: MSG_ERROR
//
// MessageText:
//
//  %1
//
#define MSG_ERROR                        0x00000001L

Severity=Error
Facility=Application
//
// MessageId: MSG_WARNING
//
// MessageText:
//
//  %1
//
#define MSG_WARNING                      0x00000002L

Severity=Warning
Facility=Application
//
// MessageId: MSG_INFORMATIONAL
//
// MessageText:
//
//  %1
//
#define MSG_INFORMATIONAL                0x00000004L

Severity=Informational
Facility=Application
