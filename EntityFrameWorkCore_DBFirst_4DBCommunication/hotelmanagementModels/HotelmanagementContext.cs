using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameWorkCore_DBFirst_4DBCommunication.hotelmanagementModels;

public partial class HotelmanagementContext : DbContext
{
    public HotelmanagementContext()
    {
    }

    public HotelmanagementContext(DbContextOptions<HotelmanagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccountBalance> AccountBalances { get; set; }

    public virtual DbSet<BankAccount> BankAccounts { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Dept> Depts { get; set; }

    public virtual DbSet<Emp> Emps { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Employee1> Employees1 { get; set; }

    public virtual DbSet<ErrorLog> ErrorLogs { get; set; }

    public virtual DbSet<FileUpload> FileUploads { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<LoginRegister> LoginRegisters { get; set; }

    public virtual DbSet<NewBooking> NewBookings { get; set; }

    public virtual DbSet<ProjectLevelErrorlog> ProjectLevelErrorlogs { get; set; }

    public virtual DbSet<Ranking> Rankings { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Sample2> Sample2s { get; set; }

    public virtual DbSet<SipDashboard> SipDashboards { get; set; }

    public virtual DbSet<Sipdashboard1> Sipdashboards1 { get; set; }

    public virtual DbSet<Tclcheck> Tclchecks { get; set; }

    public virtual DbSet<TempSave> TempSaves { get; set; }

    public virtual DbSet<UserRegistration> UserRegistrations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-S8CP3CH;Database=hotelmanagement;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccountBalance>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("AccountBalance", "Loans");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<BankAccount>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("BankAccount", "FundTransfer");

            entity.Property(e => e.AccountName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Location)
                .HasMaxLength(300)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("bookings");

            entity.Property(e => e.CustomerName)
                .IsUnicode(false)
                .HasColumnName("customerName");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Location)
                .IsUnicode(false)
                .HasColumnName("location");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("cities");

            entity.Property(e => e.CityName)
                .IsUnicode(false)
                .HasColumnName("cityName");
            entity.Property(e => e.Id).HasColumnName("id");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("countries");

            entity.Property(e => e.CountryName)
                .IsUnicode(false)
                .HasColumnName("countryName");
            entity.Property(e => e.Id).HasColumnName("id");
        });

        modelBuilder.Entity<Dept>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("dept");

            entity.Property(e => e.Dname)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("dname");
            entity.Property(e => e.Dno).HasColumnName("dno");
        });

        modelBuilder.Entity<Emp>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("emp");

            entity.Property(e => e.Dno).HasColumnName("dno");
            entity.Property(e => e.Eid).HasColumnName("eid");
            entity.Property(e => e.Ename)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ename");
            entity.Property(e => e.Salary).HasColumnName("salary");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Empid);

            entity.ToTable("employee");

            entity.Property(e => e.Empid).HasColumnName("empid");
            entity.Property(e => e.Empname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("empname");
            entity.Property(e => e.Empsalary)
                .HasColumnType("money")
                .HasColumnName("empsalary");
        });

        modelBuilder.Entity<Employee1>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Employee", "HR");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<ErrorLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ErrorLog__3213E83FEA52264C");

            entity.ToTable("ErrorLog");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CurrentUser).IsUnicode(false);
            entity.Property(e => e.ErrorMessage).IsUnicode(false);
            entity.Property(e => e.ErrorProcedure).IsUnicode(false);
            entity.Property(e => e.ErrorSeverity).IsUnicode(false);
            entity.Property(e => e.ErrorState).IsUnicode(false);
            entity.Property(e => e.Errordtae)
                .HasColumnType("datetime")
                .HasColumnName("errordtae");
            entity.Property(e => e.Servername)
                .IsUnicode(false)
                .HasColumnName("SERVERNAME");
        });

        modelBuilder.Entity<FileUpload>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FileUplo__3214EC074EF0F5E7");

            entity.ToTable("FileUpload");

            entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e.Createdby).IsUnicode(false);
            entity.Property(e => e.FileName).IsUnicode(false);
            entity.Property(e => e.FilePath).IsUnicode(false);
            entity.Property(e => e.ModifiedFilename).IsUnicode(false);
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.HotelId).HasName("PK__Hotel__17ADC4729B0F0E77");

            entity.ToTable("Hotel");

            entity.Property(e => e.HotelId).HasColumnName("hotelId");
            entity.Property(e => e.HotelDescription)
                .IsUnicode(false)
                .HasColumnName("hotelDescription");
            entity.Property(e => e.HotelImage)
                .IsUnicode(false)
                .HasColumnName("hotelImage");
            entity.Property(e => e.HotelLocation)
                .IsUnicode(false)
                .HasColumnName("hotelLocation");
            entity.Property(e => e.HotelName)
                .IsUnicode(false)
                .HasColumnName("hotelName");
        });

        modelBuilder.Entity<LoginRegister>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("LoginRegister");

            entity.Property(e => e.Fname)
                .IsUnicode(false)
                .HasColumnName("fname");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Lname)
                .IsUnicode(false)
                .HasColumnName("lname");
            entity.Property(e => e.Mobileno)
                .IsUnicode(false)
                .HasColumnName("mobileno");
            entity.Property(e => e.Password)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Username).IsUnicode(false);
        });

        modelBuilder.Entity<NewBooking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NewBooki__3213E83F4A081989");

            entity.ToTable("NewBooking");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.City).IsUnicode(false);
            entity.Property(e => e.Country).IsUnicode(false);
            entity.Property(e => e.CustomerName).IsUnicode(false);
            entity.Property(e => e.Email).IsUnicode(false);
        });

        modelBuilder.Entity<ProjectLevelErrorlog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProjectL__3214EC07C173A56E");

            entity.ToTable("ProjectLevelErrorlog");

            entity.Property(e => e.ErrorMessage).IsUnicode(false);
            entity.Property(e => e.InnerExceptionError).IsUnicode(false);
            entity.Property(e => e.StackTraceError).IsUnicode(false);
            entity.Property(e => e.StatusCode).IsUnicode(false);
        });

        modelBuilder.Entity<Ranking>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ranking");

            entity.Property(e => e.Dno).HasColumnName("dno");
            entity.Property(e => e.Ename)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ename");
            entity.Property(e => e.Eno).HasColumnName("eno");
            entity.Property(e => e.Salary)
                .HasColumnType("money")
                .HasColumnName("salary");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Salesamount)
                .HasColumnType("money")
                .HasColumnName("salesamount");
        });

        modelBuilder.Entity<Sample2>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__sample2__3213E83F42872BB8");

            entity.ToTable("sample2");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<SipDashboard>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Sip_Dashboard");

            entity.Property(e => e.Location)
                .IsUnicode(false)
                .HasColumnName("location");
            entity.Property(e => e.Name)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Position)
                .ValueGeneratedOnAdd()
                .HasColumnName("position");
            entity.Property(e => e.Symbol)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("symbol");
            entity.Property(e => e.Weight)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("weight");
        });

        modelBuilder.Entity<Sipdashboard1>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("sipdashboard", "HR");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Tclcheck>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tclcheck");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<TempSave>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TEMP_SAVE");

            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserRegistration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserRegi__3213E83FCF415512");

            entity.ToTable("UserRegistration");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email).IsUnicode(false);
            entity.Property(e => e.FullName).IsUnicode(false);
            entity.Property(e => e.Password).IsUnicode(false);
            entity.Property(e => e.Username).IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
