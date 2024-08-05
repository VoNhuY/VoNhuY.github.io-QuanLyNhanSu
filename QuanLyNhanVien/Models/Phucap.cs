using System;
using System.Collections.Generic;

namespace QuanLyNhanVien.Models
{
    public partial class Phucap
    {
        public Phucap()
        {
            Nhanvienphucaps = new HashSet<Nhanvienphucap>();
        }

        public int Idpc { get; set; }
        public string? Tenpc { get; set; }
        public double? Sotien { get; set; }

        public virtual ICollection<Nhanvienphucap> Nhanvienphucaps { get; set; }
    }
}
