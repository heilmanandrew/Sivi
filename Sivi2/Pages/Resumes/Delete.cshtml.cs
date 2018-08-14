using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sivi2.Models;

namespace Sivi2.Pages.Resumes
{
    public class DeleteModel : PageModel
    {
        private readonly Sivi2.Models.Sivi2Context _context;

        public DeleteModel(Sivi2.Models.Sivi2Context context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Resume = await _context.Resume.FindAsync(id);

            if (Resume != null)
            {
                _context.Resume.Remove(Resume);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
