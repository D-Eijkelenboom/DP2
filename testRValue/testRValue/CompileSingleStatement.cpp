#include "CompileSingleStatement.h"

#include "FunctionCall.h"
#include "DirectFunctionCall.h"

#include "CompileCondition.h"

#define szIdentifierToReturnValue   "IdentifierToReturnValue"
#define szConstantToReturnValue     "ConstantToReturnValue"
#define szGetFromReturnValue        "getFromReturnValue"

void
CompileSingleStatement::compile( const TokenList& cTokenList
                               , TokenIterator&   iBegin
                               , TokenIterator&   iEnd
                               , RunList&         cRunList
                               , RunIterator&     iBefore )
{
    switch ( (*iBegin)->getEnum() )
    {
    case Token::IDENTIFIER:
        {
            TokenIterator       iNext           = iBegin,
                                iBeginCondition;
            FunctionCall       *pFunction       = NULL;
            DirectFunctionCall *pDirectFunction = NULL;
            RunIterator         iBeforeArgument;
            std::string         saArguments[2],
                                sBuffer;

            ++iNext;

            //  a function has only one argument.
            if ( iNext != cTokenList.end() && (*iNext)->getEnum() == Token::CONDITION_OPEN )
            {
                saArguments[0]  = (*iBegin)->getText();
                saArguments[1]  = getNextLocalVariableName( sBuffer );

                pDirectFunction = new DirectFunctionCall;
                pDirectFunction->setArraySize( 2 );
                pDirectFunction->setAt( 0, szGetFromReturnValue );
                pDirectFunction->setAt( 1, saArguments[1].c_str() );
                iBeforeArgument = cRunList.insert( iBefore, pDirectFunction );

                pFunction = new FunctionCall;
                pFunction->setArraySize( 2 );
                pFunction->setAt( 0, saArguments[0].c_str() );
                pFunction->setAt( 1, saArguments[1].c_str() );
                                  cRunList.insert( iBefore, pFunction );

                CompileCondition    cCondition;

                iBeginCondition = iNext;
                ++iBeginCondition;
                cCondition.compile( cTokenList
                                  , iBeginCondition
                                  , *(*iNext)->getPartner()
                                  , cRunList
                                  , iBeforeArgument );
            }
            else
            {
                DirectFunctionCall *pFunction       = NULL;

                saArguments[0]  = szIdentifierToReturnValue;
                saArguments[1]  = (*iBegin)->getText();

                pFunction = new DirectFunctionCall;
                pFunction->setArraySize( 2 );
                pFunction->setAt( 0, saArguments[0].c_str() );
                pFunction->setAt( 1, saArguments[1].c_str() );
                                    cRunList.insert( iBefore, pFunction );
            }
        }
        break;
    case Token::NUMBER:
        {
            DirectFunctionCall *pFunction       = NULL;
            std::string         saArguments[2];

            saArguments[0]  = szConstantToReturnValue;
            saArguments[1]  = (*iBegin)->getText();

            pFunction = new DirectFunctionCall;
            pFunction->setArraySize( 2 );
            pFunction->setAt( 0, saArguments[0].c_str() );
            pFunction->setAt( 1, saArguments[1].c_str() );
                                cRunList.insert( iBefore, pFunction );
        }
        break;
    case Token::CONDITION_OPEN:
        {
            TokenIterator       iNext           = iBegin;
            CompileCondition    cCondition;
            ++iNext;

            cCondition.compile( cTokenList
                              , iNext
                              , *(*iBegin)->getPartner()
                              , cRunList
                              , iBefore );
        }
        break;
    }
}
