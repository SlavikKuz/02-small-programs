using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebScrapper.Data
{
    class ScrapeCriteria
    {
        public ScrapeCriteria()
        {
            Parts = new List<ScrapeCriteriaParts>();
        }

        public string Data { get; set; } //data that we want to scrape
        public string Regex { get; set; } //how to scrape it
        public RegexOptions RegexOption { get; set; } //how regex need to behave
        public List<ScrapeCriteriaParts> Parts { get; set; } //how deep we will go
    }
}
