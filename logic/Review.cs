using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semantic_Analysis
{
    class Review
    {
        private string text;
        private bool tonality;
        private bool mytonality;
        private string[] words;
        public Review(string text)
        {
            this.text = text;
        }
        public string Text
        {
            get { return text; }
        }
        public bool Tonality
        {
            get { return tonality; }
            set { tonality = value; }
        }
        public bool MyTonality
        {
            get { return mytonality; }
            set { mytonality = value; }
        }
        public string[] Words
        {
            get { return words; }
            set { words = value; }
        }
    }
}

