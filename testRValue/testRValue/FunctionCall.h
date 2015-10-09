#ifndef __FunctionCall
#define __FunctionCall

#include "AbstractFunctionCall.h"

class FunctionCall : public AbstractFunctionCall
{
public:
                        FunctionCall();

public:
    virtual void        action( Program& );
    virtual void        show()      const;
};

#endif
