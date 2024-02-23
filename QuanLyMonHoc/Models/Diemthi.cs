using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyMonHoc.Models
{
    public partial class Diemthi
    {
        public string Mshv { get; set; }
        public string Msmh { get; set; }
        public string Diem { get; set; }

        public virtual Lylich MshvNavigation { get; set; }
        public virtual Monhoc MsmhNavigation { get; set; }
    }
}
