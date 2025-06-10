using System;
using System.Collections.Generic;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context;

/* Developer-Buddhika Walpita
 * Date-2023.05.29
 * Description-This is the DbContext class for the SofttOneSmsnew database.
 * It contains a DbSet for TblStudentPersonal entity.
 */
public partial class SofttOneSmsnewContext : DbContext
{
    public SofttOneSmsnewContext()
    {
    }

    public SofttOneSmsnewContext(DbContextOptions<SofttOneSmsnewContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblStudentPersonal> TblStudentPersonals { get; set; }


    //Set Connection string
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlServer("Name=ConnectionStrings:StuConnStr");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblStudentPersonal>(entity =>
        {
            entity.HasKey(e => e.Uid);

            entity.ToTable("tblStudent_Personal");

            entity.Property(e => e.Uid)
                .ValueGeneratedNever()
                .HasColumnName("UId");
            entity.Property(e => e.Address)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last_Name");
            entity.Property(e => e.Mobile)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Nic)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NIC");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
