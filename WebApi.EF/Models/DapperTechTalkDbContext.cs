using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApi.EF.Models
{
    public partial class DapperTechTalkDbContext : DbContext
    {
        public DapperTechTalkDbContext()
        {
        }

        public DapperTechTalkDbContext(DbContextOptions<DapperTechTalkDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<BankAccount> BankAccounts { get; set; } = null!;
        public virtual DbSet<Compensation> Compensations { get; set; } = null!;
        public virtual DbSet<CompensationPosition> CompensationPositions { get; set; } = null!;
        public virtual DbSet<Contractor> Contractors { get; set; } = null!;
        public virtual DbSet<CostsOnInvestmentsVw> CostsOnInvestmentsVws { get; set; } = null!;
        public virtual DbSet<FinancialYear> FinancialYears { get; set; } = null!;
        public virtual DbSet<Firm> Firms { get; set; } = null!;
        public virtual DbSet<Investment> Investments { get; set; } = null!;
        public virtual DbSet<InvestmentType> InvestmentTypes { get; set; } = null!;
        public virtual DbSet<MeasurementUnit> MeasurementUnits { get; set; } = null!;
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;
        public virtual DbSet<PurchaseInvoice> PurchaseInvoices { get; set; } = null!;
        public virtual DbSet<PurchaseInvoicePayment> PurchaseInvoicePayments { get; set; } = null!;
        public virtual DbSet<PurchaseInvoicePosition> PurchaseInvoicePositions { get; set; } = null!;
        public virtual DbSet<PurchaseInvoicePositionsVw> PurchaseInvoicePositionsVws { get; set; } = null!;
        public virtual DbSet<SellInvoice> SellInvoices { get; set; } = null!;
        public virtual DbSet<SellInvoicePayment> SellInvoicePayments { get; set; } = null!;
        public virtual DbSet<SellInvoicePosition> SellInvoicePositions { get; set; } = null!;
        public virtual DbSet<SellInvoicePositionsVw> SellInvoicePositionsVws { get; set; } = null!;
        public virtual DbSet<SettlementAnalysisVw> SettlementAnalysisVws { get; set; } = null!;
        public virtual DbSet<Subscription> Subscriptions { get; set; } = null!;
        public virtual DbSet<UnpaidPurchaseInvoicesVw> UnpaidPurchaseInvoicesVws { get; set; } = null!;
        public virtual DbSet<UnpaidSellInvoicesVw> UnpaidSellInvoicesVws { get; set; } = null!;
        public virtual DbSet<UserFirm> UserFirms { get; set; } = null!;
        public virtual DbSet<UserSubscription> UserSubscriptions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=InvoiceOffice.Api;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("AspNetUserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<BankAccount>(entity =>
            {
                entity.Property(e => e.BankAccountCode).HasMaxLength(50);

                entity.Property(e => e.BankAccountName).HasMaxLength(300);

                entity.Property(e => e.BankAccountNumber).HasMaxLength(50);

                entity.Property(e => e.BankName).HasMaxLength(300);
            });

            modelBuilder.Entity<Compensation>(entity =>
            {
                entity.HasIndex(e => new { e.Id, e.ContractorId }, "IX_Compensations_IdContractorId")
                    .IsUnique();

                entity.Property(e => e.CompensationDate).HasColumnType("date");

                entity.Property(e => e.CompensationNumber).HasMaxLength(50);

                entity.HasOne(d => d.FinancialYear)
                    .WithMany(p => p.Compensations)
                    .HasForeignKey(d => d.FinancialYearId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Compensations_FinancialYears");

                entity.HasOne(d => d.Firm)
                    .WithMany(p => p.Compensations)
                    .HasForeignKey(d => d.FirmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Compensations_Firms");
            });

            modelBuilder.Entity<CompensationPosition>(entity =>
            {
                entity.Property(e => e.Value).HasColumnType("decimal(16, 2)");

                entity.HasOne(d => d.Co)
                    .WithMany(p => p.CompensationPositions)
                    .HasPrincipalKey(p => new { p.Id, p.ContractorId })
                    .HasForeignKey(d => new { d.CompensationId, d.ContractorId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompensationPositions_Compansations");

                entity.HasOne(d => d.PurchaseInvoice)
                    .WithMany(p => p.CompensationPositions)
                    .HasPrincipalKey(p => new { p.Id, p.ContractorId })
                    .HasForeignKey(d => new { d.PurchaseInvoiceId, d.ContractorId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompensationPositions_PurchaseInvoices");

                entity.HasOne(d => d.SellInvoice)
                    .WithMany(p => p.CompensationPositions)
                    .HasPrincipalKey(p => new { p.Id, p.ContractorId })
                    .HasForeignKey(d => new { d.SellInvoiceId, d.ContractorId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompensationPositions_SellInvoices");
            });

            modelBuilder.Entity<Contractor>(entity =>
            {
                entity.Property(e => e.ApartmentNumber).HasMaxLength(8);

                entity.Property(e => e.BankAccountNumber).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.ContractorCode).HasMaxLength(50);

                entity.Property(e => e.ContractorName).HasMaxLength(300);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.HomeNumber).HasMaxLength(8);

                entity.Property(e => e.Nip).HasColumnName("NIP");

                entity.Property(e => e.Street).HasMaxLength(100);

                entity.Property(e => e.ZipNumber).HasMaxLength(10);

                entity.HasOne(d => d.Firm)
                    .WithMany(p => p.Contractors)
                    .HasForeignKey(d => d.FirmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contractors_Firms");
            });

            modelBuilder.Entity<CostsOnInvestmentsVw>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("CostsOnInvestments_vw");

                entity.Property(e => e.ContractorCode).HasMaxLength(50);

                entity.Property(e => e.GrossValue).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.InvestmentNumber).HasMaxLength(300);

                entity.Property(e => e.InvestmentTypeCode).HasMaxLength(50);

                entity.Property(e => e.NetValue).HasColumnType("numeric(38, 7)");

                entity.Property(e => e.PurchaseInvoiceDate).HasColumnType("date");

                entity.Property(e => e.PurchaseInvoiceInnerNumber).HasMaxLength(50);

                entity.Property(e => e.PurchaseInvoiceNumber).HasMaxLength(50);

                entity.Property(e => e.PurchaseInvoicePositionDescription).HasMaxLength(1000);

                entity.Property(e => e.VatValue).HasColumnType("numeric(38, 6)");
            });

            modelBuilder.Entity<FinancialYear>(entity =>
            {
                entity.Property(e => e.FinancialYearName).HasMaxLength(50);

                entity.HasOne(d => d.Firm)
                    .WithMany(p => p.FinancialYears)
                    .HasForeignKey(d => d.FirmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FinancialYears_Firms");
            });

            modelBuilder.Entity<Firm>(entity =>
            {
                entity.Property(e => e.ApartmentNumber).HasMaxLength(8);

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.HomeNumber).HasMaxLength(8);

                entity.Property(e => e.Krs).HasColumnName("KRS");

                entity.Property(e => e.NameFull).HasMaxLength(300);

                entity.Property(e => e.NameShort).HasMaxLength(50);

                entity.Property(e => e.Nip).HasColumnName("NIP");

                entity.Property(e => e.Street).HasMaxLength(100);

                entity.Property(e => e.ZipCode).HasMaxLength(10);
            });

            modelBuilder.Entity<Investment>(entity =>
            {
                entity.Property(e => e.ContractNumber).HasMaxLength(300);

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.InvestmentNumber).HasMaxLength(300);

                entity.HasOne(d => d.Firm)
                    .WithMany(p => p.Investments)
                    .HasForeignKey(d => d.FirmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Investments_Firms");

                entity.HasOne(d => d.InvestmentType)
                    .WithMany(p => p.Investments)
                    .HasPrincipalKey(p => new { p.Id, p.FirmId })
                    .HasForeignKey(d => new { d.InvestmentTypeId, d.FirmId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Investments_InvestmentTypes");
            });

            modelBuilder.Entity<InvestmentType>(entity =>
            {
                entity.HasIndex(e => e.FirmId, "InvestmentTypesIsDefault")
                    .IsUnique()
                    .HasFilter("([IsDefault]=(1))");

                entity.HasIndex(e => new { e.Id, e.FirmId }, "UK_InvestmentTypes_Id_FirmId")
                    .IsUnique();

                entity.Property(e => e.InvestmentTypeCode).HasMaxLength(50);

                entity.Property(e => e.InvestmentTypeName).HasMaxLength(300);

                entity.HasOne(d => d.Firm)
                    .WithOne(p => p.InvestmentType)
                    .HasForeignKey<InvestmentType>(d => d.FirmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvestmentTypes_Firms");
            });

            modelBuilder.Entity<MeasurementUnit>(entity =>
            {
                entity.HasIndex(e => e.FirmId, "MeasurementUnitsIsDefault")
                    .IsUnique()
                    .HasFilter("([IsDefault]=(1))");

                entity.Property(e => e.MeasurementUnitCode).HasMaxLength(50);

                entity.Property(e => e.MeasurementUnitName).HasMaxLength(300);

                entity.HasOne(d => d.Firm)
                    .WithOne(p => p.MeasurementUnit)
                    .HasForeignKey<MeasurementUnit>(d => d.FirmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MeasurementUnits_Firms");
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.HasIndex(e => e.FirmId, "PaymentMethodsIsDefault")
                    .IsUnique()
                    .HasFilter("([IsDefault]=(1))");

                entity.Property(e => e.PaymentMethodCode).HasMaxLength(50);

                entity.Property(e => e.PaymentMethodName).HasMaxLength(300);

                entity.HasOne(d => d.Firm)
                    .WithOne(p => p.PaymentMethod)
                    .HasForeignKey<PaymentMethod>(d => d.FirmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaymentMethods_Firms");
            });

            modelBuilder.Entity<PurchaseInvoice>(entity =>
            {
                entity.HasIndex(e => new { e.Id, e.ContractorId }, "IX_PurchaseInvoices_IdContractorId")
                    .IsUnique();

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.InnerInvoiceNumber).HasMaxLength(50);

                entity.Property(e => e.InvoiceDate).HasColumnType("date");

                entity.Property(e => e.InvoiceNumber).HasMaxLength(50);

                entity.Property(e => e.PaymentDate).HasColumnType("date");

                entity.Property(e => e.PurchaseDate).HasColumnType("date");

                entity.HasOne(d => d.Contractor)
                    .WithMany(p => p.PurchaseInvoices)
                    .HasForeignKey(d => d.ContractorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchaseInvoices_Contractors");

                entity.HasOne(d => d.FinancialYear)
                    .WithMany(p => p.PurchaseInvoices)
                    .HasForeignKey(d => d.FinancialYearId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchaseInvoices_FinancialYears");

                entity.HasOne(d => d.Firm)
                    .WithMany(p => p.PurchaseInvoices)
                    .HasForeignKey(d => d.FirmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchaseInvoices_Firms");
            });

            modelBuilder.Entity<PurchaseInvoicePayment>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.PaymentDate).HasColumnType("date");

                entity.Property(e => e.Value).HasColumnType("decimal(16, 2)");

                entity.HasOne(d => d.PurchaseInvoice)
                    .WithMany(p => p.PurchaseInvoicePayments)
                    .HasForeignKey(d => d.PurchaseInvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchaseInvoicePayments_PurchaseInvoices");
            });

            modelBuilder.Entity<PurchaseInvoicePosition>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(16, 2)");

                entity.HasOne(d => d.Investment)
                    .WithMany(p => p.PurchaseInvoicePositions)
                    .HasForeignKey(d => d.InvestmentId)
                    .HasConstraintName("FK_PurchaseInvoicePositions_Investments");

                entity.HasOne(d => d.MeasurementUnit)
                    .WithMany(p => p.PurchaseInvoicePositions)
                    .HasForeignKey(d => d.MeasurementUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchaseInvoicePositions_MeasurementUnits");

                entity.HasOne(d => d.PurchaseInvoice)
                    .WithMany(p => p.PurchaseInvoicePositions)
                    .HasForeignKey(d => d.PurchaseInvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchaseInvoicePositions_PurchaseInvoices");
            });

            modelBuilder.Entity<PurchaseInvoicePositionsVw>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("PurchaseInvoicePositions_vw");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.GrossValue).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.NetValue).HasColumnType("numeric(38, 7)");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.VatValue).HasColumnType("numeric(38, 6)");
            });

            modelBuilder.Entity<SellInvoice>(entity =>
            {
                entity.HasIndex(e => new { e.Id, e.ContractorId }, "IX_SellInvoices_IdContractorId")
                    .IsUnique();

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.InvoiceDate).HasColumnType("date");

                entity.Property(e => e.InvoiceNumber).HasMaxLength(50);

                entity.Property(e => e.PaymentDate).HasColumnType("date");

                entity.Property(e => e.SellDate).HasColumnType("date");

                entity.HasOne(d => d.BankAccount)
                    .WithMany(p => p.SellInvoices)
                    .HasForeignKey(d => d.BankAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SellInvoices_BankAccounts");

                entity.HasOne(d => d.Contractor)
                    .WithMany(p => p.SellInvoices)
                    .HasForeignKey(d => d.ContractorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SellInvoices_Contractors");

                entity.HasOne(d => d.CorrectionInvoice)
                    .WithMany(p => p.InverseCorrectionInvoice)
                    .HasForeignKey(d => d.CorrectionInvoiceId)
                    .HasConstraintName("FK_SellInvoices_SellInvoices");

                entity.HasOne(d => d.FinancialYear)
                    .WithMany(p => p.SellInvoices)
                    .HasForeignKey(d => d.FinancialYearId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SellInvoices_FinancialYears");

                entity.HasOne(d => d.Firm)
                    .WithMany(p => p.SellInvoices)
                    .HasForeignKey(d => d.FirmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SellInvoices_Firms");

                entity.HasOne(d => d.Investment)
                    .WithMany(p => p.SellInvoices)
                    .HasForeignKey(d => d.InvestmentId)
                    .HasConstraintName("FK_SellInvoices_Investments");
            });

            modelBuilder.Entity<SellInvoicePayment>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.PaymentDate).HasColumnType("date");

                entity.Property(e => e.Value).HasColumnType("decimal(16, 2)");

                entity.HasOne(d => d.SellInvoice)
                    .WithMany(p => p.SellInvoicePayments)
                    .HasForeignKey(d => d.SellInvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SellInvoicePayments_SellInvoices");
            });

            modelBuilder.Entity<SellInvoicePosition>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(16, 2)");

                entity.HasOne(d => d.MeasurementUnit)
                    .WithMany(p => p.SellInvoicePositions)
                    .HasForeignKey(d => d.MeasurementUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SellInvoicePositions_MeasurementUnits");

                entity.HasOne(d => d.SellInvoice)
                    .WithMany(p => p.SellInvoicePositions)
                    .HasForeignKey(d => d.SellInvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SellInvoicePositions_SellInvoices");
            });

            modelBuilder.Entity<SellInvoicePositionsVw>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("SellInvoicePositions_vw");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.GrossValue).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.NetValue).HasColumnType("numeric(38, 7)");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.VatValue).HasColumnType("numeric(38, 6)");
            });

            modelBuilder.Entity<SettlementAnalysisVw>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("SettlementAnalysis_vw");

                entity.Property(e => e.ContractorCode).HasMaxLength(50);

                entity.Property(e => e.Has).HasColumnType("numeric(38, 6)");

                entity.Property(e => e.InvoiceDate).HasColumnType("date");

                entity.Property(e => e.InvoiceNumber).HasMaxLength(50);

                entity.Property(e => e.Key).HasMaxLength(32);

                entity.Property(e => e.Owing).HasColumnType("numeric(38, 6)");

                entity.Property(e => e.PaymentDate).HasColumnType("date");
            });

            modelBuilder.Entity<Subscription>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(300);

                entity.Property(e => e.PricePerMonth).HasColumnType("decimal(16, 2)");
            });

            modelBuilder.Entity<UnpaidPurchaseInvoicesVw>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("UnpaidPurchaseInvoices_vw");

                entity.Property(e => e.CompensatedValue).HasColumnType("decimal(38, 2)");

                entity.Property(e => e.ContractorCode).HasMaxLength(50);

                entity.Property(e => e.GrossValue).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.InvoiceDate).HasColumnType("date");

                entity.Property(e => e.InvoiceNumber).HasMaxLength(50);

                entity.Property(e => e.PaidValue).HasColumnType("decimal(38, 2)");

                entity.Property(e => e.PaymentDate).HasColumnType("date");

                entity.Property(e => e.UnpaidValue).HasColumnType("decimal(38, 2)");
            });

            modelBuilder.Entity<UnpaidSellInvoicesVw>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("UnpaidSellInvoices_vw");

                entity.Property(e => e.CompensatedValue).HasColumnType("decimal(38, 2)");

                entity.Property(e => e.ContractorCode).HasMaxLength(50);

                entity.Property(e => e.GrossValue).HasColumnType("decimal(38, 6)");

                entity.Property(e => e.InvestmentNumber).HasMaxLength(300);

                entity.Property(e => e.InvoiceDate).HasColumnType("date");

                entity.Property(e => e.InvoiceNumber).HasMaxLength(50);

                entity.Property(e => e.PaidValue).HasColumnType("decimal(38, 2)");

                entity.Property(e => e.PaymentDate).HasColumnType("date");

                entity.Property(e => e.UnpaidValue).HasColumnType("decimal(38, 2)");
            });

            modelBuilder.Entity<UserFirm>(entity =>
            {
                entity.Property(e => e.AspNetUserId).HasMaxLength(450);

                entity.HasOne(d => d.AspNetUser)
                    .WithMany(p => p.UserFirms)
                    .HasForeignKey(d => d.AspNetUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserFirms_AspNetUsers");

                entity.HasOne(d => d.Firm)
                    .WithMany(p => p.UserFirms)
                    .HasForeignKey(d => d.FirmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserFirms_Firms");
            });

            modelBuilder.Entity<UserSubscription>(entity =>
            {
                entity.HasIndex(e => e.AspNetUserId, "IX_UserSubscriptions_AspNetUserId")
                    .IsUnique();

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.DateTo).HasColumnType("datetime");

                entity.HasOne(d => d.AspNetUser)
                    .WithOne(p => p.UserSubscription)
                    .HasForeignKey<UserSubscription>(d => d.AspNetUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserSubscriptions_AspNetUsers");

                entity.HasOne(d => d.Subscription)
                    .WithMany(p => p.UserSubscriptions)
                    .HasForeignKey(d => d.SubscriptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserSubscriptions_Subscriptions");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
