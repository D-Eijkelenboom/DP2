using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compiler
{
    class Syntax
    {
        public static bool isNumber(char c)
        {
            if (char.IsDigit(c))
                return true;
            return false;
        }

        public static bool isSymbol(char c)
        {
            if (char.IsSymbol(c))
                return true;
            return false;
        }
    }
}
