#include "CompileCondition.h"

#include "CompilePlusMinus.h"

CompileCondition::CompileCondition()
    : CompileOperator( new CompilePlusMinus )
{
    TokenMap   &cTokenMap   = getTokenMap();

    cTokenMap[Token::LESS_THAN]     = "$<";
    cTokenMap[Token::LARGER_THAN]   = "$>";
}

CompileCondition::TokenIterator
CompileCondition::getLastToken( const TokenList& cTokenList
                              , TokenIterator&   iCurrent )
{
    if ( (*iCurrent)->getEnum() == Token::CONDITION_OPEN )
        return *(*iCurrent)->getPartner();
    else
        return iCurrent;
}
