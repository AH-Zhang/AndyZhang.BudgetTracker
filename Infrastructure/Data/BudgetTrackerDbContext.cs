using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class BudgetTrackerDbContext: DbContext
    {
        public BudgetTrackerDbContext(DbContextOptions<BudgetTrackerDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(ConfigureUser);
            modelBuilder.Entity<Income>(ConfigureIncome);
            modelBuilder.Entity<Expenditure>(ConfigureExpenditure);
        }

        private void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Email).HasMaxLength(50).IsRequired();
            builder.Property(m => m.Password).HasMaxLength(10).IsRequired();
            builder.Property(m => m.Fullname).HasMaxLength(50);
        }

        private void ConfigureIncome(EntityTypeBuilder<Income> builder)
        {
            builder.ToTable("Incomes");
            builder.HasKey(m => m.Id);
            builder.HasOne(m => m.User).WithMany(m => m.Incomes).HasForeignKey(m => m.UserId);
            builder.Property(m => m.Amount).HasColumnType("money");
            builder.Property(m => m.Description).HasMaxLength(100).IsRequired();
            builder.Property(m => m.Remarks).HasMaxLength(500);
        }

        private void ConfigureExpenditure(EntityTypeBuilder<Expenditure> builder)
        {
            builder.ToTable("Expenditures");
            builder.HasKey(m => m.Id);
            builder.HasOne(m => m.User).WithMany(m => m.Expenditures).HasForeignKey(m => m.UserId);
            builder.Property(m => m.Amount).HasColumnType("money");
            builder.Property(m => m.Description).HasMaxLength(100).IsRequired();
            builder.Property(m => m.Remarks).HasMaxLength(500);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Expenditure> Expenditures { get; set; }
        public DbSet<Income> Incomes { get; set; }
    }
}
