using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dots_server_v2.Data;
using dots_server_v2.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace dots_server_v2.Pages.Home
{
    public class IndexPageModel : PageModel
    {
        private readonly DotsContext _context;
        private readonly ILogger<IndexPageModel> _logger;

        public IndexPageModel(DotsContext context, ILogger<IndexPageModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public List<Package> PopularPackages { get; set; }
        
        public async Task OnGetAsync()
        {
            PopularPackages = await _context.Packages.AsNoTracking()
                .Include(p => p.Screenshots)
                .OrderByDescending(p => p.Rating)
                .Where(p => p.Screenshots.Count > 0)
                .Take(15)
                .ToListAsync();
            _logger.LogInformation($"{PopularPackages.Count} package loaded");
        }
    }
}