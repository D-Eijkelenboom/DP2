#include "AbstractFunctionCall.h"

AbstractFunctionCall::AbstractFunctionCall()
{
}

AbstractFunctionCall::iterator
AbstractFunctionCall::next( iterator iCurrent )
{
    iterator    iNext   = iCurrent;

    ++iNext;

    return iNext;
}

void
AbstractFunctionCall::setArraySize( size_t nSize )
{
    m_sContentArray.resize( nSize );
}

void
AbstractFunctionCall::setAt( unsigned nPosition, const char* szText )
{
    m_sContentArray[nPosition]  = szText;
}

const AbstractFunctionCall::ContentArray&
AbstractFunctionCall::getContentArray() const
{
    return m_sContentArray;
}
