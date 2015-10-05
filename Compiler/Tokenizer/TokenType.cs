using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Tokenizer
{
	public enum TokenType
	{
		//Keywords
		If,
		Else,
		While,
		Do,
		Show,

		//Characters
		Plus,
		Minus,
		Multiply,
		Divide,
		OpenParenth,
		CloseParenth,
		LBracket,
		RBracket,
		NotCompare,
		Compare,
		Equals,
		Semicolon,

		//Other
		Identifier,
		Number,
		Whitespace,
		Undetermined
	}
}
