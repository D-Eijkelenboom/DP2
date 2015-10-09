#include "DoNothing.h"

#include <stdio.h>

DoNothing::DoNothing()
{
}

DoNothing::~DoNothing()
{
}

void
DoNothing::action( Program& )
{
}

DoNothing::iterator
DoNothing::next( iterator iCurrent )
{
    iterator    iResult = iCurrent;

    ++iResult;

    return iResult;
}

void
DoNothing::show() const
{
    printf( " DoNothing\r\n" );
}
