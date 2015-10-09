#include "FunctionCall.h"

#include "Program.h"

FunctionCall::FunctionCall()
{
}

void
FunctionCall::action( Program& cProgram )
{
    const ContentArray &saContentArray  = getContentArray();
    size_t              nSize           = saContentArray.size();

    if ( nSize > 0 )
    {
        Program::fnRunMethod    fnMethod;

        fnMethod    = cProgram.getMethod( saContentArray[0].c_str(), nSize - 1 );

        if ( nSize > 1 )
        {
            ContentArray    saArguments;
            size_t          n;

            saArguments.resize( nSize-1 );
            for ( n=0; n<nSize-1; n++ )
                saArguments[n]  = cProgram.getValue( saContentArray[n+1].c_str() );

            fnMethod( nSize-1, &saArguments[0], cProgram, cProgram.getReturnValue() );
        }
        else
            fnMethod( nSize-1, NULL , cProgram, cProgram.getReturnValue() );
    }
}

void
FunctionCall::show() const
{
    const ContentArray &saContentArray  = getContentArray();
    size_t              n, nSize        = saContentArray.size();

    printf ( " FunctionCall\r\n" );

    for ( n=0; n<nSize; n++ )
        printf( "    %2ld \"%s\"\r\n", n+1, saContentArray[n].c_str() );
}
