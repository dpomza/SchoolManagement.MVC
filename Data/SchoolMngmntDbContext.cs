using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagement.MVC.Data;

public partial class SchoolMngmntDbContext : DbContext
{
    public SchoolMngmntDbContext(DbContextOptions<SchoolMngmntDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }
    
    public virtual DbSet<Teacher> Teachers { get; set; }
    
    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<StudentsCourse> StudentsCourses { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Courses__3214EC07C83849D6");

            entity.HasIndex(e => e.Code, "UQ__Courses__A25C5AA76B513771").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(70);

            entity.HasOne(d => d.Teacher).WithMany(p => p.Courses)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Courses__Teacher__3E52440B");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Grades__3214EC07AC2BEE78");

            entity.Property(e => e.DateRecorded).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.GradeObtained).HasColumnName("GradeObtained");

            entity.HasOne(d => d.StudentsCourse).WithMany(p => p.Grades)
                .HasForeignKey(d => d.StudentCourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Grades__StudentC__45F365D3");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Students__3214EC0724F3E95E");

            entity.HasIndex(e => e.FileNumber, "UQ__Students__8BD00B71E43CE9BE").IsUnique();

            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        modelBuilder.Entity<StudentsCourse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Students__3214EC076F3E9A9A");

            entity.HasOne(d => d.Course).WithMany(p => p.StudentsCourses)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StudentsC__Cours__4222D4EF");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentsCourses)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StudentsC__Stude__412EB0B6");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Teachers__3214EC07F359B14E");

            entity.HasIndex(e => e.FileNumber, "UQ__Teachers__8BD00B71851876A7").IsUnique();

            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
