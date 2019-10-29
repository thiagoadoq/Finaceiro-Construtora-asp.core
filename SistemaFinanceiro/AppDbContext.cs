using Microsoft.EntityFrameworkCore;
using SistemaFinanceiro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaFinanceiro
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Terceiros> Terceiros { get; set; }

        public DbSet<Financeriros> Financeriros { get; set; }

    }
}
