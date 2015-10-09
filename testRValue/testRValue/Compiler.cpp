#include "Compiler.h"

#include <sstream>

Compiler::Compiler()
{
}

Compiler::~Compiler()
{
}

Compiler::TokenIterator
Compiler::getLastToken( const TokenList& cTokenList
                      , TokenIterator&   cCurrent )
{
    return cCurrent;
}

std::string
Compiler::getNextLocalVariableName( std::string& sBuffer )
{
    static  int         nValue  = 0;
    std::stringstream   sStream;

    sStream << " " << ++nValue;

    sBuffer = sStream.str();

    return sBuffer;
}
