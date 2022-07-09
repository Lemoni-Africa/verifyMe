using System;
using Microsoft.EntityFrameworkCore;
using VerifyMeIntegration.Models;

namespace VerifyMeIntegration.Data
{
    public class VerifyMeDataContext: DbContext
    {
        public VerifyMeDataContext(DbContextOptions<VerifyMeDataContext> options) : base(options) { }

        public DbSet<AddressVerification> AddressVerification { get; set; }
        public DbSet<IdentityVerification> IdentityVerification { get; set; }
        public DbSet<GuarantorVerification> GuarantorVerification { get; set; }
        public DbSet<EmploymentVerification> EmploymentVerification { get; set; }
        public DbSet<ApiCalls> ApiCalls { get; set; }
        //public DbSet<TransactionsHistoryView> TransactionsHistoryView { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            /*modelBuilder
                .Entity<TransactionsHistoryView>(
                    eb =>
                    {
                        eb.HasNoKey();
                        eb.ToView("transaction_history_view");
                    });*/

            modelBuilder.Entity<ApiCalls>().HasKey("Id");
            modelBuilder.Entity<ApiCalls>().HasIndex("ResourceName");
            modelBuilder.Entity<ApiCalls>().Property(x => x.CallTime).HasColumnType("datetime2").HasDefaultValue(DateTime.Now);


            modelBuilder.Entity<EmploymentVerification>().HasKey("Id");
            modelBuilder.Entity<EmploymentVerification>().HasIndex("ApplicantFirstname");
            modelBuilder.Entity<EmploymentVerification>().HasIndex("ApplicantLastname");
            modelBuilder.Entity<EmploymentVerification>().HasIndex("ApplicantIdNumber");
            modelBuilder.Entity<EmploymentVerification>().HasIndex("ApplicationId");
            modelBuilder.Entity<EmploymentVerification>().HasIndex(p => new { p.ApplicantFirstname, p.ApplicantLastname, p.ApplicantDob });
            modelBuilder.Entity<EmploymentVerification>().Property(x => x.CreatedAt).HasColumnType("datetime2").IsRequired(true).HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<EmploymentVerification>().Property(x => x.UpdatedAt).HasColumnType("datetime2").IsRequired(true).HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<GuarantorVerification>().HasKey("Id");
            modelBuilder.Entity<GuarantorVerification>().HasIndex("Firstname");
            modelBuilder.Entity<GuarantorVerification>().HasIndex("Lastname");
            modelBuilder.Entity<GuarantorVerification>().HasIndex("Email");
            modelBuilder.Entity<GuarantorVerification>().HasIndex(p => new { p.Firstname, p.Lastname });
            modelBuilder.Entity<GuarantorVerification>().HasIndex("ApplicationId");
            modelBuilder.Entity<GuarantorVerification>().Property(x => x.CreatedAt).HasColumnType("datetime2").IsRequired(true).HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<GuarantorVerification>().Property(x => x.UpdatedAt).HasColumnType("datetime2").IsRequired(true).HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<IdentityVerification>().HasKey("Id");
            modelBuilder.Entity<IdentityVerification>().HasIndex("IdType");
            modelBuilder.Entity<IdentityVerification>().HasIndex("IdReference");
            modelBuilder.Entity<IdentityVerification>().HasIndex("ApplicationId");
            modelBuilder.Entity<IdentityVerification>().Property(x => x.ExpiryDate).HasColumnType("date");
            modelBuilder.Entity<IdentityVerification>().Property(x => x.CreatedAt).HasColumnType("datetime2").IsRequired(true).HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<IdentityVerification>().Property(x => x.UpdatedAt).HasColumnType("datetime2").IsRequired(true).HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<AddressVerification>().HasIndex("IdNumber");
            modelBuilder.Entity<AddressVerification>().HasIndex("ApplicationId");
            modelBuilder.Entity<AddressVerification>().HasKey("Id");
            modelBuilder.Entity<AddressVerification>().Property(x => x.CreatedAt).HasColumnType("datetime2").IsRequired(true).HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<AddressVerification>().Property(x => x.UpdatedAt).HasColumnType("datetime2").IsRequired(true).HasDefaultValue(DateTime.Now);

            base.OnModelCreating(modelBuilder);

        }
     }
}
