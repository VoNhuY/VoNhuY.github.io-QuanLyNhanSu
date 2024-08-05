using System;
using System.Collections.Generic;

namespace QuanLyNhanVien.Models
{
    public partial class Bangluong
    {
        public int Idbangluong { get; set; }
        public int? Manv { get; set; }
        public string? Hoten { get; set; }
        public double? Luongcoban { get; set; }

        public virtual Nhanvien? ManvNavigation { get; set; }
    }
}
