using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace QuanLyNhanVien.Models
{
    public partial class QLNSContext : DbContext
    {
        public QLNSContext()
        {
        }

        public QLNSContext(DbContextOptions<QLNSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bangcong> Bangcongs { get; set; } = null!;
        public virtual DbSet<Bangluong> Bangluongs { get; set; } = null!;
        public virtual DbSet<Baohiem> Baohiems { get; set; } = null!;
        public virtual DbSet<Chucvu> Chucvus { get; set; } = null!;
        public virtual DbSet<Hopdong> Hopdongs { get; set; } = null!;
        public virtual DbSet<Khenthuongkyluat> Khenthuongkyluats { get; set; } = null!;
        public virtual DbSet<Loaica> Loaicas { get; set; } = null!;
        public virtual DbSet<Loaicong> Loaicongs { get; set; } = null!;
        public virtual DbSet<Nhanvien> Nhanviens { get; set; } = null!;
        public virtual DbSet<Nhanvienphucap> Nhanvienphucaps { get; set; } = null!;
        public virtual DbSet<Phongban> Phongbans { get; set; } = null!;
        public virtual DbSet<Phucap> Phucaps { get; set; } = null!;
        public virtual DbSet<Tangca> Tangcas { get; set; } = null!;
        public virtual DbSet<Ungluong> Ungluongs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Server=LAPTOP-IBPFU685;Database=QLNS;User Id=sa;Password=123;Trusted_Connection=True;trustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bangcong>(entity =>
            {
                entity.HasKey(e => e.Idbc);

                entity.ToTable("BANGCONG");

                entity.Property(e => e.Idbc).HasColumnName("IDBC");

                entity.Property(e => e.Giora).HasColumnName("GIORA");

                entity.Property(e => e.Giovao).HasColumnName("GIOVAO");

                entity.Property(e => e.LDloaicong).HasColumnName("lDLOAICONG");

                entity.Property(e => e.Manv).HasColumnName("MANV");

                entity.Property(e => e.Nam).HasColumnName("NAM");

                entity.Property(e => e.Ngay).HasColumnName("NGAY");

                entity.Property(e => e.Phutra).HasColumnName("PHUTRA");

                entity.Property(e => e.Thang).HasColumnName("THANG");

                entity.HasOne(d => d.LDloaicongNavigation)
                    .WithMany(p => p.Bangcongs)
                    .HasForeignKey(d => d.LDloaicong)
                    .HasConstraintName("FK_BANGCONG_LOAICONG");

                entity.HasOne(d => d.ManvNavigation)
                    .WithMany(p => p.Bangcongs)
                    .HasForeignKey(d => d.Manv)
                    .HasConstraintName("FK_BANGCONG_NHANVIEN");
            });

            modelBuilder.Entity<Bangluong>(entity =>
            {
                entity.HasKey(e => e.Idbangluong);

                entity.ToTable("BANGLUONG");

                entity.Property(e => e.Idbangluong).HasColumnName("IDBANGLUONG");

                entity.Property(e => e.Hoten)
                    .HasMaxLength(50)
                    .HasColumnName("HOTEN");

                entity.Property(e => e.Luongcoban).HasColumnName("LUONGCOBAN");

                entity.Property(e => e.Manv).HasColumnName("MANV");

                entity.HasOne(d => d.ManvNavigation)
                    .WithMany(p => p.Bangluongs)
                    .HasForeignKey(d => d.Manv)
                    .HasConstraintName("FK_BANGLUONG_NHANVIEN");
            });

            modelBuilder.Entity<Baohiem>(entity =>
            {
                entity.HasKey(e => e.Idbh);

                entity.ToTable("BAOHIEM");

                entity.Property(e => e.Idbh).HasColumnName("IDBH");

                entity.Property(e => e.Manv).HasColumnName("MANV");

                entity.Property(e => e.Ngaycap)
                    .HasColumnType("datetime")
                    .HasColumnName("NGAYCAP");

                entity.Property(e => e.Noicap)
                    .HasMaxLength(300)
                    .HasColumnName("NOICAP");

                entity.Property(e => e.Noidkikhambenh)
                    .HasMaxLength(100)
                    .HasColumnName("NOIDKIKHAMBENH");

                entity.Property(e => e.Sobh)
                    .HasMaxLength(50)
                    .HasColumnName("SOBH");

                entity.HasOne(d => d.ManvNavigation)
                    .WithMany(p => p.Baohiems)
                    .HasForeignKey(d => d.Manv)
                    .HasConstraintName("FK_BAOHIEM_NHANVIEN");
            });

            modelBuilder.Entity<Chucvu>(entity =>
            {
                entity.HasKey(e => e.Idcv);

                entity.ToTable("CHUCVU");

                entity.Property(e => e.Idcv).HasColumnName("IDCV");

                entity.Property(e => e.Tenchucvu)
                    .HasMaxLength(50)
                    .HasColumnName("TENCHUCVU");
            });

            modelBuilder.Entity<Hopdong>(entity =>
            {
                entity.HasKey(e => e.Sohd);

                entity.ToTable("HOPDONG");

                entity.Property(e => e.Sohd).HasColumnName("SOHD");

                entity.Property(e => e.Hesoluong).HasColumnName("HESOLUONG");

                entity.Property(e => e.Lanky).HasColumnName("LANKY");

                entity.Property(e => e.Manv).HasColumnName("MANV");

                entity.Property(e => e.Ngaybatdau)
                    .HasColumnType("datetime")
                    .HasColumnName("NGAYBATDAU");

                entity.Property(e => e.Ngayketthuc)
                    .HasColumnType("datetime")
                    .HasColumnName("NGAYKETTHUC");

                entity.Property(e => e.Ngayky)
                    .HasColumnType("datetime")
                    .HasColumnName("NGAYKY");

                entity.Property(e => e.Noidung).HasColumnName("NOIDUNG");

                entity.Property(e => e.Thoihan)
                    .HasMaxLength(50)
                    .HasColumnName("THOIHAN");

                entity.HasOne(d => d.ManvNavigation)
                    .WithMany(p => p.Hopdongs)
                    .HasForeignKey(d => d.Manv)
                    .HasConstraintName("FK_HOPDONG_NHANVIEN");
            });

            modelBuilder.Entity<Khenthuongkyluat>(entity =>
            {
                entity.ToTable("KHENTHUONGKYLUAT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Loai).HasColumnName("LOAI");

                entity.Property(e => e.Manv).HasColumnName("MANV");

                entity.Property(e => e.Ngay)
                    .HasColumnType("datetime")
                    .HasColumnName("NGAY");

                entity.Property(e => e.Noidung)
                    .HasMaxLength(50)
                    .HasColumnName("NOIDUNG");

                entity.Property(e => e.Soktlt).HasColumnName("SOKTLT");

                entity.HasOne(d => d.ManvNavigation)
                    .WithMany(p => p.Khenthuongkyluats)
                    .HasForeignKey(d => d.Manv)
                    .HasConstraintName("FK_KHENTHUONGKYLUAT_NHANVIEN");
            });

            modelBuilder.Entity<Loaica>(entity =>
            {
                entity.HasKey(e => e.Idloaica);

                entity.ToTable("LOAICA");

                entity.Property(e => e.Idloaica).HasColumnName("IDLOAICA");

                entity.Property(e => e.Heso).HasColumnName("HESO");

                entity.Property(e => e.Tenloaica)
                    .HasMaxLength(50)
                    .HasColumnName("TENLOAICA");
            });

            modelBuilder.Entity<Loaicong>(entity =>
            {
                entity.HasKey(e => e.Idloaicong);

                entity.ToTable("LOAICONG");

                entity.Property(e => e.Idloaicong).HasColumnName("IDLOAICONG");

                entity.Property(e => e.Heso).HasColumnName("HESO");

                entity.Property(e => e.Tenloaicong)
                    .HasMaxLength(50)
                    .HasColumnName("TENLOAICONG");
            });

            modelBuilder.Entity<Nhanvien>(entity =>
            {
                entity.HasKey(e => e.Manv);

                entity.ToTable("NHANVIEN");

                entity.Property(e => e.Manv).HasColumnName("MANV");

                entity.Property(e => e.Cccd)
                    .HasMaxLength(50)
                    .HasColumnName("CCCD");

                entity.Property(e => e.Diachi)
                    .HasMaxLength(300)
                    .HasColumnName("DIACHI");

                entity.Property(e => e.Gioitinh).HasColumnName("GIOITINH");

                entity.Property(e => e.Hinhanh).HasColumnName("HINHANH");

                entity.Property(e => e.Hoten)
                    .HasMaxLength(50)
                    .HasColumnName("HOTEN");

                entity.Property(e => e.Idbp).HasColumnName("IDBP");

                entity.Property(e => e.Idcv).HasColumnName("IDCV");

                entity.Property(e => e.Idpb).HasColumnName("IDPB");

                entity.Property(e => e.Ngaysinh)
                    .HasColumnType("datetime")
                    .HasColumnName("NGAYSINH");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(50)
                    .HasColumnName("SDT");

                entity.HasOne(d => d.IdcvNavigation)
                    .WithMany(p => p.Nhanviens)
                    .HasForeignKey(d => d.Idcv)
                    .HasConstraintName("FK_NHANVIEN_CHUCVU");

                entity.HasOne(d => d.IdpbNavigation)
                    .WithMany(p => p.Nhanviens)
                    .HasForeignKey(d => d.Idpb)
                    .HasConstraintName("FK_NHANVIEN_PHONGBAN1");
            });

            modelBuilder.Entity<Nhanvienphucap>(entity =>
            {
                entity.ToTable("NHANVIENPHUCAP");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .HasColumnName("ID")
                    .IsFixedLength();

                entity.Property(e => e.Idpc).HasColumnName("IDPC");

                entity.Property(e => e.Manv).HasColumnName("MANV");

                entity.Property(e => e.Ngay)
                    .HasColumnType("datetime")
                    .HasColumnName("NGAY");

                entity.Property(e => e.Noidung)
                    .HasMaxLength(500)
                    .HasColumnName("NOIDUNG");

                entity.Property(e => e.Sotien).HasColumnName("SOTIEN");

                entity.HasOne(d => d.IdpcNavigation)
                    .WithMany(p => p.Nhanvienphucaps)
                    .HasForeignKey(d => d.Idpc)
                    .HasConstraintName("FK_NHANVIENPHUCAP_PHUCAP");

                entity.HasOne(d => d.ManvNavigation)
                    .WithMany(p => p.Nhanvienphucaps)
                    .HasForeignKey(d => d.Manv)
                    .HasConstraintName("FK_NHANVIENPHUCAP_NHANVIEN");
            });

            modelBuilder.Entity<Phongban>(entity =>
            {
                entity.HasKey(e => e.Idpb);

                entity.ToTable("PHONGBAN");

                entity.Property(e => e.Idpb).HasColumnName("IDPB");

                entity.Property(e => e.Tenpb)
                    .HasMaxLength(50)
                    .HasColumnName("TENPB");
            });

            modelBuilder.Entity<Phucap>(entity =>
            {
                entity.HasKey(e => e.Idpc);

                entity.ToTable("PHUCAP");

                entity.Property(e => e.Idpc).HasColumnName("IDPC");

                entity.Property(e => e.Sotien).HasColumnName("SOTIEN");

                entity.Property(e => e.Tenpc)
                    .HasMaxLength(50)
                    .HasColumnName("TENPC");
            });

            modelBuilder.Entity<Tangca>(entity =>
            {
                entity.ToTable("TANGCA");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idloaica).HasColumnName("IDLOAICA");

                entity.Property(e => e.Manv).HasColumnName("MANV");

                entity.Property(e => e.Nam).HasColumnName("NAM");

                entity.Property(e => e.Ngay).HasColumnName("NGAY");

                entity.Property(e => e.Sogio).HasColumnName("SOGIO");

                entity.Property(e => e.Thang).HasColumnName("THANG");

                entity.HasOne(d => d.IdloaicaNavigation)
                    .WithMany(p => p.Tangcas)
                    .HasForeignKey(d => d.Idloaica)
                    .HasConstraintName("FK_TANGCA_LOAICA");

                entity.HasOne(d => d.ManvNavigation)
                    .WithMany(p => p.Tangcas)
                    .HasForeignKey(d => d.Manv)
                    .HasConstraintName("FK_TANGCA_NHANVIEN");
            });

            modelBuilder.Entity<Ungluong>(entity =>
            {
                entity.ToTable("UNGLUONG");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Manv).HasColumnName("MANV");

                entity.Property(e => e.Nam).HasColumnName("NAM");

                entity.Property(e => e.Ngay).HasColumnName("NGAY");

                entity.Property(e => e.Sotien).HasColumnName("SOTIEN");

                entity.Property(e => e.Thang).HasColumnName("THANG");

                entity.Property(e => e.Trangthai).HasColumnName("TRANGTHAI");

                entity.HasOne(d => d.ManvNavigation)
                    .WithMany(p => p.Ungluongs)
                    .HasForeignKey(d => d.Manv)
                    .HasConstraintName("FK_UNGLUONG_NHANVIEN");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
