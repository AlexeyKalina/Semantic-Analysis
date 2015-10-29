using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Semantic_Analysis
{
    class DataSet
    {
        private List<WordCount> falseWords;
        private List<WordCount> trueWords;
        private double allWordsCount;
        private double allReviewsCount;
        private double trueReviewsCount;
        private double trueWordsCount;
        private double falseReviewsCount;
        private double falseWordsCount;

        public void Get(string path)
        {
            StreamReader sr = new StreamReader(path);
            falseWords = new List<WordCount>();
            trueWords = new List<WordCount>();

            allWordsCount = Convert.ToDouble(sr.ReadLine());
            allReviewsCount = Convert.ToDouble(sr.ReadLine());
            trueReviewsCount = Convert.ToDouble(sr.ReadLine());
            trueWordsCount = Convert.ToDouble(sr.ReadLine());

            int it = 0;
            string str = sr.ReadLine();
            while (str != "false")
            {
                trueWords.Add(new WordCount(str));
                trueWords[it].Count = Convert.ToInt32(sr.ReadLine());
                str = sr.ReadLine();
                it++;
            }

            it = 0;
            falseReviewsCount = Convert.ToDouble(sr.ReadLine());
            falseWordsCount = Convert.ToDouble(sr.ReadLine());
            str = sr.ReadLine();
            while (str != "end")
            {
                falseWords.Add(new WordCount(str));
                falseWords[it].Count = Convert.ToInt32(sr.ReadLine());
                if (!(sr.EndOfStream))
                {
                    str = sr.ReadLine();
                }
                else
                {
                    str = "end";
                }
                it++;
            }
        }
        public List<WordCount> FalseWords
        {
            get { return falseWords; }
        }
        public List<WordCount> TrueWords
        {
            get { return trueWords; }
        }
        public double AllWordsCount
        {
            get { return allWordsCount; }
        }
        public double AllReviewsCount
        {
            get { return allReviewsCount; }
        }
        public double TrueReviewsCount
        {
            get { return trueReviewsCount; }
        }
        public double TrueWordsCount
        {
            get { return trueWordsCount; }
        }
        public double FalseReviewsCount
        {
            get { return falseReviewsCount; }
        }
        public double FalseWordsCount
        {
            get { return falseWordsCount; }
        }
    }
}
