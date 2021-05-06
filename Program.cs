
namespace XMLinJSONout
{
    class Program
    {
        static void Main(string[] args)
        {
            var xml_file = new FileManager("C:\\dev\\XMLinJSONout\\XMLinJSONout\\message.txt");
            var lexer = new Lexer(xml_file.Contents);
            lexer.Tokenize();
            var parser = new Parser(lexer.TokenList);
            parser.PrintTokens();
        }
    }
}
