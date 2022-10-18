using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using PDMasterDetail.Models;
using Microsoft.AspNetCore.Mvc;

namespace PDMasterDetail.Pages.MikeT
{
    public class IndexModel : PageModel
    {
        private readonly PDMasterDetail.Data.PDMasterDetailContext _context;

        public IndexModel(PDMasterDetail.Data.PDMasterDetailContext context)
        {
            _context = context;
        }

        public IList<SCP> SCP { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? ObjectClass { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? ClassSort { get; set; }
        public string? NameSort { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            NameSort = string.IsNullOrEmpty(sortOrder) ? "desc" : "";


            IQueryable<string> classQuery = from i in _context.SCP orderby i.ObjectClass select i.ObjectClass;

            var SCPinfo = from i in _context.SCP select i;

            if (!string.IsNullOrEmpty(SearchString))
            {
                SCPinfo = SCPinfo.Where(n => n.Name.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(ClassSort))
            {
                SCPinfo = SCPinfo.Where(c => c.ObjectClass == ClassSort);
            }

            switch (sortOrder)
            {
                case "desc":
                    SCPinfo = SCPinfo.OrderByDescending(i => i.Name);
                    break;
                default:
                    SCPinfo = SCPinfo.OrderBy(i => i.Name);
                    break;
            }

            ObjectClass = new SelectList(await classQuery.Distinct().ToListAsync());
            SCP = await SCPinfo.ToListAsync();

            //SCP = await SCPs.ToListAsync();
        }
    }
}
