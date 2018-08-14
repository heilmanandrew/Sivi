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
    public class DetailsModel : PageModel
    {
        private readonly Sivi2.Models.Sivi2Context _context;

        public DetailsModel(Sivi2.Models.Sivi2Context context)
        {
            _context = context;
        }

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
    }
}
