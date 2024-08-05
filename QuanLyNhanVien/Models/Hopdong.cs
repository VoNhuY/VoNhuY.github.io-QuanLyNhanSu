using System;
using System.Collections.Generic;

namespace QuanLyNhanVien.Models
{
    public partial class Hopdong
    {
        public int Sohd { get; set; }
        public DateTime? Ngaybatdau { get; set; }
        public DateTime? Ngayketthuc { get; set; }
        public DateTime? Ngayky { get; set; }
        public string? Noidung { get; set; }
        public int? Lanky { get; set; }
        public string? Thoihan { get; set; }
        public double? Hesoluong { get; set; }
        public int? Manv { get; set; }

        public virtual Nhanvien? ManvNavigation { get; set; }
    }
}
