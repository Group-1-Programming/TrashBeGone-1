using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrashBeGone.Models;

namespace TrashBeGone.Data
{
    public class TrashBeGoneContext : DbContext
    {
        public TrashBeGoneContext (DbContextOptions<TrashBeGoneContext> options)
            : base(options)
        {
        }

        public DbSet<TrashBeGone.Models.Admin> Admin { get; set; } = default!;

        public DbSet<TrashBeGone.Models.User> User { get; set; } = default!;

        public DbSet<TrashBeGone.Models.Company> Company { get; set; } = default!;

        public DbSet<TrashBeGone.Models.CompanyUser> CompanyUser { get; set; } = default!;
    }
}
