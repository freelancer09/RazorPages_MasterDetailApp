using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using PDMasterDetail.Data;
using PDMasterDetail.Models;
using Microsoft.Extensions.FileProviders;

namespace PDMasterDetail.Pages.SCPs
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
        public string SearchString { get; set; }
        public SelectList SCPClasses { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SCPClass { get; set; }
        public string NameSort { get; set; }
        public string ClassSort { get; set; }


        public async Task OnGetAsync(string sortOrder)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "NameDesc" : "";
            ClassSort = sortOrder == "ClassAsc" ? "ClassDesc" : "ClassAsc";
            IQueryable<string> classQuery = from q in _context.SCP orderby q.ObjectClass select q.ObjectClass;
            var scp = from r in _context.SCP select r;
            if (!string.IsNullOrEmpty(SearchString))
            {
                scp = scp.Where(r => r.Description.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(SCPClass))
            {
                scp = scp.Where(x => x.ObjectClass == SCPClass);
            }
            switch (sortOrder)
            {
                case "NameDesc":
                    scp = scp.OrderByDescending(y => y.Name);
                    break;
                case "ClassDesc":
                    scp = scp.OrderByDescending(y => y.ObjectClass);
                    break;
                case "ClassAsc":
                    scp = scp.OrderBy(y => y.ObjectClass);
                    break;
                default:
                    scp = scp.OrderBy(y => y.Name);
                    break;
            }
            SCPClasses = new SelectList(await classQuery.Distinct().ToListAsync());

            SCP = await scp.ToListAsync();
        }
    }
}
