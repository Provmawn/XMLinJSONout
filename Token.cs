using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLinJSONout
{
    public class Token
    {
        public enum Class
        {
            Identifier,
            Puntuation,
            Operator,
            Constant
        }
        public string Value { get; set; }
        public Class Type { get; set; }
        public Token(string value, Class type)
        {
            this.Value = value;
            this.Type = type;
        }
    }
}
