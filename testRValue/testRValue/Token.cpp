#include "Token.h"

Token::Token()
{
    setEnum( NONE );

    m_piPartner = NULL;
}

Token::~Token()
{
}

void
Token::setText( const char* szText )
{
    m_sText = szText;
}

void
Token::setEnum( Enum  nEnum )
{
    m_nEnum = nEnum;
}

void
Token::setPartner( iterator& iPartner )
{
    m_piPartner  = &iPartner;
}

const char*
Token::getText() const
{
    return m_sText.c_str();
}

Token::Enum
Token::getEnum() const
{
    return m_nEnum;
}

Token::iterator*
Token::getPartner() const
{
    return m_piPartner;
}
