using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLinJSONout
{
    public class Parser
    {
        List<Token> TokenList;
        public Parser(List<Token> token_list)
        {
            this.TokenList = token_list;
        }
        public void PrintTokens()
        {
            foreach (var token in TokenList)
            {
                Console.WriteLine($"[{token.Value}, {token.Type}]");
            }
        }
    }
}
