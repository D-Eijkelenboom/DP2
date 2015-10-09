#ifndef __Token
#define __Token

#include <list>
#include <string>

class Token
{
public:
    enum Enum
    {
        NONE = 0,
        PLUS,
        MINUS,
        TIMES,
        DIVIDE,
        LESS_THAN,
        LARGER_THAN,
        IDENTIFIER,
        NUMBER,
        CONDITION_OPEN,
        CONDITION_CLOSE,    
        SEMICOLON
    };

public:
    typedef std::list<Token*>   TokenList;
    typedef TokenList::iterator iterator;

public:
                    Token();
    virtual        ~Token();

public:
    virtual void    setText( const char* );
    virtual void    setEnum( Enum );
    virtual void    setPartner( iterator& );

public:
    const char     *getText()       const;
    Enum            getEnum()       const;
    iterator       *getPartner()    const;

private:
    std::string     m_sText;
    Enum            m_nEnum;
    iterator       *m_piPartner;
};

#endif
