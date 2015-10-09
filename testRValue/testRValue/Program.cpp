#include "Program.h"

#include <sstream>

Program::Program()
{
}

const char*
Program::getValue( const char* szName )
{
    return "3";
}

Program::fnRunMethod
Program::getMethod( const char* szName, unsigned )
{
    return runPlus;
}

std::string&
Program::getReturnValue()
{
    return m_sReturnValue;
}

void
Program::setReturnValue( const std::string& sValue )
{
    m_sReturnValue  = sValue;
}

void
Program::runPlus( size_t nSize, const std::string* saText, Program&, std::string& sReturnValue )
{
    if ( nSize != 2 )
        sReturnValue    = "0";
    else
    {
        std::stringstream   sStream;

        sStream << ( ::atoi(saText[0].c_str()) + ::atoi(saText[2].c_str()) );
        sReturnValue    = sStream.str();
    }
}
