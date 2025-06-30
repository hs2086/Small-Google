using BigDataProject.Models;
using BigDataProject.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Page;
using System.Runtime.InteropServices;

namespace BigDataProject.Controllers
{
    public class SearchController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Search/GetData/{searchTerm}")]
        public IActionResult GetData(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return Json(new List<string>()); // return empty list
            }

            string term = searchTerm.Trim().ToLower();

            List<string> names = _context.Results
                .Where(x => x.Word.ToLower().StartsWith(term) && x.Word.Length < 21)
                .Select(x => x.Word)
                .Take(10)
                .ToList();

            return Json(names);
        }

        [HttpGet("Search/Details")]
        public IActionResult Details(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return BadRequest("Search term cannot be empty.");

            var result1 = _context.Results.FirstOrDefault(x => x.Word.ToLower() == searchTerm.ToLower());
            if (result1 == null)
                return NotFound($"No result found for '{searchTerm}'.");

            Decode decode = new Decode();
            FrontDataVM frontData = new FrontDataVM
            {
                Word = result1.Word,
                LinksNormal = new List<string>(),
                FreqsNarmal = new List<string>(),
                LinksRank = new List<string>(),
                FreqsRank = new List<string>()
            };

            var urlProps = new[] { result1.Url1, result1.Url2, result1.Url3, result1.Url4, result1.Url5, result1.Url6, result1.Url7, result1.Url8, result1.Url9, result1.Url10 };

            foreach (var url in urlProps)
            {
                if (!string.IsNullOrWhiteSpace(url))
                {
                    var parts = url.Split("|||");
                    if (parts.Length == 2)
                    {
                        string cleanUrl = decode.SanitizeUrl(RemoveExtension(parts[0]));
                        frontData.LinksNormal.Add(cleanUrl);
                        frontData.FreqsNarmal.Add(parts[1]);
                    }
                }
            }


            var pageRankings = _context.PageRankings
                .Where(p => frontData.LinksNormal.Contains(p.Url))
                .OrderByDescending(p => p.Rank)
                .ThenBy(p => p.InGoing)
                .ToList();

            foreach (var pr in pageRankings)
            {
                frontData.LinksRank.Add(pr.Url);
                frontData.FreqsRank.Add(pr.Rank.ToString("G"));
            }

            foreach (var pr in frontData.LinksNormal)
            {
                if (frontData.LinksRank.IndexOf(pr) == -1)
                {
                    frontData.LinksRank.Add(pr);
                    frontData.FreqsRank.Add("0");
                }
            }

            return View(frontData);
            string RemoveExtension(string url)
            {
                int dotIndex = url.LastIndexOf('.');
                return dotIndex > 0 ? url.Substring(0, dotIndex) : url;
            }
        }

    }
}
