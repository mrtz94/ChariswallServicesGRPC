using System;
using System.Collections.Generic;
using ChariswallNewDomain.Models;
using Microsoft.EntityFrameworkCore;

namespace ChariswallNewDomain.Context;

public partial class ChariswallDemoDbContext : DbContext
{
    public ChariswallDemoDbContext()
    {
    }

    public ChariswallDemoDbContext(DbContextOptions<ChariswallDemoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ActiveSystem> ActiveSystems { get; set; }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<BankBranch> BankBranches { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Credit> Credits { get; set; }

    public virtual DbSet<CurrencyEquivalent> CurrencyEquivalents { get; set; }

    public virtual DbSet<CurrencySymbol> CurrencySymbols { get; set; }

    public virtual DbSet<CustomerRepresentative> CustomerRepresentatives { get; set; }

    public virtual DbSet<CustomerTradeType> CustomerTradeTypes { get; set; }

    public virtual DbSet<CustomerType> CustomerTypes { get; set; }

    public virtual DbSet<CustomerUser> CustomerUsers { get; set; }

    public virtual DbSet<DealType> DealTypes { get; set; }

    public virtual DbSet<DestinationBank> DestinationBanks { get; set; }

    public virtual DbSet<EndDuration> EndDurations { get; set; }

    public virtual DbSet<ExchangeBankAccount> ExchangeBankAccounts { get; set; }

    public virtual DbSet<ExchangeCustomer> ExchangeCustomers { get; set; }

    public virtual DbSet<ExpertLevel> ExpertLevels { get; set; }

    public virtual DbSet<ExportType> ExportTypes { get; set; }

    public virtual DbSet<Industry> Industries { get; set; }

    public virtual DbSet<NimaBank> NimaBanks { get; set; }

    public virtual DbSet<NimaBankAccount> NimaBankAccounts { get; set; }

    public virtual DbSet<NimaDeal> NimaDeals { get; set; }

    public virtual DbSet<NimaDealActive> NimaDealActives { get; set; }

    public virtual DbSet<NimaDealLog> NimaDealLogs { get; set; }

    public virtual DbSet<NimaDealPayment> NimaDealPayments { get; set; }

    public virtual DbSet<NimaOffer> NimaOffers { get; set; }

    public virtual DbSet<NimaOfferActive> NimaOfferActives { get; set; }

    public virtual DbSet<NimaOfferLog> NimaOfferLogs { get; set; }

    public virtual DbSet<NimaOfferPayment> NimaOfferPayments { get; set; }

    public virtual DbSet<NimaOfferPo> NimaOfferPos { get; set; }

    public virtual DbSet<NimaOfferState> NimaOfferStates { get; set; }

    public virtual DbSet<NimaPaymentStatus> NimaPaymentStatuses { get; set; }

    public virtual DbSet<NimaRateType> NimaRateTypes { get; set; }

    public virtual DbSet<NimaRequestState> NimaRequestStates { get; set; }

    public virtual DbSet<NimaRequestType> NimaRequestTypes { get; set; }

    public virtual DbSet<NimaTransferType> NimaTransferTypes { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<PaymentTool> PaymentTools { get; set; }

    public virtual DbSet<RegistererType> RegistererTypes { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<RequestActive> RequestActives { get; set; }

    public virtual DbSet<RequestLog> RequestLogs { get; set; }

    public virtual DbSet<RialPaymentMethod> RialPaymentMethods { get; set; }

    public virtual DbSet<SanaAction> SanaActions { get; set; }

    public virtual DbSet<SanaHeading> SanaHeadings { get; set; }

    public virtual DbSet<SanaOrder> SanaOrders { get; set; }

    public virtual DbSet<SanaOrderLog> SanaOrderLogs { get; set; }

    public virtual DbSet<SanaOrderReason> SanaOrderReasons { get; set; }

    public virtual DbSet<SanaPayment> SanaPayments { get; set; }

    public virtual DbSet<SanaSource> SanaSources { get; set; }

    public virtual DbSet<SanaState> SanaStates { get; set; }

    public virtual DbSet<Supply> Supplies { get; set; }

    public virtual DbSet<SupplyActive> SupplyActives { get; set; }

    public virtual DbSet<SupplyLog> SupplyLogs { get; set; }

    public virtual DbSet<SystemConfig> SystemConfigs { get; set; }

    public virtual DbSet<Trusty> Trusties { get; set; }

    public virtual DbSet<UserAction> UserActions { get; set; }

    public virtual DbSet<ValidityCheck> ValidityChecks { get; set; }

    public virtual DbSet<Xerate> Xerates { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=10.20.22.99; Initial Catalog=ChariswallTestDB; User ID=admin; Password=abc.1234;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActiveSystem>(entity =>
        {
            entity.ToTable("ActiveSystem");

            entity.Property(e => e.Etitle)
                .HasMaxLength(50)
                .HasColumnName("ETitle");
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.Property(e => e.RoleId).HasMaxLength(450);

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.Property(e => e.ContactEmail)
                .HasMaxLength(100)
                .HasDefaultValueSql("(N'')");
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.InsideCompanyLine)
                .HasMaxLength(10)
                .HasDefaultValueSql("(N'')");
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.OfficeNumber).HasMaxLength(50);
            entity.Property(e => e.SanaUserCode).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.Property(e => e.UserId).HasMaxLength(450);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.Property(e => e.UserId).HasMaxLength(450);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<BankBranch>(entity =>
        {
            entity.ToTable("BankBranch");

            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("Country");

            entity.HasIndex(e => e.Ftitle, "UniqueFTitle").IsUnique();

            entity.Property(e => e.Enable)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.Etitle)
                .HasMaxLength(50)
                .HasColumnName("ETitle");
            entity.Property(e => e.Ftitle)
                .HasMaxLength(50)
                .HasColumnName("FTitle");
        });

        modelBuilder.Entity<Credit>(entity =>
        {
            entity.HasKey(e => e.ServerDateTime);

            entity.ToTable("Credit");

            entity.Property(e => e.ServerDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasComment("تاریخ و زمان سرور")
                .HasColumnType("datetime");
            entity.Property(e => e.CreditAmount).HasComment("اعتبار");
            entity.Property(e => e.CreditInUse).HasComment("اعتبار باز");
            entity.Property(e => e.Currency)
                .HasMaxLength(4)
                .HasComment("ارز");
            entity.Property(e => e.ShamsiInt).HasComment("تاریخ شمسی");
        });

        modelBuilder.Entity<CurrencyEquivalent>(entity =>
        {
            entity.ToTable("CurrencyEquivalent");

            entity.HasIndex(e => e.Title, "UniqueTitle").IsUnique();

            entity.Property(e => e.Eqtitle)
                .HasMaxLength(50)
                .HasColumnName("EQTitle");
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.EqtitleNavigation).WithMany(p => p.CurrencyEquivalents)
                .HasPrincipalKey(p => p.CurrencyName)
                .HasForeignKey(d => d.Eqtitle)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CurrencyEquivalent_CurrencySymbol");
        });

        modelBuilder.Entity<CurrencySymbol>(entity =>
        {
            entity.HasKey(e => e.Symbol);

            entity.ToTable("CurrencySymbol");

            entity.HasIndex(e => e.CurrencyName, "UniqueCurrency").IsUnique();

            entity.Property(e => e.Symbol).HasMaxLength(50);
            entity.Property(e => e.CurrencyName).HasMaxLength(50);
        });

        modelBuilder.Entity<CustomerRepresentative>(entity =>
        {
            entity.ToTable("CustomerRepresentative");

            entity.Property(e => e.Birthdate).HasColumnType("date");
            entity.Property(e => e.Firstname).HasMaxLength(255);
            entity.Property(e => e.IdentificationNumber).HasMaxLength(255);
            entity.Property(e => e.IdinquiryState)
                .HasMaxLength(255)
                .HasColumnName("IDInquiryState");
            entity.Property(e => e.Lastname).HasMaxLength(255);
            entity.Property(e => e.NationalCode).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(255);

            entity.HasOne(d => d.CustomerNavigation).WithMany(p => p.CustomerRepresentatives)
                .HasForeignKey(d => d.Customer)
                .HasConstraintName("FK_CustomerRepresentative_ExchangeCustomer");
        });

        modelBuilder.Entity<CustomerTradeType>(entity =>
        {
            entity.ToTable("CustomerTradeType");

            entity.HasIndex(e => e.Title, "UniqueTitleCTT").IsUnique();

            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<CustomerType>(entity =>
        {
            entity.ToTable("CustomerType");

            entity.HasIndex(e => e.Title, "UniqueTitleCT").IsUnique();

            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<CustomerUser>(entity =>
        {
            entity.ToTable("CustomerUser");

            entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(100);

            entity.HasOne(d => d.BankBranchNavigation).WithMany(p => p.CustomerUsers)
                .HasForeignKey(d => d.BankBranch)
                .HasConstraintName("FK_CustomerUser_BankBranch");

            entity.HasOne(d => d.CustomerNavigation).WithMany(p => p.CustomerUsers)
                .HasForeignKey(d => d.Customer)
                .HasConstraintName("FK_CustomerUser_ExchangeCustomer");
        });

        modelBuilder.Entity<DealType>(entity =>
        {
            entity.ToTable("DealType");

            entity.HasIndex(e => e.Title, "UniqueTitleDT").IsUnique();

            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<DestinationBank>(entity =>
        {
            entity.ToTable("DestinationBank");

            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<EndDuration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_EndDurations");

            entity.ToTable("EndDuration");

            entity.Property(e => e.Currency).HasMaxLength(50);
            entity.Property(e => e.EndDuration1).HasColumnName("EndDuration");
            entity.Property(e => e.Potype)
                .HasMaxLength(50)
                .HasColumnName("POType");

            entity.HasOne(d => d.CurrencyNavigation).WithMany(p => p.EndDurations)
                .HasForeignKey(d => d.Currency)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EndDuration_CurrencySymbol");
        });

        modelBuilder.Entity<ExchangeBankAccount>(entity =>
        {
            entity.ToTable("ExchangeBankAccount");

            entity.HasIndex(e => new { e.Bank, e.ShabaNumber }, "UniqueBankShaba").IsUnique();

            entity.Property(e => e.Bank).HasMaxLength(50);
            entity.Property(e => e.Enable)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.ShabaNumber).HasMaxLength(100);
        });

        modelBuilder.Entity<ExchangeCustomer>(entity =>
        {
            entity.ToTable("ExchangeCustomer");

            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.Alias).HasMaxLength(200);
            entity.Property(e => e.Ceofullname)
                .HasMaxLength(200)
                .HasColumnName("CEOFullname");
            entity.Property(e => e.Company).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Firstname).HasMaxLength(255);
            entity.Property(e => e.IdinquiryState)
                .HasMaxLength(255)
                .HasColumnName("IDInquiryState");
            entity.Property(e => e.Lastname).HasMaxLength(255);
            entity.Property(e => e.NationalCode).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.RegisterDate).HasColumnType("date");
            entity.Property(e => e.RegisterNumber).HasMaxLength(255);
            entity.Property(e => e.SystemLastUpdateTime).HasColumnType("datetime");
            entity.Property(e => e.SystemPassword).HasMaxLength(500);
            entity.Property(e => e.SystemRegisterTime).HasColumnType("datetime");
            entity.Property(e => e.SystemUsername).HasMaxLength(100);
        });

        modelBuilder.Entity<ExpertLevel>(entity =>
        {
            entity.ToTable("ExpertLevel");

            entity.Property(e => e.ExpertLevelId).ValueGeneratedNever();
            entity.Property(e => e.ExpertlevelName).HasMaxLength(50);
            entity.Property(e => e.MaxAmount).HasColumnType("numeric(28, 2)");
            entity.Property(e => e.MinAmount).HasColumnType("numeric(28, 2)");
        });

        modelBuilder.Entity<ExportType>(entity =>
        {
            entity.ToTable("ExportType");

            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<Industry>(entity =>
        {
            entity.ToTable("Industry");

            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<NimaBank>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_NimaBanks");

            entity.ToTable("NimaBank");

            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<NimaBankAccount>(entity =>
        {
            entity.ToTable("NimaBankAccount");

            entity.Property(e => e.AccountNumber).HasMaxLength(200);
            entity.Property(e => e.OwnerName).HasMaxLength(200);
            entity.Property(e => e.ShabaNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<NimaDeal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_NimaBuys");

            entity.ToTable("NimaDeal");

            entity.Property(e => e.AccountNumber).HasMaxLength(50);
            entity.Property(e => e.AccountOwnerName).HasMaxLength(200);
            entity.Property(e => e.CodeType).HasMaxLength(200);
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.DealDate).HasColumnType("datetime");
            entity.Property(e => e.DemandDateTime).HasColumnType("datetime");
            entity.Property(e => e.DemandDetailLink).HasMaxLength(500);
            entity.Property(e => e.Iban)
                .HasMaxLength(200)
                .HasColumnName("IBAN");
            entity.Property(e => e.OtherCodes).HasMaxLength(2000);
            entity.Property(e => e.Podate)
                .HasColumnType("date")
                .HasColumnName("PODate");
            entity.Property(e => e.RialPaymentCondition).HasMaxLength(2000);
            entity.Property(e => e.SanaTrackingNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ServerDateTimeDealDetail).HasColumnType("datetime");
            entity.Property(e => e.ServerDateTimeRead).HasColumnType("datetime");
            entity.Property(e => e.StatusText).HasMaxLength(50);
            entity.Property(e => e.Supplier).HasMaxLength(200);
            entity.Property(e => e.SupplyDetailLink).HasMaxLength(500);
            entity.Property(e => e.SupplyRegisterDateTime).HasColumnType("datetime");
            entity.Property(e => e.Swiftcode)
                .HasMaxLength(200)
                .HasColumnName("SWIFTCode");
            entity.Property(e => e.TradeDetailLink).HasMaxLength(500);

            entity.HasOne(d => d.CountryNavigation).WithMany(p => p.NimaDealCountryNavigations)
                .HasForeignKey(d => d.Country)
                .HasConstraintName("FK_NimaDeal_Country");

            entity.HasOne(d => d.DestinationCountryNavigation).WithMany(p => p.NimaDealDestinationCountryNavigations)
                .HasForeignKey(d => d.DestinationCountry)
                .HasConstraintName("FK_NimaDeal_NimaDeal");

            entity.HasOne(d => d.RateTypeNavigation).WithMany(p => p.NimaDeals)
                .HasForeignKey(d => d.RateType)
                .HasConstraintName("FK_NimaDeal_NimaRateType");

            entity.HasOne(d => d.RialPaymentMethodNavigation).WithMany(p => p.NimaDeals)
                .HasForeignKey(d => d.RialPaymentMethod)
                .HasConstraintName("FK_NimaDeal_RialPaymentMethod");

            entity.HasOne(d => d.SupplierBankAccountNavigation).WithMany(p => p.NimaDeals)
                .HasForeignKey(d => d.SupplierBankAccount)
                .HasConstraintName("FK_NimaDeal_BankBranch");

            entity.HasOne(d => d.SupplierNavigation).WithMany(p => p.NimaDeals)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK_NimaDeal_ExchangeCustomer");

            entity.HasOne(d => d.SupplierUserNavigation).WithMany(p => p.NimaDeals)
                .HasForeignKey(d => d.SupplierUser)
                .HasConstraintName("FK_NimaDeal_CustomerUser");
        });

        modelBuilder.Entity<NimaDealActive>(entity =>
        {
            entity.ToTable("NimaDealActive");

            entity.Property(e => e.AccountNumber).HasMaxLength(50);
            entity.Property(e => e.AccountOwnerName).HasMaxLength(200);
            entity.Property(e => e.CodeType).HasMaxLength(200);
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.DealDate).HasColumnType("datetime");
            entity.Property(e => e.DemandDateTime).HasColumnType("datetime");
            entity.Property(e => e.DemandDetailLink).HasMaxLength(500);
            entity.Property(e => e.Iban)
                .HasMaxLength(200)
                .HasColumnName("IBAN");
            entity.Property(e => e.OtherCodes).HasMaxLength(2000);
            entity.Property(e => e.Podate)
                .HasColumnType("date")
                .HasColumnName("PODate");
            entity.Property(e => e.RialPaymentCondition).HasMaxLength(2000);
            entity.Property(e => e.SanaTrackingNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ServerDateTimeDealDetail).HasColumnType("datetime");
            entity.Property(e => e.ServerDateTimeRead).HasColumnType("datetime");
            entity.Property(e => e.StatusText).HasMaxLength(50);
            entity.Property(e => e.Supplier).HasMaxLength(200);
            entity.Property(e => e.SupplyDetailLink).HasMaxLength(500);
            entity.Property(e => e.SupplyRegisterDateTime).HasColumnType("datetime");
            entity.Property(e => e.Swiftcode)
                .HasMaxLength(200)
                .HasColumnName("SWIFTCode");
            entity.Property(e => e.TradeDetailLink).HasMaxLength(500);

            entity.HasOne(d => d.CountryNavigation).WithMany(p => p.NimaDealActiveCountryNavigations)
                .HasForeignKey(d => d.Country)
                .HasConstraintName("FK_NimaDealActive_Country");

            entity.HasOne(d => d.DestinationCountryNavigation).WithMany(p => p.NimaDealActiveDestinationCountryNavigations)
                .HasForeignKey(d => d.DestinationCountry)
                .HasConstraintName("FK_NimaDealActive_Country1");

            entity.HasOne(d => d.RateTypeNavigation).WithMany(p => p.NimaDealActives)
                .HasForeignKey(d => d.RateType)
                .HasConstraintName("FK_NimaDealActive_NimaRateType");

            entity.HasOne(d => d.RialPaymentMethodNavigation).WithMany(p => p.NimaDealActives)
                .HasForeignKey(d => d.RialPaymentMethod)
                .HasConstraintName("FK_NimaDealActive_RialPaymentMethod");

            entity.HasOne(d => d.SupplierNavigation).WithMany(p => p.NimaDealActives)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK_NimaDealActive_ExchangeCustomer");
        });

        modelBuilder.Entity<NimaDealLog>(entity =>
        {
            entity.ToTable("NimaDealLog");

            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("IPAddress");
            entity.Property(e => e.Podate)
                .HasColumnType("date")
                .HasColumnName("PODate");
            entity.Property(e => e.RialPaymentCondition).HasMaxLength(2000);
            entity.Property(e => e.ServerDateTimeRead).HasColumnType("datetime");
            entity.Property(e => e.TradeDetailLink).HasMaxLength(500);

            entity.HasOne(d => d.CountryNavigation).WithMany(p => p.NimaDealLogs)
                .HasForeignKey(d => d.Country)
                .HasConstraintName("FK_NimaDealLog_Country");

            entity.HasOne(d => d.RateTypeNavigation).WithMany(p => p.NimaDealLogs)
                .HasForeignKey(d => d.RateType)
                .HasConstraintName("FK_NimaDealLog_NimaRateType");

            entity.HasOne(d => d.RialPaymentMethodNavigation).WithMany(p => p.NimaDealLogs)
                .HasForeignKey(d => d.RialPaymentMethod)
                .HasConstraintName("FK_NimaDealLog_RialPaymentMethod");

            entity.HasOne(d => d.SupplierBankAccountNavigation).WithMany(p => p.NimaDealLogs)
                .HasForeignKey(d => d.SupplierBankAccount)
                .HasConstraintName("FK_NimaDealLog_BankBranch");
        });

        modelBuilder.Entity<NimaDealPayment>(entity =>
        {
            entity.ToTable("NimaDealPayment");

            entity.Property(e => e.Description).HasMaxLength(2000);
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentId).HasMaxLength(50);

            entity.HasOne(d => d.PaymentMethodNavigation).WithMany(p => p.NimaDealPayments)
                .HasForeignKey(d => d.PaymentMethod)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NimaDealPayment_NimaPaymentMethod");

            entity.HasOne(d => d.SourceBankNavigation).WithMany(p => p.NimaDealPayments)
                .HasForeignKey(d => d.SourceBank)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NimaDealPayment_NimaBank");

            entity.HasOne(d => d.StateNavigation).WithMany(p => p.NimaDealPayments)
                .HasForeignKey(d => d.State)
                .HasConstraintName("FK_NimaDealPayment_NimaPaymentStatus");
        });

        modelBuilder.Entity<NimaOffer>(entity =>
        {
            entity.ToTable("NimaOffer");

            entity.Property(e => e.AccountNumber).HasMaxLength(50);
            entity.Property(e => e.AccountOwnerAddress).HasMaxLength(2000);
            entity.Property(e => e.AccountOwnerName).HasMaxLength(200);
            entity.Property(e => e.AccountOwnerPhone).HasMaxLength(200);
            entity.Property(e => e.BankAddress).HasMaxLength(2000);
            entity.Property(e => e.ConvertCurrency)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.CreateUser).HasMaxLength(50);
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.DetailLink).HasMaxLength(200);
            entity.Property(e => e.ErrorMessage).HasMaxLength(500);
            entity.Property(e => e.Iban)
                .HasMaxLength(200)
                .HasColumnName("IBAN");
            entity.Property(e => e.LastNimaChangeTime).HasColumnType("datetime");
            entity.Property(e => e.LastNimaCheckTime).HasColumnType("datetime");
            entity.Property(e => e.LastTransferTryTime).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateTime).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateUser).HasMaxLength(50);
            entity.Property(e => e.OfferDate).HasColumnType("datetime");
            entity.Property(e => e.OfferExpireTime).HasColumnType("datetime");
            entity.Property(e => e.OtherCodes).HasMaxLength(2000);
            entity.Property(e => e.OtherCodesDescription).HasMaxLength(500);
            entity.Property(e => e.Podays).HasColumnName("PODays");
            entity.Property(e => e.Ponumber)
                .HasMaxLength(50)
                .HasColumnName("PONumber");
            entity.Property(e => e.Potype).HasColumnName("POType");
            entity.Property(e => e.RegisterValidityDate).HasColumnType("datetime");
            entity.Property(e => e.RequestPaymentDeadline).HasColumnType("datetime");
            entity.Property(e => e.RequestRegisterDate).HasColumnType("datetime");
            entity.Property(e => e.RialPaymentDeadline).HasColumnType("datetime");
            entity.Property(e => e.SanaTrackingNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ServerDateTimeOfferDetail).HasColumnType("datetime");
            entity.Property(e => e.ServerDateTimeRead).HasColumnType("datetime");
            entity.Property(e => e.ServerDateTimeRequestDetail).HasColumnType("datetime");
            entity.Property(e => e.StatusText).HasMaxLength(50);
            entity.Property(e => e.Swiftcode)
                .HasMaxLength(200)
                .HasColumnName("SWIFTCode");
            entity.Property(e => e.SystemCreateTime).HasColumnType("datetime");
            entity.Property(e => e.Trader).HasMaxLength(50);
        });

        modelBuilder.Entity<NimaOfferActive>(entity =>
        {
            entity.ToTable("NimaOfferActive");

            entity.Property(e => e.ConvertCurrency)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.CreateUser).HasMaxLength(50);
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.DetailLink).HasMaxLength(200);
            entity.Property(e => e.ErrorMessage).HasMaxLength(500);
            entity.Property(e => e.LastNimaChangeTime).HasColumnType("datetime");
            entity.Property(e => e.LastNimaCheckTime).HasColumnType("datetime");
            entity.Property(e => e.LastTransferTryTime).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateTime).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateUser).HasMaxLength(50);
            entity.Property(e => e.OfferDate).HasColumnType("datetime");
            entity.Property(e => e.OfferExpireTime).HasColumnType("datetime");
            entity.Property(e => e.Podays).HasColumnName("PODays");
            entity.Property(e => e.Ponumber)
                .HasMaxLength(50)
                .HasColumnName("PONumber");
            entity.Property(e => e.Potype).HasColumnName("POType");
            entity.Property(e => e.RegisterValidityDate).HasColumnType("datetime");
            entity.Property(e => e.RequestPaymentDeadline).HasColumnType("datetime");
            entity.Property(e => e.RequestRegisterDate).HasColumnType("datetime");
            entity.Property(e => e.RialPaymentDeadline).HasColumnType("datetime");
            entity.Property(e => e.SanaTrackingNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ServerDateTimeOfferDetail).HasColumnType("datetime");
            entity.Property(e => e.ServerDateTimeRead).HasColumnType("datetime");
            entity.Property(e => e.ServerDateTimeRequestDetail).HasColumnType("datetime");
            entity.Property(e => e.StatusText).HasMaxLength(50);
            entity.Property(e => e.SystemCreateTime).HasColumnType("datetime");
            entity.Property(e => e.Trader).HasMaxLength(50);
        });

