using compiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    class Token
    {
        public Token() { }

        public Token(int linenr, int posnr, TokenType token, object value, int level, int partner)
        {
            LineNr = linenr;
            PositionNr = posnr;
            Type = token;
            Value = value;
            Level = level;
            Partner = partner;
        }
                            
        public int LineNr { get; set; }

        public int PositionNr { get; set; }

        public TokenType Type { get; set; }

        public object Value { get; set; }

        public int Level { get; set; }

        public int Partner { get; set; }
    }
}
