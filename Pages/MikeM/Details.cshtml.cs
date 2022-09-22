using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PDMasterDetail.Data;
using PDMasterDetail.Models;

namespace PDMasterDetail.Pages.SCPs
{
    public class DetailsModel : PageModel
    {
        private readonly PDMasterDetail.Data.PDMasterDetailContext _context;

        public DetailsModel(PDMasterDetail.Data.PDMasterDetailContext context)
        {
            _context = context;
        }

      public SCP SCP { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SCP == null)
            {
                return NotFound();
            }

            var scp = await _context.SCP.FirstOrDefaultAsync(m => m.ID == id);
            if (scp == null)
            {
                return NotFound();
            }
            else 
            {
                SCP = scp;
            }
            return Page();
        }
    }
}
