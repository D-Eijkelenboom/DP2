﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler
{
    public enum TokenType
    {
        PRINT,
        WHILE,
        FOR,
        IF,
        ELSE,
        BRACKETOPEN,
        BRACKETCLOSE,
        ELIPSISOPEN,
        ELIPSISCLOSE,
        SEMICOLON,
        EQUALS,
        COMPARE,
        LESSEREQUALS,
        GREATEREQUALS,
        NOTEQUALS,
        MINUS,
        PLUS,
        MULTIPLY,
        DIVIDE,
        INCREMENT,
        DECREMENT,
        NUMBER,
        IDENTIFIER
    }
}
