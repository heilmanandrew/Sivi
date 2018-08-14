using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sivi2.Models;

namespace Sivi2.Pages.Resumes
{
    public class EditModel : PageModel
    {
        private readonly Sivi2.Models.Sivi2Context _context;

        public EditModel(Sivi2.Models.Sivi2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Resume Resume { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Resume = await _context.Resume.FirstOrDefaultAsync(m => m.Id == id);

            if (Resume == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Resume).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResumeExists(Resume.Id))
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

        private bool ResumeExists(int id)
        {
            return _context.Resume.Any(e => e.Id == id);
        }
    }
}
