using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvlDevTools.Utilities.Literals
{
    public static class GreekLiterals
    {
        private readonly static Dictionary<string, string> greekLiterals = new Dictionary<string, string>()
        {
            {"α", "a" },
            {"β", "b" },
            {"γ", "g" },
            {"δ", "d" },
            {"ε", "e" },
            {"ζ", "z" },
            {"η", "i" },
            {"θ", "th"},
            {"ι", "i" },
            {"κ", "k" },
            {"λ", "l" },
            {"μ", "m" },
            {"ν", "n" },
            {"ξ", "x" },
            {"ο", "o" },
            {"π", "p" },
            {"ρ", "r" },
            {"σ", "s" },
            {"τ", "t" },
            {"υ", "y" },
            {"φ", "f" },
            {"χ", "ch" },
            {"ψ", "ps" },
            {"ω", "ο" },
            {"ς", "s" },
            {"ά", "a" },
            {"έ", "e" },
            {"ή", "i" },
            {"ί", "i" },
            {"ό", "o" },
            {"ύ", "y" },
            {"ώ", "ο" },
        };

        public static string ToGreeklish(this string source, TextCase textCase, char whiteSpace = ' ')
        {
            var mRet = new StringBuilder();
            mRet.Append(source.ToLower());

            for (int i = 0; i < mRet.Length; i++)
            {
                if (mRet[i] == ' ')
                {
                    mRet.Replace(' ', whiteSpace);
                    continue;
                }

                mRet.Replace(mRet[i].ToString(), ConvertLiterals(mRet[i].ToString()));
            }

            return textCase switch
            {
                TextCase.ToLowerCase => mRet.ToString().ToLower(),
                TextCase.ToUpperCase => mRet.ToString().ToUpper(),
                TextCase.ToSentenceCase => char.ToUpper(mRet[0]) + mRet.ToString().Substring(1),
                _ => mRet.ToString().ToLower()
            };
        }

        private static string ConvertLiterals(string c)
        {
            return greekLiterals.ContainsKey(c) ? greekLiterals[c] : c;
        }
    }
}
