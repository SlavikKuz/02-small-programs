using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebScrapper.Builders;
using WebScrapper.Data;
using WebScrapper.Workers;

namespace WebScrapper
{
    class Program
    {
        private const string Method = "search";

        static void Main(string[] args)
        {
            try
            {
  
                using (WebClient client = new WebClient())
                {
                    string content = client.DownloadString($"https://www.finn.no/job/fulltime/search.html?occupation=0.23");

                    ScrapeCriteria scrapeCriteria = new ScrapeCriteriaBuilder().WithData(content)
                        .WithRegex(@"<a id=.(.*?). href=.(.*?). class=.ads__unit__link. data-finnkode=.(.*?). data-listposition=.(.*?). (.*?) data-search-resultitem=..>\n\n(.*?)\n.(.*?)<.a>")
                        .WithRegexOptions(RegexOptions.ExplicitCapture)
                        .WithPart(new ScrapeCriteriaPartBuilder()
                            .WithRegex(@"")//??? >\n\n(.*?)\n
                            .WithRegexOptions(RegexOptions.Singleline)
                            .Build())
                        .WithPart(new ScrapeCriteriaPartBuilder()
                            .WithRegex(@"")//??? href=.(.*?).
                            .WithRegexOptions(RegexOptions.Singleline)
                            .Build())
                        .Build();

                    Scraper scraper = new Scraper();

                    var scrapedElements = scraper.Scrape(scrapeCriteria);

                    if (scrapedElements.Any())
                    {
                        foreach (var scrapedElement in scrapedElements)
                            Console.WriteLine(scrapedElement);
                    }
                    else
                        Console.WriteLine("No matches!");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
