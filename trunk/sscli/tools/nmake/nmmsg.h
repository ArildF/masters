// ==++==
//
//   
//    Copyright (c) 2002 Microsoft Corporation.  All rights reserved.
//   
//    The use and distribution terms for this software are contained in the file
//    named license.txt, which can be found in the root of this distribution.
//    By using this software in any fashion, you are agreeing to be bound by the
//    terms of this license.
//   
//    You must not remove this notice, or any other, from this software.
//   
//
// ==--==
// File nmmsg.h created by mkmsg.bat from source nmmsg.us 
#define SYNTAX_NO_PAREN 1000 
#define SYNTAX_BAD_CHAR 1001 
#define SYNTAX_ONE_DOLLAR 1002 
#define SYNTAX_NO_EQUALS 1003 
#define SYNTAX_NO_MACRO_NAME 1004 
#define SYNTAX_NO_SEQUENCE 1005 
#define SYNTAX_NO_QUOTE 1006 
#define SYNTAX_QUOTE_UNEXPECTED 1007 
#define SYNTAX_BAD_DIRECTIVE 1017 
#define SYNTAX_MISSING_DIRECTIVE 1018 
#define SYNTAX_TOO_MANY_IFS 1019 
#define SYNTAX_EOF_NO_DIRECTIVE 1020 
#define SYNTAX_UNEXPECTED_ELSE 1021 
#define SYNTAX_MISSING_END_CHAR 1022 
#define SYNTAX_INVALID_EXPR 1023 
#define SYNTAX_BAD_CMDSWITCHES 1024 
#define SYNTAX_UNEXPECTED_ENDIF 1025 
#define SYNTAX_NO_NAME 1031 
#define SYNTAX_UNEXPECTED_TOKEN 1033 
#define SYNTAX_NO_SEPARATOR 1034 
#define SYNTAX_NO_SEP_OR_EQUALS 1035 
#define SYNTAX_TOO_MANY_NAMES 1036 
#define SYNTAX_NO_TARGET_NAME 1037 
#define LEXER_INTERNAL 1038 
#define PARSER_INTERNAL 1039 
#define MACRO_INTERNAL 1040 
#define BUILD_INTERNAL 1041 
#define EXPR_TOO_LONG_INTERNAL 1042 
#define TOO_MANY_TMP_FILES_INTERNAL 1043 
#define SPAWN_FAILED_ERROR 1045 
#define OUT_OF_SEARCH_HANDLES 1046 
#define MISSING_ARG_BEFORE_PAREN 1047 
#define CANT_WRITE_FILE 1048 
#define MACRO_TOO_LONG 1049 
#define USER_CONTROLLED 1050 
#define OUT_OF_MEMORY 1051 
#define CANT_OPEN_FILE 1052 
#define CANT_READ_FILE 1053 
#define CANT_MAKE_INLINE 1054 
#define OUT_OF_ENV_SPACE 1055 
#define NO_COMMAND_COM 1056 
#define BAD_UNLINK 1057 
#define USER_INTERRUPT 1058 
#define MISSING_CLOSING_BRACE 1059 
#define ERROR_CLOSING_FILE 1060 
#define CMDLINE_F_NO_FILENAME 1061 
#define CMDLINE_X_NO_FILENAME 1062 
#define CMDLINE_NO_MACRONAME 1063 
#define CMDLINE_NO_MAKEFILE 1064 
#define CMDLINE_BAD_OPTION 1065 
#define NO_WILDCARD_MATCH 1069 
#define CYCLE_IN_MACRODEF 1070 
#define CYCLE_IN_TREE 1071 
#define CYCLE_IN_INCLUDES 1072 
#define CANT_MAKE_TARGET 1073 
#define NAME_TOO_LONG 1076 
#define BAD_RETURN_CODE 1077 
#define CONST_TOO_BIG 1078 
#define DIVIDE_BY_ZERO 1079 
#define BAD_OP_TYPES 1080 
#define CANT_FIND_PROGRAM 1081 
#define EXEC_NO_MEM 1082 
#define TARGET_MACRO_IS_NULL 1083 
#define CANT_CREATE_TEMP 1084 
#define MIXED_RULES 1085 
#define DEPENDENTS_ON_RULE 1086 
#define MIXED_SEPARATORS 1087 
#define BAD_SEPARATOR 1088 
#define CMDS_ON_PSEUDO 1089 
#define DEPS_ON_PSEUDO 1090 
#define TOO_MANY_RULE_NAMES 1092 
#define MIXED_TARGETS 1093 
#define SYNTAX_KEEP_INLINE_FILE 1094 
#define COMMAND_TOO_LONG 1095 
#define EXTMAKE_CANNOT_OPEN 1096 
#define EXTMAKE_NO_FILENAME 1097 
#define EXTMAKE_BAD_SYNTAX 1098 
#define BAD_BATCH_MACRO 1100 
#define CANT_SUPPORT_UNICODE 1101 
#define OUT_OF_HANDLES 2001 
#define SYNTAX_CMDFILE 4001 
#define RESETTING_MACRO 4002 
#define TOO_MANY_RULES 4004 
#define IGNORING_RULE 4005 
#define ILLEGAL_SPECIAL_MACRO 4006 
#define TRUNCATING_FILENAME 4007 
#define REMOVED_TARGET 4008 
#define BUILD_FAILED_SLASH_K 4010 
#define TARGET_ERROR_IN_CHILD 4011 
#define FILE_DOESNT_EXIST 1 
#define TARGET_UP_TO_DATE 2 
#define UPDATE_INFO 3 
#define TIME_FORMAT 4 
#define TOUCHING_TARGET 5 
#define TARGET_DOESNT_EXIST 6 
#define INFERENCE_MESSAGE 7 
#define MACROS_MESSAGE 8 
#define TARGETS_MESSAGE 9 
#define COMMANDS_MESSAGE 10 
#define FLAGS_MESSAGE 11 
#define DEPENDENTS_MESSAGE 12 
#define USER_MESSAGE 13 
#define MACRO_DEFINITION 14 
#define MSG_IDE_BUILD 15 
#define FATAL_ERROR_MESSAGE 20 
#define ERROR_MESSAGE 21 
#define WARNING_MESSAGE 22 
#define STOP_MESSAGE 23 
#define COPYRIGHT_MESSAGE_1 24 
#define COPYRIGHT_MESSAGE_2 25 
#define MESG_FIRST 100 
#define MESG_USAGE 101 
#define MESG_WHERE 102 
#define MESG_A 103 
#define MESG_B 104 
#define MESG_C 105 
#define MESG_D 106 
#define MESG_E 107 
#define MESG_HELP 108 
#define MESG_I 109 
#define MESG_K 110 
#define MESG_M 111 
#define MESG_N 112 
#define MESG_L 113 
#define MESG_P 114 
#define MESG_Q 115 
#define MESG_R 116 
#define MESG_S 117 
#define MESG_T 118 
#define MESG_V 119 
#define MESG_U 120 
#define MESG_Y 121 
#define MESG_LAST 122 
#define MESG_OPTIONS 125 
