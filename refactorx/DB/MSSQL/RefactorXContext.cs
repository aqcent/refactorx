using Microsoft.EntityFrameworkCore;
using refactorx.BL.Models;
using refactorx.DB.MSSQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace refactorx.DB.MSSQL
{
    public class RefactorXContext : DbContext
    {
        public RefactorXContext(DbContextOptions<RefactorXContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<ApplicationEntity> Applications { get; set; }
        public DbSet<ApplicantEntity> Applicants { get; set; }
        public DbSet<CreditManagerEntity> CreditManagers { get; set; }
        public DbSet<BranchBankEntity> BranchBanks { get; set; }
        public DbSet<CurrencyEntity> Currencies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationEntity>()
                .HasIndex(x => x.ApplicationNum)
                .IsUnique();

            modelBuilder.Entity<BranchBankEntity>()
                .HasIndex(x => x.Name)
                .IsUnique();
        }
    }
}
