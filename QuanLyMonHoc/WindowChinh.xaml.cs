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
    /// Interaction logic for WindowChinh.xaml
    /// </summary>
    public partial class WindowChinh : Window
    {
        public WindowChinh()
        {
            InitializeComponent();
        }

        private void menuMonHoc_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
        }

        private void menuHocVien_Click(object sender, RoutedEventArgs e)
        {
            WindowHocvien windowHocvien = new WindowHocvien();
            windowHocvien.Show();
        }
    }
}
