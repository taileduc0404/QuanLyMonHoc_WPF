using QuanLyMonHoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QuanLyMonHoc
{
    /// <summary>
    /// Interaction logic for WindowHocvien.xaml
    /// </summary>
    public partial class WindowHocvien : Window
    {
        public WindowHocvien()
        {
            InitializeComponent();
            //hienthi();
        }

        qlhvContext context = new qlhvContext();
        private void hienthi()
        {
            dg.ItemsSource = context.Lyliches.Select(x => new
            {
                Mshv = x.Mshv,
                Tenhv = x.Tenhv,
                Ngaysinh = x.Ngaysinh,
                Malop = x.Malop,
                Lop = x.MalopNavigation,
                Phai = x.Phai
            }).ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hienthi();
        }
    }
}
