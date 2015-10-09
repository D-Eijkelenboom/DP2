#ifndef __Compiler
#define __Compiler

#include "Node.h"
#include "Token.h"

class Compiler
{
public:
    typedef Node::RunList       RunList;
    typedef RunList::iterator   RunIterator;
    typedef Token::TokenList    TokenList;
    typedef TokenList::iterator TokenIterator;

public:
                            Compiler();
    virtual                ~Compiler();

public:
    virtual void            compile( const TokenList& cTokenList
                                   , TokenIterator&   iBegin
                                   , TokenIterator&   iEnd
                                   , RunList&         cRunList
                                   , RunIterator&     iBefore ) = 0;

    virtual TokenIterator   getLastToken( const TokenList& cTokenList
                                        , TokenIterator&   iCurrent );

protected:
    static  std::string     getNextLocalVariableName( std::string& );
};

#endif
