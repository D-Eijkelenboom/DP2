#include "CompileOperator.h"

#include "FunctionCall.h"
#include "DirectFunctionCall.h"

#define szGetFromReturnValue    "getFromReturnValue"

CompileOperator::CompileOperator( Compiler* pNextLevel )
    : m_pNextLevel( pNextLevel )
{
}

CompileOperator::~CompileOperator()
{
    delete m_pNextLevel;
}

void
CompileOperator::compile( const TokenList& cTokenList
                        , TokenIterator&   iBegin
                        , TokenIterator&   iEnd
                        , RunList&         cRunList
                        , RunIterator&     iBefore )
{
    TokenIterator           iCurrent        = iBegin;
    TokenMap::iterator      iFind;
    RunIterator             iaBefore[2];
    CompileNextLevel        cNextLevel;
    CompileNextLevelList    cNextLevelList;

    cNextLevel.iBegin   = iBegin;

    while ( iCurrent != iEnd )
    {
        if ( (*iCurrent)->getPartner() != NULL )
            iCurrent    = *(*iCurrent)->getPartner();

        iFind   = m_nTokenMap.find( (*iCurrent)->getEnum() );

        if ( iFind != m_nTokenMap.end() )
        {
            fillRunlist( iFind->second, cRunList, iBefore, iaBefore );

            fillNextLevelList( iaBefore, iCurrent, cNextLevel, cNextLevelList );
        }
        else
            ++iCurrent;
    }

    insertLastNextLevel( iEnd, iBefore, cNextLevel, cNextLevelList );

    compileNextLevel( cTokenList, cRunList, cNextLevelList );
}

CompileOperator::TokenIterator
CompileOperator::getLastToken( const TokenList& cTokenList
                             , TokenIterator&   iCurrent )
{
    TokenIterator  iResult  = iCurrent;

    while ( iResult != cTokenList.end() && (*iResult)->getEnum() != Token::SEMICOLON )
        ++iResult;

    return iResult;
}

CompileOperator::TokenMap&
CompileOperator::getTokenMap()
{
    return m_nTokenMap;
}

void
CompileOperator::fillRunlist( const std::string& sFunctionName
                            , RunList&           cRunList
                            , RunIterator&       iBefore
                            , RunIterator*       iaBefore )
{
    std::string             saArguments[3];
    std::string             sBuffer;
    FunctionCall           *pFunction       = NULL;
    DirectFunctionCall     *pDirectFunction = NULL;
    int                     n;

    saArguments[0]  = sFunctionName;
    saArguments[1]  = getNextLocalVariableName( sBuffer );
    saArguments[2]  = getNextLocalVariableName( sBuffer );

    for ( n=0; n<2; n++ )
    {
        pDirectFunction = new DirectFunctionCall;
        pDirectFunction->setArraySize( 2 );
        pDirectFunction->setAt( 0, szGetFromReturnValue );
        pDirectFunction->setAt( 1, saArguments[n+1].c_str() );
        iaBefore[n]     = cRunList.insert( iBefore, pDirectFunction );
    }

    pFunction = new FunctionCall;
    pFunction->setArraySize( 3 );
    for ( n=0; n<3; n++ )
        pFunction->setAt( n, saArguments[n].c_str() );
    cRunList.insert( iBefore, pFunction );
}

void
CompileOperator::fillNextLevelList( RunIterator*          iaBefore
                                  , TokenIterator&        iCurrent
                                  , CompileNextLevel&     cNextLevel
                                  , CompileNextLevelList& cNextLevelList )
{
    if ( cNextLevelList.size() == 0 )
        cNextLevel.iBefore  = iaBefore[0];

    cNextLevel.iEnd     = iCurrent;

    cNextLevelList.push_back( cNextLevel );

    ++iCurrent;

    cNextLevel.iBefore  = iaBefore[1];
    cNextLevel.iBegin   = iCurrent;
}

void
CompileOperator::insertLastNextLevel( TokenIterator&        iEnd
                                    , RunIterator&          iBefore
                                    , CompileNextLevel&     cNextLevel
                                    , CompileNextLevelList& cNextLevelList )
{
    if ( cNextLevelList.size() == 0 )
        cNextLevel.iBefore  = iBefore;

    cNextLevel.iEnd     = iEnd;

    cNextLevelList.push_back( cNextLevel );
}

void
CompileOperator::compileNextLevel( const TokenList&      cTokenList
                                 , RunList&              cRunList
                                 , CompileNextLevelList& cNextLevelList )
{
    CompileNextLevelList::iterator  iStep   = cNextLevelList.begin();

    while ( iStep != cNextLevelList.end() )
    {
        CompileNextLevel   &cNextLevelList  = *iStep;

        m_pNextLevel->compile( cTokenList
                             , cNextLevelList.iBegin
                             , cNextLevelList.iEnd
                             , cRunList
                             , cNextLevelList.iBefore );
        ++iStep;
    }
}
