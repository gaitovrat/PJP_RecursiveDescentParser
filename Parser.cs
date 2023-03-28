using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class Parser
    {
        public Parser(Scanner scanner)
        {
            _scanner = scanner;
            _token = scanner.NextToken();

            var value = E();

            if (_error)
                Console.WriteLine("Error");
            else
            {
                Console.WriteLine(string.Join(" ", _output));
                Console.WriteLine(value);
            }
        }

        public int E()
        {
            _output.Add("1");
            return E1(T());
        }

        public int E1(int n)
        {
            switch (_token.Type)
            {
                case TokenType.PLUS:
                    Expect(TokenType.PLUS);
                    _output.Add("2");
                    return E1(n + T());
                case TokenType.MINUS:
                    Expect(TokenType.MINUS);
                    _output.Add("3");
                    return E1(n - T());
                case TokenType.EOL:
                    Expect(TokenType.EOL);
                    _output.Add("4");
                    return n;
                default:
                    return n;
            }
        }

        public int T()
        {
            _output.Add("5");
            return T1(F());
        }

        public int T1(int n)
        {
            switch (_token.Type)
            {
                case TokenType.MUL:
                    Expect(TokenType.MUL);
                    _output.Add("6");
                    return T1(n * F());
                case TokenType.DIV:
                    Expect(TokenType.DIV);
                    _output.Add("7");
                    return T1(n / F());
                case TokenType.EOL:
                    Expect(TokenType.EOL);
                    _output.Add("8");
                    return n;
                default:
                    return n;
            }
        }

        public int F()
        {
            var value = 0;
            switch (_token.Type)
            {
                case TokenType.LeftPAR:
                    Expect(TokenType.LeftPAR);
                    _output.Add("9");
                    value = E();
                    Expect(TokenType.RightPAR);
                    return value;
                case TokenType.NUMBER:
                    value = int.Parse(_token.Value);
                    Expect(TokenType.NUMBER);
                    _output.Add("10");
                    return value;
                default:
                    return 0;
            }
        }

        public void Expect(TokenType type)
        {
            if (_token.Type == type)
                _token = _scanner.NextToken();
            else _error = true;
        }

        private Scanner _scanner;
        private Token _token;
        private bool _error = false;
        private List<string> _output = new List<string>();
    }
}
