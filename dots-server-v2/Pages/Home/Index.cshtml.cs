using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dots_server_v2.Data;
using dots_server_v2.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace dots_server_v2.Pages.Home
{
    public class IndexPageModel : PageModel
    {
        private readonly DotsContext _context;
        public IndexPageModel(DotsContext context)
        {
            _context = context;
        }

        public List<Package> PopularPackages { get; set; }
        
        public async Task OnGetAsync()
        {
            PopularPackages = await _context.Packages.AsNoTracking()
                .OrderByDescending(p => p.Rating)
                .Take(15)
                .ToListAsync();
        }
    }
}