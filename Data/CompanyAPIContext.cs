using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyAPI.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyAPI.Data
{
    public class CompanyAPIContext : DbContext
    {
        public CompanyAPIContext (DbContextOptions<CompanyAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Company> Company { get; set; } = default!;
		public DbSet<Employee> Employee { get; set; } = default!;
	}
}
