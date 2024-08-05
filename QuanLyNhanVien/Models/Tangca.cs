using System;
using System.Collections.Generic;

namespace QuanLyNhanVien.Models
{
    public partial class Tangca
    {
        public int Id { get; set; }
        public int? Nam { get; set; }
        public int? Thang { get; set; }
        public int? Ngay { get; set; }
        public double? Sogio { get; set; }
        public int? Manv { get; set; }
        public int? Idloaica { get; set; }

        public virtual Loaica? IdloaicaNavigation { get; set; }
        public virtual Nhanvien? ManvNavigation { get; set; }
    }
}
