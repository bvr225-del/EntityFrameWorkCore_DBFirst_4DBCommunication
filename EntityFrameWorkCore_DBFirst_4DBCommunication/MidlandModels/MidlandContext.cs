using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameWorkCore_DBFirst_4DBCommunication.MidlandModels;

public partial class MidlandContext : DbContext
{
    public MidlandContext()
    {
    }

    public MidlandContext(DbContextOptions<MidlandContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<EmployeeDetail> EmployeeDetails { get; set; }

    public virtual DbSet<ErrorDetail> ErrorDetails { get; set; }

    public virtual DbSet<MastEmployeeDetail> MastEmployeeDetails { get; set; }

    public virtual DbSet<MastUser> MastUsers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Sample123> Sample123s { get; set; }

    public virtual DbSet<Sr123> Sr123s { get; set; }

    public virtual DbSet<SurveyResult> SurveyResults { get; set; }

    public virtual DbSet<UserSurveyQueAn> UserSurveyQueAns { get; set; }

    public virtual DbSet<Userdatum> Userdata { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DESKTOP-S8CP3CH;Database=MIDLAND;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("customers");

            entity.Property(e => e.CustomerName)
                .IsUnicode(false)
                .HasColumnName("customerName");
            entity.Property(e => e.CustomerNum)
                .IsUnicode(false)
                .HasColumnName("customerNum");
        });

        modelBuilder.Entity<EmployeeDetail>(entity =>
        {
            entity.HasKey(e => e.EmpId);

            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.EmailId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmpName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.PinCode)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ErrorDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Error_details");

            entity.Property(e => e.Message).IsUnicode(false);
            entity.Property(e => e.ProcedureName)
                .IsUnicode(false)
                .HasColumnName("Procedure_name");
            entity.Property(e => e.Timestamp).HasColumnType("datetime");
            entity.Property(e => e.TxnId)
                .ValueGeneratedOnAdd()
                .HasColumnName("txn_id");
        });

        modelBuilder.Entity<MastEmployeeDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Mast_Employee_Details");

            entity.Property(e => e.EmpDesignation)
                .IsUnicode(false)
                .HasColumnName("Emp_Designation");
            entity.Property(e => e.EmpId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Emp_Id");
            entity.Property(e => e.EmpName)
                .IsUnicode(false)
                .HasColumnName("Emp_Name");
            entity.Property(e => e.EmpSalary)
                .HasColumnType("money")
                .HasColumnName("Emp_salary");
            entity.Property(e => e.EmpStatus)
                .IsUnicode(false)
                .HasColumnName("Emp_status");
        });

        modelBuilder.Entity<MastUser>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("mast_user");

            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TxnId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("txn_id");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("username");
            entity.Property(e => e.Userroll)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("userroll");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Orderid).HasName("PK__Orders__080E3775B3241F9A");

            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Orderlocation)
                .IsUnicode(false)
                .HasColumnName("orderlocation");
            entity.Property(e => e.Ordername)
                .IsUnicode(false)
                .HasColumnName("ordername");
        });

        modelBuilder.Entity<Sample123>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("sample123");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Sr123>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("sr123");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SurveyResult>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Name)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Timestamp)
                .IsUnicode(false)
                .HasColumnName("TIMESTAMP");
            entity.Property(e => e.UserId)
                .IsUnicode(false)
                .HasColumnName("USER_ID");
            entity.Property(e => e.UserSurveyId)
                .IsUnicode(false)
                .HasColumnName("USER_SURVEY_ID");
        });

        modelBuilder.Entity<UserSurveyQueAn>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.QuestionId).HasColumnName("QUESTION_ID");
            entity.Property(e => e.QuestionOrder).HasColumnName("QUESTION_ORDER");
            entity.Property(e => e.QuestionText)
                .IsUnicode(false)
                .HasColumnName("QUESTION_TEXT");
            entity.Property(e => e.ResponseValue)
                .IsUnicode(false)
                .HasColumnName("RESPONSE_VALUE");
        });

        modelBuilder.Entity<Userdatum>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TxnId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("txn_id");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("username");
            entity.Property(e => e.Userroll)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("userroll");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
