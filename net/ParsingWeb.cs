using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using HtmlAgilityPack;

namespace Semantic_Analysis
{
    class ParsingWeb
    {
        HtmlDocument doc = new HtmlDocument();
        WebClient wc = new WebClient();

        void Download(string url, ref HtmlNodeCollection nodes, ref HtmlNodeCollection nodes2)
        {
            wc.DownloadFile(url, "0.htm");
            doc.Load("0.htm", Encoding.GetEncoding(1251));
            nodes = doc.DocumentNode.SelectNodes("//section[@class != 'promo__write_response']/p");
            nodes2 = doc.DocumentNode.SelectNodes("//div[@class='card__responses__response__information__rating']/*/b");
        }


        public void Parse(int count, ref string url, ref int it, ref int hund, ref List<Review> reviews)
        {
            HtmlNodeCollection nodes = null;
            HtmlNodeCollection nodes2 = null;
            hund++;
            if (hund != 1) url = url.Substring(0, url.Length - 1);
            if (hund > 10) url = url.Substring(0, url.Length - 1);
            if (hund > 99) url = url.Substring(0, url.Length - 1);
            if (hund > 999) url = url.Substring(0, url.Length - 1);

            url = url + hund.ToString();
            Download(url, ref nodes, ref nodes2);

            int k = 0;
            foreach (var tag in nodes)
            {
                if (it == count) break;
                bool mig = false;
                foreach (var tag2 in tag.ChildNodes)
                {
                    if (tag2.Name == "a")
                    {
                        reviews.Add(new Review(TextChange.Change(tag2.Attributes[4].Value)));
                        mig = true;
                    }
                }
                if (mig == false)
                {
                    reviews.Add(new Review(TextChange.Change(tag.InnerText)));
                }
                reviews[it].Tonality = Convert.ToDouble(nodes2[k].InnerText) > 3;
                k++;
                it++;
            }

            if (count > it)
            {
                Parse(count, ref url, ref it, ref hund, ref reviews);
            }
        }
    }
}

