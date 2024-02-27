using Microsoft.EntityFrameworkCore;
using QuanLyMonHoc.Models;
using QuanLyMonHoc.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuanLyMonHoc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        qlhvContext qlhv = new qlhvContext();

        private void hienthi()
        {
            dg.ItemsSource = qlhv.Monhocs.ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hienthi();
        }

        private bool IsValid()
        {
            MonHocVM vm = new MonHocVM();
            if (vm.Msmh == null)
            {
                return false;
            }
            if (vm.Tenmh == null)
            {
                return false;
            }
            if (vm.Sotiet == null)
            {
                return false;
            }


            return true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Monhoc monhoc = new Monhoc();
            MonHocVM vm = gridMonHoc.DataContext as MonHocVM;
            var check = qlhv.Monhocs.FirstOrDefault(x => x.Msmh == vm!.Msmh);

            if (check != null)
            {
                MessageBox.Show($"Mã môn học {vm!.Msmh} đã tồn tại", "Success.", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                try
                {
                    monhoc.Msmh = vm!.Msmh;
                    monhoc.Tenmh = vm.Tenmh;
                    monhoc.Sotiet = vm.Sotiet;

					qlhv.Monhocs.Add(monhoc);
					qlhv.SaveChanges();
					hienthi();
					MessageBox.Show("Thêm thành công", "Success.", MessageBoxButton.OK, MessageBoxImage.Information);
				}
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

        }

        private void dg_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {

        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
			//qlhvContext db = new qlhvContext();
			//Monhoc maso = dg.SelectedItem as Monhoc;
			//var monhoc = db.Monhocs.Find(maso);

			var selectedItem = dg.SelectedItem;

			if (selectedItem != null)
			{

				var selectedMonhoc = (selectedItem as dynamic);


				string msmh = selectedMonhoc.Msmh;


				var monhocs = qlhv.Monhocs.Find(msmh);

				if (monhocs != null)
				{
					qlhv.Monhocs.Remove(monhocs);
					qlhv.SaveChanges();
					hienthi();
				}
			}
		}

        private void Sua_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Grid gr = btn.Parent as Grid;


            MonHocVM vm = gr.DataContext as MonHocVM;

            Monhoc monHocFind = qlhv.Monhocs.Find(vm.Msmh);

            if (monHocFind != null)
            {
                monHocFind.Msmh = vm.Msmh;
                monHocFind.Tenmh = vm.Tenmh;
                monHocFind.Sotiet = vm.Sotiet;
                qlhv.Monhocs.Update(monHocFind);
                qlhv.SaveChanges();
                hienthi();
            }
        }

        private void dg_LoadingRowDetails(object sender, DataGridRowDetailsEventArgs e)
        {
            string maso = dg.SelectedValue.ToString()!;
            Monhoc monhoc = qlhv.Monhocs.Find(maso);

            Grid gr = e.DetailsElement.FindName("gridMonHoc") as Grid;

            if (gr != null)
            {

                gr.DataContext = MonHocVM.ChuyenDoi(monhoc);
            }
            else
            {
                MessageBox.Show("Khong co du lieu");
            }

        }
    }
}
