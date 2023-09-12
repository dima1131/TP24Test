using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TP24Test.Shared.Models;

namespace TP24Test.Repository.Data
{
    public class TP24Context : DbContext
    {
        public TP24Context()
        {
        }
        public TP24Context(DbContextOptions<TP24Context> options) : base(options)
        {
        }
        
        public virtual DbSet<Invoice> Invoices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("**************");
            }
        }
    }
}
