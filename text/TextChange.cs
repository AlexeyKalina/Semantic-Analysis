using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iveonik.Stemmers;

namespace Semantic_Analysis
{
    static class TextChange
    {
        public static string Change(string str)
        {
            char[] sep = { '\n', '\t', '\r' };
            string[] textSplit = str.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            string newStr = "";
            for (int i = 0; i < textSplit.Length; i++)
            {
                if (textSplit[i].Contains("&lt;br /&gt;"))
                {
                    textSplit[i] = textSplit[i].Substring(0, textSplit[i].Length - 12);
                }

                newStr += textSplit[i];
            }
            return newStr;
        }
        public static string[] SplitToWords(string text)
        {
            RussianStemmer stemmer = new RussianStemmer();
            char[] separators = { ' ', ',', '.', '!', '"', '?', '+', '-', ':', ';', '\n', '\r', '\t', ')', '(', '/', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            string[] textSplit = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < textSplit.Length; i++)
            {
                textSplit[i] = stemmer.Stem(textSplit[i]);
            }
            textSplit = TextChange.JoinNo(textSplit);
            textSplit = TextChange.RemovePrepositions(textSplit);
            return textSplit;
        }

        static string[] RemovePrepositions(string[] words)
        {
            words = words.Where(item => item.Length > 2).ToArray();
            return words;
        }

        static string[] JoinNo(string[] words)
        {
            for (int i = 0; i < words.Length - 1; i++)
            {
                if (words[i] == "не")
                {
                    words[i] = words[i] + words[i + 1];
                    words[i + 1] = "";
                }
            }
            return words;
        }
    }
}

