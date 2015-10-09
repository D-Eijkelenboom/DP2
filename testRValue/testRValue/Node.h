#ifndef ___Node
#define ___Node

class Program;

#include <list>

class Node
{
public:
    typedef std::list<Node*>    RunList;
    typedef RunList::iterator   iterator;

public:
                        Node()  {}
    virtual            ~Node()  {}

public:
    virtual void        action( Program& )  = 0;
    virtual iterator    next( iterator )    = 0;
    virtual void        show()      const   = 0;
};

#endif
