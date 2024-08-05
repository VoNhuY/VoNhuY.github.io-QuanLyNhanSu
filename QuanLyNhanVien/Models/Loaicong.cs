using System;
using System.Collections.Generic;

namespace QuanLyNhanVien.Models
{
    public partial class Loaicong
    {
        public Loaicong()
        {
            Bangcongs = new HashSet<Bangcong>();
        }

        public int Idloaicong { get; set; }
        public string? Tenloaicong { get; set; }
        public double? Heso { get; set; }

        public virtual ICollection<Bangcong> Bangcongs { get; set; }
    }
}
