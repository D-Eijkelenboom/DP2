using Compiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler
{
    class CompileWhile
    {
        private Stack<Token> needsclosure;
        private TokenType[] OpenTokens;
        private TokenType[] CloseTokens;

        public CompileWhile()
        {
            OpenTokens = new TokenType[]
            {
                TokenType.BRACKETOPEN,
                TokenType.ELIPSISOPEN
            };

            CloseTokens = new TokenType[]
            {
                TokenType.BRACKETOPEN,
                TokenType.ELIPSISOPEN
            };

            needsclosure = new Stack<Token>();
        }

        public void compile(List<Token> tokens)
        { 
            foreach(Token token in tokens)
            {
                if (OpenTokens.Contains(token.Type))
                {
                    needsclosure.Push(token);
                }
                if (CloseTokens.Contains(token.Type))
                {
                    if(token.Type == TokenType.BRACKETCLOSE)
                    {
                        if (needsclosure.Peek().Type == TokenType.BRACKETOPEN)
                        {
                            needsclosure.Pop();
                        }
                        else
                        {
                            Console.WriteLine("Compile error at line: " + token.LineNr + " position: " + token.PositionNr);
                            Console.WriteLine(" \"{\" not found");
                        }
                    }
                    else if (token.Type == TokenType.ELIPSISCLOSE)
                    {
                        if (needsclosure.Peek().Type == TokenType.ELIPSISOPEN)
                        {
                            needsclosure.Pop();
                        }
                        else
                        {
                            Console.WriteLine("Compile error at line: " + token.LineNr + " position: " + token.PositionNr);
                            Console.WriteLine(" \"(\" not found");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Compile error at line: " + token.LineNr + " position: " + token.PositionNr);
                    }
                }


            }
        }
    }
}
