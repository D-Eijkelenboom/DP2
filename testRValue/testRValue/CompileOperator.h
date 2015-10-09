#ifndef __CompileOperator
#define __CompileOperator

#include "Compiler.h"

#include <map>

class CompileOperator : public Compiler
{
public:
                            CompileOperator( Compiler* pNext );
    virtual                ~CompileOperator();

public:
    virtual void            compile( const TokenList& cTokenList
                                   , TokenIterator&   iBegin
                                   , TokenIterator&   iEnd
                                   , RunList&         cRunList
                                   , RunIterator&     iBefore );

    virtual TokenIterator   getLastToken( const TokenList& cTokenList
                                        , TokenIterator&   iCurrent );

protected:
    typedef std::map<Token::Enum,std::string> TokenMap;

protected:
    TokenMap               &getTokenMap();

private:
    class CompileNextLevel
    {
    private:
        TokenIterator   iBegin,
                        iEnd;
        RunIterator     iBefore;

    private:
        friend class CompileOperator;
    };

    typedef std::list<CompileNextLevel> CompileNextLevelList;

private:
            void            fillRunlist( const std::string&
                                       , RunList&
                                       , RunIterator&
                                       , RunIterator* );
            void            fillNextLevelList( RunIterator*
                                             , TokenIterator&
                                             , CompileNextLevel&
                                             , CompileNextLevelList& );
            void            insertLastNextLevel( TokenIterator&
                                               , RunIterator&
                                               , CompileNextLevel&
                                               , CompileNextLevelList& );


            void            compileNextLevel( const TokenList&      cTokenList
                                            , RunList&              cRunList
                                            , CompileNextLevelList& cNextLevelList );

private:
    TokenMap                m_nTokenMap;
    Compiler               *m_pNextLevel;
};

#endif
