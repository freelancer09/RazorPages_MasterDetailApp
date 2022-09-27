
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using PDMasterDetail.Models;
using Microsoft.AspNetCore.Mvc;

namespace PDMasterDetail.Pages.Doug
{
    public class IndexModel : PageModel
    {
        private readonly PDMasterDetail.Data.PDMasterDetailContext _context;

        public IndexModel(PDMasterDetail.Data.PDMasterDetailContext context)
        {
            _context = context;
        }

        public IList<SCP> SCP { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? ObjectClass { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? SCPObjectClass { get; set; }
        public string? SCPSort { get; set; }

        /*public async Task OnGetAsync()
        {
            if (_context.SCP != null)
            {
                SCP = await _context.SCP.ToListAsync();
            }
        }*/

        public async Task OnGetAsync(string sortOrder)
        {
            SCPSort = sortOrder;
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.SCP
                                            orderby m.ObjectClass
                                            select m.ObjectClass;

            var scps = from m in _context.SCP
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                scps = scps.Where(s => s.Name.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(SCPObjectClass))
            {
                scps = scps.Where(x => x.ObjectClass == SCPObjectClass);
            }
            if (SCPSort == "desc")
            {
                scps = scps.OrderByDescending(m => m.Name);
            }
            else
            {
                scps = scps.OrderBy(m => m.Name);
            }
            ObjectClass = new SelectList(await genreQuery.Distinct().ToListAsync());
            SCP = await scps.ToListAsync();
        }
    }
}
