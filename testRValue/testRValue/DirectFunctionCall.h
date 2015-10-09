#ifndef __DirectFunctionCall
#define __DirectFunctionCall

#include "AbstractFunctionCall.h"

class DirectFunctionCall : public AbstractFunctionCall
{
public:
                        DirectFunctionCall();

public:
    virtual void        action( Program& );
    virtual void        show()      const;
};

#endif
