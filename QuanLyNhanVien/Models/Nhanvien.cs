using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuanLyNhanVien.Models
{
    public partial class Nhanvien
    {
        public Nhanvien()
        {
            Bangcongs = new HashSet<Bangcong>();
            Bangluongs = new HashSet<Bangluong>();
            Baohiems = new HashSet<Baohiem>();
            Hopdongs = new HashSet<Hopdong>();
            Khenthuongkyluats = new HashSet<Khenthuongkyluat>();
            Nhanvienphucaps = new HashSet<Nhanvienphucap>();
            Tangcas = new HashSet<Tangca>();
            Ungluongs = new HashSet<Ungluong>();
        }

        public int Manv { get; set; }
        [Display(Name = "Họ và Tên")]
        public string? Hoten { get; set; }
        [Display(Name = "Giới tính")]
        public bool? Gioitinh { get; set; }
        [Display(Name = "Ngày sinh")]
        public DateTime? Ngaysinh { get; set; }
        [Display(Name = "SĐT")]
        public string? Sdt { get; set; }
        public string? Cccd { get; set; }
        [Display(Name = "Địa chỉ")]
        public string? Diachi { get; set; }
        [Display(Name = "Hình ảnh")]
        public byte[]? Hinhanh { get; set; }
        public int? Idpb { get; set; }
        public int? Idbp { get; set; }
        public int? Idcv { get; set; }
        [Display(Name = "Mã chức vụ")]
        public virtual Chucvu? IdcvNavigation { get; set; }
        [Display(Name = "Mã phòng ban")]
        public virtual Phongban? IdpbNavigation { get; set; }
        public virtual ICollection<Bangcong> Bangcongs { get; set; }
        public virtual ICollection<Bangluong> Bangluongs { get; set; }
        public virtual ICollection<Baohiem> Baohiems { get; set; }
        public virtual ICollection<Hopdong> Hopdongs { get; set; }
        public virtual ICollection<Khenthuongkyluat> Khenthuongkyluats { get; set; }
        public virtual ICollection<Nhanvienphucap> Nhanvienphucaps { get; set; }
        public virtual ICollection<Tangca> Tangcas { get; set; }
        public virtual ICollection<Ungluong> Ungluongs { get; set; }
    }
}
