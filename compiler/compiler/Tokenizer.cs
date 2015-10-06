using Compiler;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace compiler
{
    class Tokenizer
    {
        private TokenType[] OpenTokens;
        private TokenType[] CloseTokens;
        private Stack<Token> needsClosure;
        private List<Token> tokens;
        private string[] lines;
        private int level;

        public Tokenizer(string[] lines)
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

            needsClosure = new Stack<Token>();
            tokens = new List<Token>();

            //string[] text = clean(lines);
            tokenize(lines);
        }
        
        private List<Token> tokenize(string[] lines)
        {
            int posNr = 0;
            int lineNr = 0;
            int level = 0;

            foreach(string line in lines)
            {
                lineNr++;
                string[] words = line.Split(' ');

                for (int i = 0; i < words.Length; i++)
                {                   
                    switch (words[i])
                    { 
                        case "for":
                            tokens.Add(new Token(lineNr, posNr, TokenType.FOR, "for", level, -1));
                            break;
                        case "while":
                            tokens.Add(new Token(lineNr, posNr, TokenType.WHILE, "while", level, -1));
                            break;
                        case "if":
                            tokens.Add(new Token(lineNr, posNr, TokenType.IF, "if", level, -1));
                            needsClosure.Push(tokens.LastOrDefault());
                            break;
                        case "elseif":
                            if (needsClosure.Peek().Type != TokenType.IF)
                            {
                                Console.WriteLine("Error: IF statement not found");
                            }
                            else
                            {
                                tokens.Add(new Token(lineNr, posNr, TokenType.ELSEIF, "elseif", level, -1));
                                needsClosure.Pop();
                            }
                            break;
                        case "else":
                            if (needsClosure.Peek().Type != TokenType.IF || needsClosure.Peek().Type != TokenType.ELSEIF)
                            {
                                Console.WriteLine("Error: IF / ELSEIF statement not found");
                            }
                            else
                            {
                                needsClosure.Pop();
                                tokens.Add(new Token(lineNr, posNr, TokenType.ELSE, "else", level, -1));
                            }                            
                            break;
                        case "{":
                            level++;
                            Token token = new Token(lineNr, posNr, TokenType.BRACKETOPEN, "{", level, -1); 
                            needsClosure.Push(token);
                            tokens.Add(token);
                            break;
                        case "}":
                            if (needsClosure.Peek().Type != TokenType.BRACKETOPEN && needsClosure.Peek().Type != TokenType.IF)
                            {
                                Console.WriteLine("Error: } not found");
                            }
                            else
                            {
                                if (needsClosure.Peek().Type == TokenType.IF)
                                {
                                    needsClosure.Pop();
                                    if (needsClosure.Peek().Type == TokenType.BRACKETOPEN)
                                    {
                                        level--;
                                        needsClosure.Pop();
                                        tokens.Add(new Token(lineNr, posNr, TokenType.BRACKETCLOSE, "}", level, -1));
                                    }
                                }
                                level--;
                                needsClosure.Pop();
                                tokens.Add(new Token(lineNr, posNr, TokenType.BRACKETCLOSE, "}", level, -1));
                            }
                            break;
                        case "(":
                            tokens.Add(new Token(lineNr, posNr, TokenType.ELIPSISOPEN, "(", level, -1));
                            needsClosure.Push(tokens.LastOrDefault());
                            
                            break;
                        case ")":
                            if (needsClosure.Peek().Type != TokenType.ELIPSISOPEN)
                            {
                                Console.WriteLine("Error: ( not found");
                            }
                            else
                            {
                                needsClosure.Pop();
                                tokens.Add(new Token(lineNr, posNr, TokenType.ELIPSISCLOSE, ")", level, -1));
                            }
                            break;
                        case ";":
                            tokens.Add(new Token(lineNr, posNr, TokenType.SEMICOLON, ";", level, -1));
                            break;
                        case "=":
                            tokens.Add(new Token(lineNr, posNr, TokenType.EQUALS, "=", level, -1));
                            break;
                        case "<=":
                            tokens.Add(new Token(lineNr, posNr, TokenType.LESSEREQUALS, "<=", level, -1));
                            break;
                        case ">=":
                            tokens.Add(new Token(lineNr, posNr, TokenType.GREATEREQUALS, ">=", level, -1));
                            break;
                        case "!=":
                            tokens.Add(new Token(lineNr, posNr, TokenType.NOTEQUALS, "!=", level, -1));
                            break;
                        case "+":
                            tokens.Add(new Token(lineNr, posNr, TokenType.PLUS, "+", level, -1));
                            break;
                        case "-":
                            tokens.Add(new Token(lineNr, posNr, TokenType.MINUS, "-", level, -1));
                            break;
                        case "*":
                            tokens.Add(new Token(lineNr, posNr, TokenType.MULTIPLY, "*", level, -1));
                            break;
                        case "/":
                            tokens.Add(new Token(lineNr, posNr, TokenType.DIVIDE, "/", level, -1));
                            break;
                        default:
                            int value;
                            if (int.TryParse(words[i], out value))
                            {                                
                                tokens.Add(new Token(lineNr, posNr, TokenType.NUMBER, value, level, -1));
                            }
                            else 
                            {
                                tokens.Add(new Token(lineNr, posNr, TokenType.IDENTIFIER, value, level, -1));
                            }
                            break;
                    }
                    posNr = posNr + words[i].Length + 1;
                }                                
            }
            return tokens;
        }

        private string[] clean(string[] lines)
        {
            List<string> cleanedList = new List<string>();
            foreach (string line in lines)
            {
                string cleanedString = Regex.Replace(line, @"^\s*$\n", string.Empty, RegexOptions.Multiline).TrimEnd();
                cleanedList.Add(cleanedString);
            }
            return cleanedList.ToArray();
        }

        public List<Token> getTokens()
        {
            return tokens;
        }
    }
}
