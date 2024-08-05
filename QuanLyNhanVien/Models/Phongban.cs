using System;
using System.Collections.Generic;

namespace QuanLyNhanVien.Models
{
    public partial class Phongban
    {
        public Phongban()
        {
            Nhanviens = new HashSet<Nhanvien>();
        }

        public int Idpb { get; set; }
        public string? Tenpb { get; set; }

        public virtual ICollection<Nhanvien> Nhanviens { get; set; }
    }
}
