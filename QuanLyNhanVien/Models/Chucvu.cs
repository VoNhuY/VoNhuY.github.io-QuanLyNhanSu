using System;
using System.Collections.Generic;

namespace QuanLyNhanVien.Models
{
    public partial class Chucvu
    {
        public Chucvu()
        {
            Nhanviens = new HashSet<Nhanvien>();
        }

        public int Idcv { get; set; }
        public string? Tenchucvu { get; set; }

        public virtual ICollection<Nhanvien> Nhanviens { get; set; }
    }
}
