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
    public class IndexModel : PageModel
    {
        private readonly Sivi2.Models.Sivi2Context _context;

        public IndexModel(Sivi2.Models.Sivi2Context context)
        {
            _context = context;
        }

        public IList<Resume> Resume { get;set; }

        public async Task OnGetAsync()
        {
            Resume = await _context.Resume.ToListAsync();
        }
    }
}
