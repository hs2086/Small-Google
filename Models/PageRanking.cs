using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Page
{
    public class PageRanking
    {
        [Key]
        public string Url { get; set; }
        public double Rank { get; set; }
        public int InGoing { get; set; }
        public int OutGoing { get; set; }
    }
}
