using QuanLyMonHoc.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyMonHoc.ViewModels
{
    public class MonHocVM
    {
        public string? Msmh { get; set; }
        public string? Tenmh { get; set; }
        public int? Sotiet { get; set; }

        public static MonHocVM ChuyenDoi(Monhoc monhoc)
        {
            if (monhoc == null)
            {
                return null!;
            }
            return new MonHocVM
            {
                Msmh = monhoc.Msmh,
                Tenmh = monhoc.Tenmh,
                Sotiet = monhoc.Sotiet
            };
        }
    }
}
