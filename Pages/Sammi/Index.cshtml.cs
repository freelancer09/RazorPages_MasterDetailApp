using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PDMasterDetail.Data;
using PDMasterDetail.Models;

namespace PDMasterDetail.Pages.Sammi
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

        public async Task OnGetAsync()
        {
            if (_context.SCP != null)
            {
                SCP = await _context.SCP.ToListAsync();
            }
        }
    }
}
