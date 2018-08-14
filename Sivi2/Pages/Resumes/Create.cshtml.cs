using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sivi2.Models;

namespace Sivi2.Pages.Resumes
{
    public class CreateModel : PageModel
    {
        private readonly Sivi2.Models.Sivi2Context _context;

        public CreateModel(Sivi2.Models.Sivi2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Resume Resume { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Resume.Add(Resume);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}