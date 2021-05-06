using System; // Console.WriteLine()
using System.Collections.Generic; // List<T>

namespace XMLinJSONout
{
    public class Lexer
    {
        public string contents { get; }
        private int position = 0;
        public List<Token> TokenList = new List<Token>();
        public Lexer(string contents)
        {
            this.contents = contents;
        }
        public void PrintTokens()   // TODO: make a logger class since this violates "Single Responsibility Principle"
        {
            foreach (var token in TokenList)
            {
                Console.WriteLine($"[{token.Value}, {token.Type}]");
            }
        }
        public void Tokenize()
        {
            while (position < contents.Length)
            {
                // current character we are handling
                if (CurrentCharacter() == '<')
                {
                    if (position + 1 < contents.Length && PeekNextCharacter() == '/')   // TODO: make this condition look cleaner
                    {
                        // '</' case
                        TokenList.Add(new Token(CurrentCharacter().ToString() + PeekNextCharacter().ToString(), Token.Class.Operator));
                    }
                    else
                        TokenList.Add(new Token(CurrentCharacter().ToString(), Token.Class.Operator));
                }
                else if (CurrentCharacter() == '>')
                {
                    // '>' case
                    TokenList.Add(new Token(CurrentCharacter().ToString(), Token.Class.Operator));
                    ++position;
                    if (position < contents.Length)
                    {
                        var constant = EatConstant();
                        if (!string.IsNullOrWhiteSpace(constant))
                            TokenList.Add(new Token(constant, Token.Class.Constant));
                    }
                }
                else if (IsIdentifier(CurrentCharacter()))
                    TokenList.Add(new Token(EatIdentifier(), Token.Class.Identifier));
                ++position;
            }
        }
        private char PeekNextCharacter()
        {
            // Precondition: (position + 1 < contents.Length)
            return contents[position + 1];
        }
        private char CurrentCharacter()
        {
            return contents[position];
        }
        private bool IsIdentifier(char ch)
        {
            return (Char.IsLetter(ch) || ch == '_');
        }
        private string EatConstant()
        {
            string constant = default;
            do
            {
                constant += contents[position++];
            }
            while (contents[position] != '<');
            --position;
            return constant;
        }
        private string EatIdentifier()
        {
            // Invariant/Assertion: (position < contents.Length)
            string identifier = default;
            do
            {
                identifier += contents[position++];
            }
            while (IsIdentifier(contents[position]));
            // move position back if it was not an identifier character
            --position;
            return identifier;
        }

    }
}
