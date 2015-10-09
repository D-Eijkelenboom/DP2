using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler
{
    enum TokenType
    {
        WHILE,
        FOR,
        IF,
        ELSE,
        ELSEIF,
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
        NUMBER,
        IDENTIFIER
    }
}
