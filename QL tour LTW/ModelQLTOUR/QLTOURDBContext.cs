using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QL_tour_LTW.ModelQLTOUR
{
    public partial class QLTOURDBContext : DbContext
    {
        public QLTOURDBContext()
            : base("name=QLTOURDBContext")
        {
        }

        public virtual DbSet<DIEMDEN> DIEMDENs { get; set; }
        public virtual DbSet<DIEMDI> DIEMDIs { get; set; }
        public virtual DbSet<HOADON> HOADONs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<KHACHSAN> KHACHSANs { get; set; }
        public virtual DbSet<LOAITOUR> LOAITOURs { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<PHUONGTIEN> PHUONGTIENs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOANs { get; set; }
        public virtual DbSet<TAIKHOANEMAIL> TAIKHOANEMAILs { get; set; }
        public virtual DbSet<TKUSER> TKUSERs { get; set; }
        public virtual DbSet<TOUR> TOURs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DIEMDEN>()
                .Property(e => e.MADDEN)
                .IsUnicode(false);

            modelBuilder.Entity<DIEMDEN>()
                .Property(e => e.MALTOUR)
                .IsUnicode(false);

            modelBuilder.Entity<DIEMDEN>()
                .HasMany(e => e.TOURs)
                .WithRequired(e => e.DIEMDEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DIEMDI>()
                .Property(e => e.MADDI)
                .IsUnicode(false);

            modelBuilder.Entity<DIEMDI>()
                .Property(e => e.MALTOUR)
                .IsUnicode(false);

            modelBuilder.Entity<DIEMDI>()
                .HasMany(e => e.TOURs)
                .WithRequired(e => e.DIEMDI)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.SOHD)
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.THANHTIEN)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.MATOUR)
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.MAKH)
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.MANV)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.MAKH)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.CCCD)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .HasMany(e => e.HOADONs)
                .WithRequired(e => e.KHACHHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHACHSAN>()
                .Property(e => e.MAKS)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHSAN>()
                .Property(e => e.TRANGTHAI)
                .IsUnicode(false);

            modelBuilder.Entity<LOAITOUR>()
                .Property(e => e.MALTOUR)
                .IsUnicode(false);

            modelBuilder.Entity<LOAITOUR>()
                .HasMany(e => e.DIEMDENs)
                .WithRequired(e => e.LOAITOUR)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOAITOUR>()
                .HasMany(e => e.DIEMDIs)
                .WithRequired(e => e.LOAITOUR)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOAITOUR>()
                .HasMany(e => e.TOURs)
                .WithRequired(e => e.LOAITOUR)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.MANV)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.CCCD)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.HOADONs)
                .WithRequired(e => e.NHANVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHUONGTIEN>()
                .Property(e => e.MAPT)
                .IsUnicode(false);

            modelBuilder.Entity<PHUONGTIEN>()
                .Property(e => e.TRANGTHAI)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.MATKHAU)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOANEMAIL>()
                .Property(e => e.MKEMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<TKUSER>()
                .Property(e => e.MATKHAU)
                .IsUnicode(false);

            modelBuilder.Entity<TKUSER>()
                .Property(e => e.VAITRO)
                .IsUnicode(false);

            modelBuilder.Entity<TOUR>()
                .Property(e => e.MATOUR)
                .IsUnicode(false);

            modelBuilder.Entity<TOUR>()
                .Property(e => e.GIATOUR)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TOUR>()
                .Property(e => e.MALTOUR)
                .IsUnicode(false);

            modelBuilder.Entity<TOUR>()
                .Property(e => e.MADDI)
                .IsUnicode(false);

            modelBuilder.Entity<TOUR>()
                .Property(e => e.MADDEN)
                .IsUnicode(false);

            modelBuilder.Entity<TOUR>()
                .Property(e => e.MAPT)
                .IsUnicode(false);

            modelBuilder.Entity<TOUR>()
                .Property(e => e.MAKS)
                .IsUnicode(false);

            modelBuilder.Entity<TOUR>()
                .HasMany(e => e.HOADONs)
                .WithRequired(e => e.TOUR)
                .WillCascadeOnDelete(false);
        }
    }
}
