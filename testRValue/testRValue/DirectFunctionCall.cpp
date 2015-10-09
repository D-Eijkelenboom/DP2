#include "DirectFunctionCall.h"

#include "Program.h"

#include <stdio.h>

DirectFunctionCall::DirectFunctionCall()
{
}

void
DirectFunctionCall::action( Program& cProgram )
{
    const ContentArray &saContentArray  = getContentArray();
    size_t              nSize           = saContentArray.size();

    if ( nSize > 0 )
    {
        Program::fnRunMethod    fnMethod;

        fnMethod    = cProgram.getMethod( saContentArray[0].c_str(), nSize - 1 );

        if ( nSize > 1 )
            fnMethod( nSize-1, &saContentArray[1], cProgram, cProgram.getReturnValue() );
        else
            fnMethod( nSize-1, NULL              , cProgram, cProgram.getReturnValue() );
    }
}

void
DirectFunctionCall::show() const
{
    const ContentArray &saContentArray  = getContentArray();
    size_t              n, nSize        = saContentArray.size();

    printf ( " DirectFunctionCall\r\n" );

    for ( n=0; n<nSize; n++ )
        printf( "    %2ld \"%s\"\r\n", n+1, saContentArray[n].c_str() );
}
