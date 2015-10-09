#ifndef __Program
#define __Program

#include <string>

class Program
{
public:
    typedef void (*fnRunMethod) ( size_t, const std::string*, Program&, std::string& );

public:
                        Program();

public:
    const char*         getValue( const char* );
    fnRunMethod         getMethod( const char*, unsigned );

public:
    std::string        &getReturnValue();
    void                setReturnValue( const std::string& );

private:
    static  void        runPlus( size_t, const std::string*, Program&, std::string& );

private:
    std::string         m_sReturnValue;
};

#endif
