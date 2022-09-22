using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PDMasterDetail.Data;
using PDMasterDetail.Models;

namespace PDMasterDetail.Pages.Doug
{
    public class DeleteModel : PageModel
    {
        private readonly PDMasterDetail.Data.PDMasterDetailContext _context;

        public DeleteModel(PDMasterDetail.Data.PDMasterDetailContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.SCP == null)
            {
                return NotFound();
            }
            var scp = await _context.SCP.FindAsync(id);

            if (scp != null)
            {
                SCP = scp;
                _context.SCP.Remove(SCP);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
