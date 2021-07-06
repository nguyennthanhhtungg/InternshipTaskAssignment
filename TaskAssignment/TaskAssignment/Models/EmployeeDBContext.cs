using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace TaskAssignment.Models
{
    public partial class EmployeeDBContext : DbContext
    {
        IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();

        public EmployeeDBContext()
        {
        }

        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(d => d.DeptId);

                entity.ToTable("Department");

                entity.Property(d => d.DeptId).HasColumnName("DeptID");

                entity.Property(d => d.DeptLocation).HasMaxLength(50);

                entity.Property(d => d.DeptName).HasMaxLength(100);

                entity.HasMany(d => d.EmployeeDepartments)
                    .WithOne(d => d.Department)
                    .HasForeignKey(d => d.DeptID)
                    .HasConstraintName("FK_Department_EmployeeDepartment");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeId");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeNo)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.IsActived)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.MarriageStatus)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nationality)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Vietnam')");

                entity.HasMany(e => e.EmployeeDepartments)
                    .WithOne(e => e.Employee)
                    .HasForeignKey(e => e.EmployeeID)
                    .HasConstraintName("FK_Employee_EmployeeDepartment");
            });

            modelBuilder.Entity<EmployeeDepartment>(entity =>
            {
                entity.HasKey(ed => ed.ID);

                entity.ToTable("EmployeeDepartment");

                entity.Property(ed => ed.ID).HasColumnName("ID");

                entity.Property(ed => ed.EmployeeID).IsRequired();

                entity.Property(ed => ed.DeptID).IsRequired();

                entity.Property(ed => ed.StartDate)
                .IsRequired()
                .HasColumnType("datetime");

                entity.Property(ed => ed.EndDate)
                .HasColumnType("datetime");

                entity.Property(ed => ed.Description).HasColumnName("Description");

                entity.HasOne(ed => ed.Department)
                .WithMany(ed => ed.EmployeeDepartments)
                .HasForeignKey(ed => ed.DeptID);

                entity.HasOne(ed => ed.Employee)
                .WithMany(ed => ed.EmployeeDepartments)
                .HasForeignKey(ed => ed.EmployeeID);
            });

            //OnModelCreatingPartial(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
