using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace compiler
{
    public class Tokenizer
    {
        private TokenType[] OpenTokens;
        private TokenType[] CloseTokens;
        private Stack<Token> ifTokens;
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
            ifTokens = new Stack<Token>();
            tokens = new List<Token>();

            tokenize(lines);
        }
        
        private List<Token> tokenize(string[] lines)
        {
            int posNr = 0;
            int lineNr = 0;
            int level = 0;

            foreach(string line in lines)
            {
                string cleanLine = Regex.Replace(line, @"\t|\n|\r", "");
                lineNr++;

				// escape new line
                if (cleanLine == "")
					continue;

                string[] words = cleanLine.Split(' ');

                for (int i = 0; i < words.Length; i++)
                {
                    switch (words[i])
                    {
                        case "print":
                            tokens.Add(new Token(lineNr, posNr, TokenType.PRINT, "print", level, null));
                            break;
                        case "for":
                            tokens.Add(new Token(lineNr, posNr, TokenType.FOR, "for", level, null));
                            break;
                        case "while":
                            tokens.Add(new Token(lineNr, posNr, TokenType.WHILE, "while", level, null));
                            break;
                        case "if":
                            tokens.Add(new Token(lineNr, posNr, TokenType.IF, "if", level, null));
                            ifTokens.Push(tokens.LastOrDefault());
                            break;                        
                        case "else":
                            if (ifTokens.Count == 0)
                            {
                                Console.WriteLine("Error: IF statement not found");
                            }
                            else
                            {
                                Token partner = ifTokens.Pop();
                                tokens.Add(new Token(lineNr, posNr, TokenType.ELSE, "else", level, partner));
                                partner.Partner = tokens.LastOrDefault();
                            }                            
                            break;
                        case "{":
                            level++;
                            Token token = new Token(lineNr, posNr, TokenType.BRACKETOPEN, "{", level, null); 
                            needsClosure.Push(token);
                            tokens.Add(token); 
                            break;
                        case "}":
                            if (needsClosure.Peek().Type != TokenType.BRACKETOPEN)
                            {
                                Console.WriteLine("Error: } not found");
                            }
                            else
                            {
                                level--;
                                Token partner = needsClosure.Pop();
                                tokens.Add(new Token(lineNr, posNr, TokenType.BRACKETCLOSE, "}", level, partner));
                                partner.Partner = tokens.LastOrDefault();

                            }
                            break;
                        case "(":
                            tokens.Add(new Token(lineNr, posNr, TokenType.ELIPSISOPEN, "(", level, null));
                            needsClosure.Push(tokens.LastOrDefault());
                            
                            break;
                        case ")":
                            if (needsClosure.Peek().Type != TokenType.ELIPSISOPEN)
                            {
                                Console.WriteLine("Error: ( not found");
                            }
                            else
                            {
                                Token partner = needsClosure.Pop();
                                tokens.Add(new Token(lineNr, posNr, TokenType.ELIPSISCLOSE, ")", level, partner));
                                partner.Partner = tokens.LastOrDefault();
                            }
                            break;
                        case ";":
                            tokens.Add(new Token(lineNr, posNr, TokenType.SEMICOLON, ";", level, null));
                            break;
                        case "=":
                            tokens.Add(new Token(lineNr, posNr, TokenType.EQUALS, "=", level, null));
                            break;
                        case "==":
                            tokens.Add(new Token(lineNr, posNr, TokenType.COMPARE, "==", level, null));
                            break;
                        case "<=":
                            tokens.Add(new Token(lineNr, posNr, TokenType.LESSEREQUALS, "<=", level, null));
                            break;
                        case ">=":
                            tokens.Add(new Token(lineNr, posNr, TokenType.GREATEREQUALS, ">=", level, null));
                            break;
                        case "!=":
                            tokens.Add(new Token(lineNr, posNr, TokenType.NOTEQUALS, "!=", level, null));
                            break;
                        case "+":
                            tokens.Add(new Token(lineNr, posNr, TokenType.PLUS, "+", level, null));
                            break;
                        case "-":
                            tokens.Add(new Token(lineNr, posNr, TokenType.MINUS, "-", level, null));
                            break;
                        case "*":
                            tokens.Add(new Token(lineNr, posNr, TokenType.MULTIPLY, "*", level, null));
                            break;
                        case "/":
                            tokens.Add(new Token(lineNr, posNr, TokenType.DIVIDE, "/", level, null));
                            break;
                        case "++":
                            tokens.Add(new Token(lineNr, posNr, TokenType.INCREMENT, "++", level, null));
                            break;
                        case "--":
                            tokens.Add(new Token(lineNr, posNr, TokenType.DECREMENT, "--", level, null));
                            break;
                        default:
                            string temp = Regex.Replace(words[i], @";", "");
                            int value;
                            if (int.TryParse(temp, out value))
                            {
                                tokens.Add(new Token(lineNr, posNr, TokenType.NUMBER, value.ToString(), level, null));
                            }
                            else 
                            {
                                tokens.Add(new Token(lineNr, posNr, TokenType.IDENTIFIER, temp, level, null));
                            }
                            break;
                    }
                    posNr = posNr + words[i].Length + 1;
                }                                
            }
            if(needsClosure.Count != 0)
            {
                Console.WriteLine("Compile error: \"} or ) \" missing!");
            }

            connectTokens();

            return tokens;
        }

        public void connectTokens()
        {
            for (int i = 0; i < tokens.Count - 1; i++)
            {
                if (i < tokens.Count - 1)
                {
                    tokens[i].Next = tokens[i + 1];
                    tokens[i + 1].Prev = tokens[i];
                }
            }
        }

        public List<Token> getTokens()
        {
            return tokens;
        }
    }
}
