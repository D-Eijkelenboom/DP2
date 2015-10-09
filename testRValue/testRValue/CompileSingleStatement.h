#ifndef __CompileSingleStatement
#define __CompileSingleStatement

#include "Compiler.h"

class CompileSingleStatement : public Compiler
{
public:
    virtual void            compile( const TokenList& cTokenList
                                   , TokenIterator&   iBegin
                                   , TokenIterator&   iEnd
                                   , RunList&         cRunList
                                   , RunIterator&     iBefore );
};

#endif
