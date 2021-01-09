using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PolytechExamBase.Models
{
    public partial class PolytechExamBaseNewContext : DbContext
    {
        public PolytechExamBaseNewContext()
        {
        }

        public PolytechExamBaseNewContext(DbContextOptions<PolytechExamBaseNewContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dbusers> Dbusers { get; set; }
        public virtual DbSet<Marks> Marks { get; set; }
        public virtual DbSet<PassedTasks> PassedTasks { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:polytechexambase.database.windows.net,1433;Initial Catalog=PolytechExamBaseNew;Persist Security Info=False;User ID=dbo.admin;Password=Henry656;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dbusers>(entity =>
            {
                entity.HasKey(e => e.FuckingUserId)
                    .HasName("DBUsers_PK");

                entity.ToTable("DBUsers");

                entity.Property(e => e.FuckingUserId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Fucking_User_ID");

                entity.Property(e => e.Email).HasMaxLength(128);

                entity.Property(e => e.FirstName)
                    .HasColumnName("First_Name")
                    .HasMaxLength(20);

                entity.Property(e => e.LastName)
                    .HasColumnName("Last_Name")
                    .HasMaxLength(20);

                entity.Property(e => e.Password).HasMaxLength(20);

                entity.Property(e => e.Role).HasMaxLength(20);
            });

            modelBuilder.Entity<Marks>(entity =>
            {
                entity.HasKey(e => e.MarkId)
                    .HasName("Marks_PK");

                entity.Property(e => e.MarkId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Mark_ID");

                entity.Property(e => e.PassedTaskId).HasColumnName("Passed_Task_ID");

                entity.HasOne(d => d.PassedTask)
                    .WithMany(p => p.Marks)
                    .HasForeignKey(d => d.PassedTaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Marks_Passed_Tasks_FK");
            });

            modelBuilder.Entity<PassedTasks>(entity =>
            {
                entity.HasKey(e => e.PassedTaskId)
                    .HasName("Passed_Task_PK");

                entity.ToTable("Passed_Tasks");

                entity.Property(e => e.PassedTaskId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Passed_Task_ID");

                entity.Property(e => e.CodeAnswer)
                    .HasColumnName("Code_Answer")
                    .HasMaxLength(2048);

                entity.Property(e => e.TaskId).HasColumnName("Task_ID");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.PassedTasks)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Passed_Task_Task_FK");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PassedTasks)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Passed_Task_DBUsers_FK");
            });

            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.HasKey(e => e.TaskId)
                    .HasName("Task_PK");

                entity.Property(e => e.TaskId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Task_ID");

                entity.Property(e => e.CodeToTest)
                    .HasColumnName("Code_To_Test")
                    .HasMaxLength(3999);

                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.Difficulty).HasMaxLength(20);

                entity.Property(e => e.TeacherId).HasColumnName("Teacher_ID");

                entity.Property(e => e.Topic).HasMaxLength(40);

                entity.Property(e => e.UnitTest)
                    .HasColumnName("Unit_Test")
                    .HasMaxLength(2048);

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Task_DBUsers_FK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
