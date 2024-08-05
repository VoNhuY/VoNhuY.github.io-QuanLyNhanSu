using System;
using System.Collections.Generic;

namespace QuanLyNhanVien.Models
{
    public partial class Bangcong
    {
        public int Idbc { get; set; }
        public int? Nam { get; set; }
        public int? Thang { get; set; }
        public int? Ngay { get; set; }
        public int? Giovao { get; set; }
        public int? Giora { get; set; }
        public int? Phutra { get; set; }
        public int? Manv { get; set; }
        public int? LDloaicong { get; set; }

        public virtual Loaicong? LDloaicongNavigation { get; set; }
        public virtual Nhanvien? ManvNavigation { get; set; }
    }
}
