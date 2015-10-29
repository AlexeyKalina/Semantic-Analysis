using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semantic_Analysis
{
    class WordCount : System.Object
    {
        private string word;
        private int count;
        public WordCount(string word)
        {
            this.word = word;
            count = 1;
        }
        public string Word
        {
            get { return word; }
        }
        public int Count
        {
            set { count = value; }
            get { return count; }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            WordCount p = obj as WordCount;
            if ((System.Object)p == null)
            {
                return false;
            }

            return (word == p.Word);
        }

        public override int GetHashCode()
        {
            return word.Length;
        }
    }
}

