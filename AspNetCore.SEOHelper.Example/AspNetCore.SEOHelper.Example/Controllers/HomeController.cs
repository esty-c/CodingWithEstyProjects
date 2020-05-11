using AspNetCore.SEOHelper.Example.Models;
using AspNetCore.SEOHelper.Sitemap;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AspNetCore.SEOHelper.Example.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _env;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        public IActionResult Index()
        {
            string queryString = "Asp.Net MVC Tutorial Part-1";
            var seoQueryString = queryString.ToSEOQueryString();
            var url = $"http://www.example.com/{seoQueryString}";
            _logger.LogInformation(url);
            return View();
        }

        public string CreateSitemapInRootDirectory()
        {
            var list = new List<SitemapNode>();

            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.8, Url = "https://codingwithesty.com/serilog-mongodb-in-asp-net-core", Frequency = SitemapFrequency.Daily });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.8, Url = "https://codingwithesty.com/logging-in-asp-net-core", Frequency = SitemapFrequency.Yearly });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.7, Url = "https://codingwithesty.com/robots-txt-in-asp-net-core", Frequency = SitemapFrequency.Monthly });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.5, Url = "https://codingwithesty.com/versioning-asp.net-core-apiIs-with-swagger", Frequency = SitemapFrequency.Weekly });
            list.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.4, Url = "https://codingwithesty.com/configuring-swagger-asp-net-core-web-api", Frequency = SitemapFrequency.Never });

            new SitemapDocument().CreateSitemapXML(list, _env.ContentRootPath);
            return "sitemap.xml file should be create in root directory";
        }



        public string LoadExistingSitemapAddMoreData()
        {          
            List<SitemapNode> items = new SitemapDocument().LoadFromFile(_env.ContentRootPath);
            items.Add(new SitemapNode { LastModified = DateTime.UtcNow, Priority = 0.4, Url = "https://codingwithesty.com/configuring-swagger-asp-net-core-web-api", Frequency = SitemapFrequency.Never });
            return "use CreateSitemapXML() method to re-write sitemap.xml   ";
        }









        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}