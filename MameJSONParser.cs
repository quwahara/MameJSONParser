using System;
using System.Collections.Generic;
using System.Text;

namespace MameJSONParser
{
    public class MameJSONParser
    {
        public static object Parse(string json)
        {
            if(json == null)
            {
                throw new ArgumentNullException("json");
            }
            return new MameJSONParser(json).Val();
        }

        private readonly List<char> spaces = new List<char>(new char[] { ' ', '\t', '\n', '\r' });
        private string json;
        private int i;
        private int line;
        private int col;

        private MameJSONParser(string json)
        {
            this.json = json;
            i = 0;
            line = 1;
            col = 1;
        }

        private bool EOJ
        {
            get
            {
                return i >= json.Length;
            }
        }

        private char C
        {
            get
            {
                if (EOJ)
                {
                    throw NewException("No more data.");
                }
                return json[i];
            }
        }

        private char Next()
        {
            var ch = C;
            ++i;
            if (!EOJ)
            {
                if (C == '\n')
                {
                    ++line;
                    col = 0;
                }
            }
            return ch;
        }

        private void Consume(char ch)
        {
            if (C != ch)
            {
                throw NewException(string.Format("Expected '{0}' but actually '{1}'.", ch, C));
            }
            Next();
        }

        private void ConsumeString(string s)
        {
            foreach (var ch in s)
            {
                Consume(ch);
            }
        }

        private void SkipSpace()
        {
            while (!EOJ && spaces.Contains(C))
            {
                Next();
            }
        }

        private string Str()
        {
            Consume('"');
            var b = new StringBuilder();
            while (!EOJ && C != '"')
            {
                if (C == '\\')
                {
                    Next();
                    switch (C)
                    {
                        case '"': b.Append('"'); Next(); break;
                        case '\\': b.Append('\\'); Next(); break;
                        case '/': b.Append('/'); Next(); break;
                        case 'b': b.Append('\b'); Next(); break;
                        case 'f': b.Append('\f'); Next(); break;
                        case 'n': b.Append('\n'); Next(); break;
                        case 'r': b.Append('\r'); Next(); break;
                        case 't': b.Append('\t'); Next(); break;
                        case 'u':
                            Next();
                            var x = new StringBuilder()
                                .Append(Next())
                                .Append(Next())
                                .Append(Next())
                                .Append(Next())
                                .ToString();
                            b.Append(Convert.ToChar(Convert.ToInt32(x, 16)));
                            break;
                        default:
                            throw NewException(string.Format("Not an escape character: '{0}'", C));
                    }
                }
                else
                {
                    b.Append(Next());
                }
            }
            Consume('"');
            return b.ToString();
        }

        private readonly List<char> digit = new List<char>(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' });
        private readonly List<char> digit1to9 = new List<char>(new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' });

        private object Number()
        {
            var b = new StringBuilder();
            if (C == '-')
            {
                b.Append(Next());
            }
            if (C == '0')
            {
                b.Append(Next());
            }
            else if (digit1to9.Contains(C))
            {
                b.Append(Next());
                while (!EOJ && digit.Contains(C))
                {
                    b.Append(Next());
                }
            }
            else
            {
                throw NewException(string.Format("Not a number.:'{0}'", C));
            }
            if (!EOJ && C == '.')
            {
                b.Append(Next());
                while (!EOJ && digit.Contains(C))
                {
                    b.Append(Next());
                }
            }
            if (!EOJ && (C == 'E' || C == 'e'))
            {
                b.Append(Next());
                if (C == '+' || C == '-')
                {
                    b.Append(Next());
                }
                if (!digit.Contains(C))
                {
                    throw NewException(string.Format("Not a number.:'{0}'", C));
                }
                while (!EOJ && digit.Contains(C))
                {
                    b.Append(Next());
                }
            }
            var n = b.ToString();
            if (n.Contains(".") || n.Contains("e") || n.Contains("E"))
            {
                return double.Parse(n);
            }
            else
            {
                return int.Parse(n);
            }
        }

        private Dictionary<string, object> Obj()
        {
            Consume('{');
            var dic = new Dictionary<string, object>();
            SkipSpace();
            while (!EOJ && C != '}')
            {
                if (dic.Count > 0)
                {
                    SkipSpace();
                    Consume(',');
                }
                SkipSpace();
                var key = Str();
                SkipSpace();
                Consume(':');
                SkipSpace();
                dic[key] = Val();
                SkipSpace();
            }
            Consume('}');
            return dic;
        }

        private List<object> Arr()
        {
            Consume('[');
            var ls = new List<object>();
            SkipSpace();
            while (!EOJ && C != ']')
            {
                if (ls.Count > 0)
                {
                    SkipSpace();
                    Consume(',');
                }
                SkipSpace();
                ls.Add(Val());
                SkipSpace();
            }
            Consume(']');
            return ls;
        }

        private object Val()
        {
            SkipSpace();
            object ret;
            switch (C)
            {
                case '{': ret = Obj(); break;
                case '[': ret = Arr(); break;
                case '"': ret = Str(); break;
                case 't': ConsumeString("true"); ret = true; break;
                case 'f': ConsumeString("false"); ret = false; break;
                case 'n': ConsumeString("null"); ret = null; break;
                default:
                    if (digit.Contains(C) || C == '-')
                    {
                        ret = Number();
                    }
                    else
                    {
                        throw NewException(string.Format("Unexpected character.:'{0}'", C));
                    }
                    break;
            }
            SkipSpace();
            if (!EOJ)
            {
                throw NewException("Too much data.");
            }
            return ret;
        }

        private Exception NewException(string message)
        {
            return new Exception(string.Format("{0} [{1}:{2}]", message, line, col));
        }
    }
}
