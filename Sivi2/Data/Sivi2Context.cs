using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sivi2.Models
{
    public class Sivi2Context : DbContext
    {
        public Sivi2Context (DbContextOptions<Sivi2Context> options)
            : base(options)
        {
        }

        public DbSet<Sivi2.Models.Resume> Resume { get; set; }
    }
}
