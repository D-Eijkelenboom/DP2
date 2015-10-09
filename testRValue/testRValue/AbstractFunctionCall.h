#ifndef __AbstractFunctionCall
#define __AbstractFunctionCall

#include "Node.h"

#include <vector>

class AbstractFunctionCall : public Node
{
public:
                                AbstractFunctionCall();

public:
    virtual iterator            next( iterator );

public:
    virtual void                setArraySize( size_t );
    virtual void                setAt( unsigned, const char* );

protected:
    typedef std::vector<std::string> ContentArray;

protected:
    virtual const ContentArray &getContentArray()   const;

private:
    ContentArray                m_sContentArray;
};

#endif
