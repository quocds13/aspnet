using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace aspnet.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly MyBlockContext _context;
        public IndexModel(ILogger<IndexModel> logger, MyBlockContext dbcontext)
        {
            _logger = logger;
            _context = dbcontext;
        }

        public void OnGet()
        {
            var articles = (from a in _context.Articles
                            orderby a.PublishDate descending
                            select a).ToList();
            ViewData["articles"] = articles;
        }
    }
}
