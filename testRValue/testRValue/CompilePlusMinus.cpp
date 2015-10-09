#include "CompilePlusMinus.h"

#include "CompileMultiply.h"

CompilePlusMinus::CompilePlusMinus()
    : CompileOperator( new CompileMultiply )
{
    TokenMap   &cTokenMap   = getTokenMap();

    cTokenMap[Token::PLUS]  = "$+";
    cTokenMap[Token::MINUS] = "$-";
}
