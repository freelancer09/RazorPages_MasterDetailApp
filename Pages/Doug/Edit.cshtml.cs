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

namespace PDMasterDetail.Pages.Doug
{
    public class EditModel : PageModel
    {
        private readonly PDMasterDetail.Data.PDMasterDetailContext _context;

        public EditModel(PDMasterDetail.Data.PDMasterDetailContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SCP SCP { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SCP == null)
            {
                return NotFound();
            }

            var scp =  await _context.SCP.FirstOrDefaultAsync(m => m.ID == id);
            if (scp == null)
            {
                return NotFound();
            }
            SCP = scp;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SCP).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SCPExists(SCP.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SCPExists(int id)
        {
          return _context.SCP.Any(e => e.ID == id);
        }
    }
}
