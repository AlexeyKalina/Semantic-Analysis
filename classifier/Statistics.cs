using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semantic_Analysis
{
    class Statistics
    {
        public static double Calculate(List<Review> reviews)
        {
            double it = 0;
            foreach (var rev in reviews)
            {
                if (rev.MyTonality == rev.Tonality)
                    it++;
            }
            double res = it / reviews.Count * 100;
            return res;
        }
    }
}
