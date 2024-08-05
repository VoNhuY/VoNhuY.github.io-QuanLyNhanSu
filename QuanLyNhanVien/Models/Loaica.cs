using System;
using System.Collections.Generic;

namespace QuanLyNhanVien.Models
{
    public partial class Loaica
    {
        public Loaica()
        {
            Tangcas = new HashSet<Tangca>();
        }

        public int Idloaica { get; set; }
        public string? Tenloaica { get; set; }
        public double? Heso { get; set; }

        public virtual ICollection<Tangca> Tangcas { get; set; }
    }
}
