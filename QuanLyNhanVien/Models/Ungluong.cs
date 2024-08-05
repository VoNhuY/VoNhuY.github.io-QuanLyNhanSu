using System;
using System.Collections.Generic;

namespace QuanLyNhanVien.Models
{
    public partial class Ungluong
    {
        public int Id { get; set; }
        public int? Nam { get; set; }
        public int? Thang { get; set; }
        public int? Ngay { get; set; }
        public double? Sotien { get; set; }
        public int? Trangthai { get; set; }
        public int? Manv { get; set; }

        public virtual Nhanvien? ManvNavigation { get; set; }
    }
}
