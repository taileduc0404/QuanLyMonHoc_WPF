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
			hienthi();
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
				Phai = (x.Phai == true ? "Nam" : "Nữ")
			}).ToList();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			Malop_cb.ItemsSource = context.Lops.ToList();
			hienthi();
		}

		private void btnThem_Click(object sender, RoutedEventArgs e)
		{
			HocvienVM vm = gridHocvien.DataContext as HocvienVM;

			if (vm != null)
			{
				Lylich ll = new Lylich
				{
					Mshv = vm.Mshv,
					Tenhv = vm.Tenhv,
					Phai = bool.Parse(vm.Phai),
					Malop = vm.Malop,
					Ngaysinh = DateTime.Parse(vm.Ngaysinh),
				};
				context.Lyliches.Add(ll);
				context.SaveChanges();
				hienthi();
			}
		}

		private void Xoabtn_Click(object sender, RoutedEventArgs e)
		{

			//Lylich ll = dg.SelectedItem as Lylich;
			//var hocvien = context.Lyliches.Find(ll);
			//if (hocvien != null)
			//{
			//	context.Lyliches.Remove(hocvien);
			//	context.SaveChanges();
			//	hienthi() ;
			//}

			var selectedItem = dg.SelectedItem;

			if (selectedItem != null)
			{
				
				var selectedHocvien = (selectedItem as dynamic);

				
				string mshv = selectedHocvien.Mshv;

				
				var hocvien = context.Lyliches.Find(mshv);

				if (hocvien != null)
				{
					context.Lyliches.Remove(hocvien);
					context.SaveChanges();
					hienthi();
				}
			}
		}

		private void SuaBtn_Click(object sender, RoutedEventArgs e)
		{
			Button btn = sender as Button;
			Grid gr = btn.Parent as Grid;


			HocvienVM vm = gr.DataContext as HocvienVM;

			Lylich hocVienFind = context.Lyliches.Find(vm.Mshv);

			if (hocVienFind != null)
			{

				hocVienFind.Tenhv = vm.Tenhv;
				hocVienFind.Ngaysinh = DateTime.Parse(vm.Ngaysinh);
				hocVienFind.Phai = bool.Parse(vm.Phai);
				hocVienFind.Malop = vm.Malop;
		
				context.Lyliches.Update(hocVienFind);
				context.SaveChanges();
				hienthi();
			}
		}

		private void dg_Loading(object sender, DataGridRowDetailsEventArgs e)
		{
			dynamic hocvien = e.Row.Item;
			Lylich lylich = context.Lyliches.Find(hocvien.Mshv);

			// Thiết lập DataContext cho Grid trong RowDetailsTemplate
			Grid gridHocVien = e.DetailsElement.FindName("gridHocVien") as Grid;
			if (gridHocVien != null)
			{
				// Kiểm tra xem đối tượng lylich có khác null không
				if (lylich != null)
				{
					// Gán dữ liệu cho vm chỉ khi lylich khác null
					HocvienVM vm = new HocvienVM
					{
						Mshv = lylich.Mshv,
						Tenhv = lylich.Tenhv,
						Ngaysinh = lylich.Ngaysinh.ToString(), // Sử dụng định dạng mặc định
						Phai = lylich.Phai.ToString(),
						Malop = lylich.Malop,
						Tenlop = lylich.MalopNavigation?.Tenlop // Kiểm tra MalopNavigation có khác null không
					};

					// Thiết lập DataContext cho Grid
					gridHocVien.DataContext = vm;

					// Thiết lập DataContext cho combobox "Malop_cb"
					ComboBox Malop_cb = gridHocVien.FindName("Malop_cb") as ComboBox;
					if (Malop_cb != null)
					{
						Malop_cb.ItemsSource = context.Lops.ToList();
						Malop_cb.DataContext = vm;
					}
				}
			}
		}
	}
}
