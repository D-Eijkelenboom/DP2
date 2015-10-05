using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Tokenizer
{
	public class Tokenizer
	{
		string sampleFolder;
		public Dictionary<String, TokenType> Matchers_Keyword { get; set; }
		public Dictionary<String, TokenType> Matchers_Character { get; set; }
		public string[] lines_sample { get; set; }
		public Stack<Token> PartnerStack { get; set; }
		public List<Token> TokenList { get; set; }
		public List<Token> ErrorList { get; set; }

		public bool debug { get; set; }

		public int level { get; set; }

		public Tokenizer()
		{
			sampleFolder = Helper.GetProjectFolder(Environment.CurrentDirectory) + "Samples\\";
			debug = false;
		}

		public bool isEmpty()
		{
			return this.TokenList.Count < 0;
		}

		private void init(string sample)
		{
			lines_sample = System.IO.File.ReadAllLines(sampleFolder + sample + ".txt");

			this.PartnerStack = new Stack<Token>();
			this.TokenList = new List<Token>();
			this.ErrorList = new List<Token>();

			this.Matchers_Keyword = new Dictionary<String, TokenType>();
			this.Matchers_Keyword.Add("if", TokenType.If);
			this.Matchers_Keyword.Add("else", TokenType.Else);
			this.Matchers_Keyword.Add("While", TokenType.While);
			this.Matchers_Keyword.Add("Show", TokenType.Show);

			this.Matchers_Character = new Dictionary<string, TokenType>();
			this.Matchers_Character.Add(" ", TokenType.Whitespace);
			this.Matchers_Character.Add("=", TokenType.Equals);
			this.Matchers_Character.Add("*", TokenType.Multiply);
			this.Matchers_Character.Add("/", TokenType.Divide);
			this.Matchers_Character.Add("==", TokenType.Compare);
			this.Matchers_Character.Add("!=", TokenType.NotCompare);
			this.Matchers_Character.Add("+", TokenType.Plus);
			this.Matchers_Character.Add("-", TokenType.Minus);
			this.Matchers_Character.Add("(", TokenType.OpenParenth);
			this.Matchers_Character.Add(")", TokenType.CloseParenth);
			this.Matchers_Character.Add("{", TokenType.LBracket);
			this.Matchers_Character.Add("}", TokenType.RBracket);
			this.Matchers_Character.Add(";", TokenType.Semicolon);

			this.level = 0;
		}

		public void createTokenList(string sampleFile)
		{
			Console.WriteLine("\n using file " + sampleFile + "\n");

			init(sampleFile);
			for (int lineNumber = 0; lineNumber < lines_sample.Length; lineNumber++)
			{
				string currentLine = lines_sample[lineNumber];
				string currentToken = "";
				for (int position = 0; position < currentLine.Length; ++position)
				{
					currentToken += currentLine[position];
					if (isLetter(currentToken[0]))
						position = processKeyword(currentLine, currentToken, lineNumber + 1, position);
					else if (isDigit(currentToken[0]))
						position = processNumber(currentLine, currentToken, lineNumber + 1, position);
					else if (isWhitespace(currentToken[0]))
						position = processWhitespace(currentLine, currentToken, lineNumber + 1, position);
					else if (isSpecialChar(currentToken[0]))
						position = processSpecialCharacter(currentLine, currentToken, lineNumber + 1, position);

					currentToken = "";
				}
			}
			checkPartnerErrors();
		}

		public void PrintPartnerStack()
		{
			foreach (var item in PartnerStack)
			{
				Console.WriteLine(item);
			}
		}

		public void PrintTokenList()
		{
			foreach (var item in TokenList)
			{
				Console.WriteLine(item);
			}
		}

		#region Checks
		public bool isSemicolon(char c)
		{
			return c == ';';
		}

		public bool isLetter(char c)
		{
			return Char.IsLetter(c);
		}

		public bool isDigit(char c)
		{
			return Char.IsDigit(c);
		}

		public bool isWhitespace(char c)
		{
			return Char.IsWhiteSpace(c);
		}

		public bool isSpecialChar(char c)
		{
			return !(Char.IsLetterOrDigit(c)) || Char.IsWhiteSpace(c);
		}
		#endregion

		#region Token Processing
		public int processKeyword(string currentLine, string currentToken, int lineNumber, int position)
		{
			int newPosition = position + 1;

			for (int i = position + 1; i < currentLine.Length; i++)
			{
				newPosition = i;
				if (isWhitespace(currentLine[i]) || isSpecialChar(currentLine[i]))
				{
					newPosition = i - 1;
					break;
				}
				currentToken += currentLine[i];
			}
			currentToken = currentToken.Trim();
			Token t = new Token(lineNumber, position, currentToken, TokenType.Identifier, this.level, null);
			if (this.Matchers_Keyword.Keys.Contains(currentToken))
			{
				t.TokenType = this.Matchers_Keyword[currentToken];
			}

			handlePartners(t);

			this.TokenList.Add(t);

			if (debug)
			{
				Console.WriteLine("New token (keyword/identifier): " + currentToken);
			}
			return newPosition;
		}

		public int processNumber(string currentLine, string currentToken, int lineNumber, int position)
		{
			int newPosition = position + 1;

			for (int i = position + 1; i < currentLine.Length; i++)
			{
				newPosition = i;
				if (isWhitespace(currentLine[i]) || !isDigit(currentLine[i]))
				{
					newPosition = i - 1;
					break;
				}
				currentToken += currentLine[i];
			}
			currentToken = currentToken.Trim();

			Token t = new Token(lineNumber, position, currentToken, TokenType.Number, this.level, null);

			this.TokenList.Add(t);

			if (debug)
			{
				Console.WriteLine("New token (number): " + currentToken);
			}
			return newPosition;
		}

		public int processWhitespace(string currentLine, string currentToken, int lineNumber, int position)
		{
			int newPosition = position + 1;

			for (int i = position + 1; i < currentLine.Length; i++)
			{
				newPosition = i;
				if (!isWhitespace(currentLine[i]))
				{
					newPosition = i - 1;
					break;
				}
				currentToken += currentLine[i];
			}
			if (debug)
			{
				Console.WriteLine("New token (whitespace): " + currentToken);
			}
			return newPosition;
		}

		public int processSpecialCharacter(string currentLine, string currentToken, int lineNumber, int position)
		{
			int newPosition = position + 1;

			for (int i = position + 1; i < currentLine.Length; i++)
			{
				newPosition = i;
				if (isSemicolon(currentLine[i]) || isWhitespace(currentLine[i]) || !isSpecialChar(currentLine[i]))
				{
					newPosition = i - 1;
					break;
				}
				currentToken += currentLine[i];
			}
			currentToken = currentToken.Trim();

			Token t = new Token(lineNumber, position, currentToken, TokenType.Undetermined, this.level, null);
			if (this.Matchers_Character.Keys.Contains(currentToken))
			{
				t.TokenType = this.Matchers_Character[currentToken];
			}

			handlePartners(t);

			this.TokenList.Add(t);


			if (debug)
			{
				Console.WriteLine("New token (special character): " + currentToken);
			}
			return newPosition;
		}
		#endregion

		#region Partner, Level and Error Handling
		public void handlePartners(Token t)
		{
			switch (t.TokenType)
			{
				case TokenType.If:
					PartnerStack.Push(t);
					break;
				case TokenType.Else:
					if (PartnerStack.Count > 0 && PartnerStack.Peek().TokenType == TokenType.If)
					{
						Console.WriteLine("Adding partner to if");
						t.Partner = PartnerStack.Peek();
						PartnerStack.Pop().Partner = t;
					}
					else
					{
						this.ErrorList.Add(t);
					}
					break;
				case TokenType.Do:
					PartnerStack.Push(t);
					break;
				case TokenType.While:
					if (PartnerStack.Count > 0 && PartnerStack.Peek().TokenType == TokenType.Do)
					{
						t.Partner = PartnerStack.Peek();
						PartnerStack.Pop().Partner = t;
					}
					else
					{
						this.ErrorList.Add(t);
					}
					break;
				case TokenType.LBracket:
					this.level++;
					PartnerStack.Push(t);
					break;
				case TokenType.RBracket:

					if (PartnerStack.Count > 0 && PartnerStack.Peek() != null && PartnerStack.Peek().TokenType == TokenType.LBracket)
					{
						this.level--;
						t.Partner = PartnerStack.Peek();
						PartnerStack.Pop().Partner = t;
					}
					else
					{
						this.ErrorList.Add(t);
					}
					break;
				case TokenType.OpenParenth:
					this.level++;
					t.Level = this.level;
					PartnerStack.Push(t);
					break;
				case TokenType.CloseParenth:
					if (PartnerStack.Count > 0 && PartnerStack.Peek() != null && PartnerStack.Peek().TokenType == TokenType.OpenParenth)
					{
						this.level--;
						t.Level = this.level;
						t.Partner = PartnerStack.Peek();
						PartnerStack.Pop().Partner = t;
					}
					else
					{
						this.ErrorList.Add(t);
					}
					break;
			}
		}

		public void checkPartnerErrors()
		{
			if (this.level == 0 && PartnerStack.Count < 1 && ErrorList.Count < 1)
			{
				Console.WriteLine("No errors found");
			}
			else
			{
				Token current;
				while (PartnerStack.Count > 0)
				{
					current = PartnerStack.Pop();
					switch (current.TokenType)
					{
						case TokenType.Else:
						case TokenType.Do:
						case TokenType.LBracket:
						case TokenType.RBracket:
						case TokenType.OpenParenth:
						case TokenType.CloseParenth:
							Console.WriteLine("Errors occurred on token: " + current.TokenType + " [" + current.TokenValue + "]" + "(Line: " + current.LineNumber + ")");
							break;
					}
				}
				printErrorList();
			}

		}

		public void printErrorList()
		{
			foreach (Token t in this.ErrorList)
			{
				Console.WriteLine("Errors occurred on token: " + t.TokenType + " [" + t.TokenValue + "]" + "(Line: " + t.LineNumber + ")");
			}
		}
		#endregion

	}
}
