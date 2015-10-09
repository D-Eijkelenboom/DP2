#include "CompileMultiply.h"

#include "CompileSingleStatement.h"

CompileMultiply::CompileMultiply()
    : CompileOperator( new CompileSingleStatement )
{
    TokenMap   &cTokenMap   = getTokenMap();

    cTokenMap[Token::TIMES]     = "$*";
    cTokenMap[Token::DIVIDE]    = "$/";
}
