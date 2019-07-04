using System;
using System.Net;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebScrapper.Builders;
using WebScrapper.Data;
using WebScrapper.Workers;

namespace ScraperTest
{
    [TestClass]
    public class UnitTest1
    {
        private readonly Scraper _scraper = new Scraper();


        [TestMethod]
        public void FindCollection()
        {
            using (WebClient client = new WebClient())
            {
                string content = client.DownloadString($"https://www.finn.no/job/fulltime/search.html?occupation=0.23");

                ScrapeCriteria scrapeCriteria = new ScrapeCriteriaBuilder()
                .WithData(content)
                .WithRegex(@"DOC")
                .WithRegexOptions(RegexOptions.ExplicitCapture)
                .Build();

                var foundElements = _scraper.Scrape(scrapeCriteria);

                Assert.IsTrue(foundElements.Count == 1);
                //Assert.IsTrue(foundElements[0] == 1);

            }

        }
    }
}
