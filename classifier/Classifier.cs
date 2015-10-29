using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semantic_Analysis
{
    static class Classifier
    {
        public static Review Classify(Review review, DataSet data)
        {
            int wTrue = 0, wFalse = 0;

            review.Words = TextChange.SplitToWords(review.Text);

            double resultTrue = Math.Log(data.TrueReviewsCount / data.AllReviewsCount);
            double resultFalse = Math.Log(data.FalseReviewsCount / data.AllReviewsCount);

            foreach (var word in review.Words)
            {
                wTrue = 0;
                wFalse = 0;
                WordCount newWord = new WordCount(word);
                if (data.TrueWords.Contains(newWord))
                {
                    wTrue = data.TrueWords[data.TrueWords.IndexOf(newWord)].Count;
                }
                resultTrue += Math.Log((wTrue + 1) / (data.AllWordsCount + data.TrueWordsCount));
                if (data.FalseWords.Contains(newWord))
                {
                    wFalse = data.FalseWords[data.FalseWords.IndexOf(newWord)].Count;
                }
                resultFalse += Math.Log((wFalse + 1) / (data.AllWordsCount + data.FalseWordsCount));
            }

            review.MyTonality = (resultTrue > resultFalse);
            return review;
        }
    }
}

