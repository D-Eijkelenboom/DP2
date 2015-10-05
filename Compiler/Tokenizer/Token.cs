using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Tokenizer
{
	public class Token
	{
		int lineNumber;
		public int LineNumber
		{
			get { return lineNumber; }
			set { lineNumber = value; }
		}
		int inlinePosition;
		public int InlinePosition
		{
			get { return inlinePosition; }
			set { inlinePosition = value; }
		}

		string tokenValue;
		public string TokenValue
		{
			get { return tokenValue; }
			set { tokenValue = value; }
		}

		TokenType tokenType;
		public TokenType TokenType
		{
			get { return tokenType; }
			set { tokenType = value; }
		}

		int level;
		public int Level
		{
			get { return level; }
			set { level = value; }
		}

		Token partner;
		public Token Partner
		{
			get { return partner; }
			set { partner = value; }
		}

		public Token(int lineNumber, int inlinePosition, String tokenValue, TokenType tokenType, int level, Token partner)
		{
			this.LineNumber = lineNumber;
			this.InlinePosition = inlinePosition;
			this.TokenValue = tokenValue;
			this.TokenType = tokenType;
			this.Level = level;
			this.Partner = partner;
		}
		
		public override string ToString()
		{
				return "[" + lineNumber + "](" + inlinePosition + ")-" + tokenType + "--" + tokenValue + "-{" + level + "}";
		}
	}
}
