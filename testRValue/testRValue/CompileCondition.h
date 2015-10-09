#ifndef __CompileCondition
#define __CompileCondition

#include "CompileOperator.h"

class CompileCondition : public CompileOperator
{
public:
                            CompileCondition();

public:
    virtual TokenIterator   getLastToken( const TokenList& cTokenList
                                        , TokenIterator&   iCurrent );
};

#endif
