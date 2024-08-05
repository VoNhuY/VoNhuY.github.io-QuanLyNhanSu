using System;
using System.Collections.Generic;

namespace QuanLyNhanVien.Models
{
    public partial class Baohiem
    {
        public int Idbh { get; set; }
        public string? Sobh { get; set; }
        public DateTime? Ngaycap { get; set; }
        public string? Noicap { get; set; }
        public string? Noidkikhambenh { get; set; }
        public int? Manv { get; set; }

        public virtual Nhanvien? ManvNavigation { get; set; }
    }
}
