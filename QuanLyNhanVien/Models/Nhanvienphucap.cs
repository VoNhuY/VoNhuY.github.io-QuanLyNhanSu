using System;
using System.Collections.Generic;

namespace QuanLyNhanVien.Models
{
    public partial class Nhanvienphucap
    {
        public string Id { get; set; } = null!;
        public int? Manv { get; set; }
        public int? Idpc { get; set; }
        public DateTime? Ngay { get; set; }
        public string? Noidung { get; set; }
        public double? Sotien { get; set; }

        public virtual Phucap? IdpcNavigation { get; set; }
        public virtual Nhanvien? ManvNavigation { get; set; }
    }
}