        modelBuilder.Entity<NimaOfferLog>(entity =>
        {
            entity.ToTable("NimaOfferLog");

            entity.Property(e => e.ConvertCurrency)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.ErrorMessage).HasMaxLength(500);
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("IPAddress");
            entity.Property(e => e.LastNimaChangeTime).HasColumnType("datetime");
            entity.Property(e => e.LastTransferTryTime).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateTime).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateUser).HasMaxLength(50);
            entity.Property(e => e.OfferExpireTime).HasColumnType("datetime");
            entity.Property(e => e.Podays).HasColumnName("PODays");
            entity.Property(e => e.Ponumber)
                .HasMaxLength(50)
                .HasColumnName("PONumber");
            entity.Property(e => e.Potype).HasColumnName("POType");
            entity.Property(e => e.RialPaymentDeadline).HasColumnType("datetime");
            entity.Property(e => e.Trader).HasMaxLength(50);
        });

        modelBuilder.Entity<NimaOfferPayment>(entity =>
        {
            entity.ToTable("NimaOfferPayment");

            entity.Property(e => e.Description).HasMaxLength(2000);
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentId).HasMaxLength(50);
        });

        modelBuilder.Entity<NimaOfferPo>(entity =>
        {
            entity.ToTable("NimaOfferPO");

            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.CreateUser).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.FileName).HasMaxLength(200);
            entity.Property(e => e.FileType).HasMaxLength(100);
            entity.Property(e => e.NimaRegisterTime).HasColumnType("datetime");
            entity.Property(e => e.Volume)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<NimaOfferState>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_NimaState");

            entity.ToTable("NimaOfferState");

            entity.Property(e => e.Etitle)
                .HasMaxLength(50)
                .HasColumnName("ETitle");
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<NimaPaymentStatus>(entity =>
        {
            entity.ToTable("NimaPaymentStatus");

            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<NimaRateType>(entity =>
        {
            entity.ToTable("NimaRateType");

            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<NimaRequestState>(entity =>
        {
            entity.ToTable("NimaRequestState");

            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<NimaRequestType>(entity =>
        {
            entity.ToTable("NimaRequestType");

            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<NimaTransferType>(entity =>
        {
            entity.ToTable("NimaTransferType");

            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_SanaPaymentMethod");

            entity.ToTable("PaymentMethod");

            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<PaymentTool>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_NimaPaymentMethods");

            entity.ToTable("PaymentTool");

            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<RegistererType>(entity =>
        {
            entity.ToTable("RegistererType");

            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.RequestCode);

            entity.ToTable("Request");

            entity.Property(e => e.RequestCode).ValueGeneratedNever();
            entity.Property(e => e.Amount).HasColumnType("decimal(26, 2)");
            entity.Property(e => e.Currency).HasMaxLength(50);
            entity.Property(e => e.ExpireDate).HasColumnType("date");
            entity.Property(e => e.PaymentExpireDate).HasColumnType("date");
            entity.Property(e => e.RefUrl)
                .HasMaxLength(255)
                .HasColumnName("RefURL");
            entity.Property(e => e.RequestDate).HasColumnType("date");
            entity.Property(e => e.ServerDateTimeDetailRead).HasColumnType("datetime");
            entity.Property(e => e.ServerDateTimeRead).HasColumnType("datetime");
        });

        modelBuilder.Entity<RequestActive>(entity =>
        {
            entity.HasKey(e => e.RequestCode);

            entity.ToTable("RequestActive");

            entity.Property(e => e.RequestCode).ValueGeneratedNever();
            entity.Property(e => e.Amount).HasColumnType("decimal(26, 2)");
            entity.Property(e => e.Currency).HasMaxLength(50);
            entity.Property(e => e.ExpireDate).HasColumnType("date");
            entity.Property(e => e.PaymentExpireDate).HasColumnType("date");
            entity.Property(e => e.RefUrl)
                .HasMaxLength(255)
                .HasColumnName("RefURL");
            entity.Property(e => e.RequestDate).HasColumnType("date");
            entity.Property(e => e.ServerDateTimeDetailRead).HasColumnType("datetime");
            entity.Property(e => e.ServerDateTimeRead).HasColumnType("datetime");
        });

        modelBuilder.Entity<RequestLog>(entity =>
        {
            entity.ToTable("RequestLog");

            entity.Property(e => e.Amount).HasColumnType("decimal(26, 2)");
            entity.Property(e => e.Currency).HasMaxLength(50);
            entity.Property(e => e.ExpireDate).HasColumnType("date");
            entity.Property(e => e.PaymentExpireDate).HasColumnType("date");
            entity.Property(e => e.RefUrl)
                .HasMaxLength(255)
                .HasColumnName("RefURL");
            entity.Property(e => e.RequestDate).HasColumnType("date");
            entity.Property(e => e.RequestValidityDate).HasColumnType("date");
            entity.Property(e => e.ServerDateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<RialPaymentMethod>(entity =>
        {
            entity.ToTable("RialPaymentMethod");

            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<SanaAction>(entity =>
        {
            entity.ToTable("SanaAction");

            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<SanaHeading>(entity =>
        {
            entity.ToTable("SanaHeading");

            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.Value).HasMaxLength(255);
        });

        modelBuilder.Entity<SanaOrder>(entity =>
        {
            entity.ToTable("SanaOrder");

            entity.Property(e => e.Currency).HasMaxLength(3);
            entity.Property(e => e.CurrencyAccountShaba).HasMaxLength(50);
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.DetailLink).HasMaxLength(500);
            entity.Property(e => e.Phone).HasMaxLength(255);
            entity.Property(e => e.PrevTrackNumber).HasMaxLength(255);
            entity.Property(e => e.ReferralNumber).HasMaxLength(255);
            entity.Property(e => e.ServerDateTimeDeatilRead).HasColumnType("datetime");
            entity.Property(e => e.ServerDateTimeRead).HasColumnType("datetime");
            entity.Property(e => e.TrackingNumber).HasMaxLength(255);
            entity.Property(e => e.UserCode).HasMaxLength(255);
        });

        modelBuilder.Entity<SanaOrderLog>(entity =>
        {
            entity.ToTable("SanaOrderLog");

            entity.Property(e => e.Currency).HasMaxLength(3);
            entity.Property(e => e.CurrencyAccountShaba).HasMaxLength(50);
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("IPAddress");
            entity.Property(e => e.Phone).HasMaxLength(255);
            entity.Property(e => e.PrevTrackNumber).HasMaxLength(255);
            entity.Property(e => e.ReferralNumber).HasMaxLength(255);
            entity.Property(e => e.ServerDateTime).HasColumnType("datetime");
            entity.Property(e => e.TrackingNumber).HasMaxLength(255);
            entity.Property(e => e.UserCode).HasMaxLength(255);
        });

        modelBuilder.Entity<SanaOrderReason>(entity =>
        {
            entity.ToTable("SanaOrderReason");

            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<SanaPayment>(entity =>
        {
            entity.ToTable("SanaPayment");

            entity.Property(e => e.PaymentTrackingCode).HasMaxLength(200);
            entity.Property(e => e.RefNumber).HasMaxLength(200);
            entity.Property(e => e.ServerDateTime).HasColumnType("datetime");
            entity.Property(e => e.TrackingNumber).HasMaxLength(50);
        });

        modelBuilder.Entity<SanaSource>(entity =>
        {
            entity.ToTable("SanaSource");

            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<SanaState>(entity =>
        {
            entity.ToTable("SanaState");

            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<Supply>(entity =>
        {
            entity.HasKey(e => e.SupplyCode);

            entity.ToTable("Supply");

            entity.Property(e => e.SupplyCode).ValueGeneratedNever();
            entity.Property(e => e.Amount).HasColumnType("decimal(26, 2)");
            entity.Property(e => e.BuyerExpireTime).HasMaxLength(5);
            entity.Property(e => e.BuyerReviewTime).HasMaxLength(5);
            entity.Property(e => e.Currency).HasMaxLength(50);
            entity.Property(e => e.DetailLink).HasMaxLength(255);
            entity.Property(e => e.ServerDateTimeDetailRead).HasColumnType("datetime");
            entity.Property(e => e.ServerDateTimeRead).HasColumnType("datetime");
            entity.Property(e => e.Supplier).HasMaxLength(200);
            entity.Property(e => e.SupplyRegisterDateTime).HasColumnType("datetime");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(26, 2)");
            entity.Property(e => e.UnitRate).HasColumnType("decimal(26, 2)");
        });

        modelBuilder.Entity<SupplyActive>(entity =>
        {
            entity.HasKey(e => e.SupplyCode);

            entity.ToTable("SupplyActive");

            entity.Property(e => e.SupplyCode).ValueGeneratedNever();
            entity.Property(e => e.Amount).HasColumnType("decimal(26, 2)");
            entity.Property(e => e.BuyerExpireTime).HasMaxLength(5);
            entity.Property(e => e.BuyerReviewTime).HasMaxLength(5);
            entity.Property(e => e.Currency).HasMaxLength(50);
            entity.Property(e => e.DetailLink).HasMaxLength(255);
            entity.Property(e => e.ServerDateTimeDetailRead).HasColumnType("datetime");
            entity.Property(e => e.ServerDateTimeRead).HasColumnType("datetime");
            entity.Property(e => e.Supplier).HasMaxLength(200);
            entity.Property(e => e.SupplyRegisterDateTime).HasColumnType("datetime");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(26, 2)");
            entity.Property(e => e.UnitRate).HasColumnType("decimal(26, 2)");
        });

        modelBuilder.Entity<SupplyLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_SupplyLog_1");

            entity.ToTable("SupplyLog");

            entity.Property(e => e.Amount).HasColumnType("decimal(26, 2)");
            entity.Property(e => e.BuyerExpireTime).HasMaxLength(5);
            entity.Property(e => e.BuyerReviewTime).HasMaxLength(5);
            entity.Property(e => e.Currency).HasMaxLength(50);
            entity.Property(e => e.DetailLink).HasMaxLength(255);
            entity.Property(e => e.ServerDateTime).HasColumnType("datetime");
            entity.Property(e => e.SupplyRegisterDateTime).HasColumnType("datetime");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(26, 2)");
            entity.Property(e => e.UnitRate).HasColumnType("decimal(26, 2)");
        });

        modelBuilder.Entity<SystemConfig>(entity =>
        {
            entity.ToTable("SystemConfig");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Text).HasMaxLength(100);
            entity.Property(e => e.Valid).HasColumnName("valid");
        });

        modelBuilder.Entity<Trusty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Trusties");

            entity.ToTable("Trusty");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<UserAction>(entity =>
        {
            entity.ToTable("UserAction");

            entity.Property(e => e.Entity).HasMaxLength(50);
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(15)
                .HasColumnName("IPAddress");
            entity.Property(e => e.ServerDateTime).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasMaxLength(100);
        });

        modelBuilder.Entity<ValidityCheck>(entity =>
        {
            entity.ToTable("ValidityCheck");

            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<Xerate>(entity =>
        {
            entity.HasKey(e => new { e.TimeStamp, e.Symbol });

            entity.ToTable("XERate");

            entity.Property(e => e.Symbol).HasMaxLength(6);
            entity.Property(e => e.Rate).HasColumnType("numeric(26, 8)");
            entity.Property(e => e.ServerDateTime).HasColumnType("smalldatetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
