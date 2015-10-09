#ifndef __DoNothing
#define __DoNothing

#include "Node.h"

class DoNothing : public Node
{
public:
                    DoNothing();
    virtual        ~DoNothing();

public:
    virtual void        action( Program& );
    virtual iterator    next( iterator );
    virtual void        show()      const;
};

#endif
