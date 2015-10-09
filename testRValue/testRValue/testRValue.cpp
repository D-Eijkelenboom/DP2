#include "CompileCondition.h"
#include "DoNothing.h"

void createTokenList( Compiler::TokenList& );
void removeTokenList( Compiler::TokenList& );
void printRunList( const Compiler::RunList& );
void removeRunList( Compiler::RunList& );

int main( int, char** )
{
    Compiler::RunList   cRunList;
    Compiler::TokenList cTokenList;

    cRunList.push_back( new DoNothing );

    createTokenList( cTokenList );

    CompileCondition    cCompileCondition;

    cCompileCondition.compile( cTokenList
                             , cTokenList.begin()
                             , cTokenList.end()
                             , cRunList
                             , cRunList.begin() );

    printRunList( cRunList );

    removeRunList( cRunList );
    removeTokenList( cTokenList );

    getchar();

    return 0;
}

void createTokenList( Compiler::TokenList& cTokenList )
{
    printf( "          x + 3 * 8 < y - 2r\n\r\n" );

    // x + 3 * 8 < y - 2
    Token  *pToken;

    pToken = new Token;
    pToken->setText( "x" );
    pToken->setEnum( Token::IDENTIFIER );
    cTokenList.push_back( pToken );

    pToken = new Token;
    pToken->setText( "+" );
    pToken->setEnum( Token::PLUS );
    cTokenList.push_back( pToken );

    pToken = new Token;
    pToken->setText( "3" );
    pToken->setEnum( Token::NUMBER );
    cTokenList.push_back( pToken );

    pToken = new Token;
    pToken->setText( "*" );
    pToken->setEnum( Token::TIMES );
    cTokenList.push_back( pToken );

    pToken = new Token;
    pToken->setText( "8" );
    pToken->setEnum( Token::NUMBER );
    cTokenList.push_back( pToken );

    pToken = new Token;
    pToken->setText( "<" );
    pToken->setEnum( Token::LESS_THAN );
    cTokenList.push_back( pToken );

    pToken = new Token;
    pToken->setText( "y" );
    pToken->setEnum( Token::IDENTIFIER );
    cTokenList.push_back( pToken );

    pToken = new Token;
    pToken->setText( "-" );
    pToken->setEnum( Token::MINUS );
    cTokenList.push_back( pToken );

    pToken = new Token;
    pToken->setText( "2" );
    pToken->setEnum( Token::NUMBER );
    cTokenList.push_back( pToken );
}

void removeTokenList( Compiler::TokenList& cTokenList )
{
    Compiler::TokenIterator iCurrent    = cTokenList.begin(),
                            iDelete;

    while ( iCurrent != cTokenList.end() )
    {
        iDelete = iCurrent;
        ++iCurrent;

        delete *iDelete;
    }

    cTokenList.clear();
}

void printRunList( const Compiler::RunList& cRunList )
{
    Compiler::RunList::const_iterator   iCurrent    = cRunList.begin();
    int                                 teller      = 0;

    while ( iCurrent != cRunList.end() )
    {
        printf( " %3ld ", ++teller );
        (*iCurrent)->show();

        ++iCurrent;
    }
}

void removeRunList( Compiler::RunList& cRunList )
{
    Compiler::RunIterator   iCurrent    = cRunList.begin(),
                            iDelete;

    while ( iCurrent != cRunList.end() )
    {
        iDelete = iCurrent;
        ++iCurrent;

        delete *iDelete;
    }

    cRunList.clear();
}
