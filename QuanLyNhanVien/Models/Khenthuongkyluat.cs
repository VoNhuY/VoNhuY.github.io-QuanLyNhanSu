using System;
using System.Collections.Generic;

namespace QuanLyNhanVien.Models
{
    public partial class Khenthuongkyluat
    {
        public int Id { get; set; }
        public int? Soktlt { get; set; }
        public string? Noidung { get; set; }
        public DateTime? Ngay { get; set; }
        public int? Manv { get; set; }
        public int? Loai { get; set; }

        public virtual Nhanvien? ManvNavigation { get; set; }
    }
}
