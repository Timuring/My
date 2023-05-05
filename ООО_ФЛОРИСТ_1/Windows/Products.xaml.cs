using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Linq;
using System.IO;
using ООО_ФЛОРИСТ_1.Models;
using ООО_ФЛОРИСТ_1.Classes;

namespace ООО_ФЛОРИСТ_1.Windows
{
    /// <summary>
    /// Логика взаимодействия для Products.xaml
    /// </summary>
    public partial class Products : Window
    {
        public Products()
        {
            InitializeComponent();
            LoadData();
            Classes.Navigation.products = this;
            Users user = App.context.Users.ToList().Find(u => u.UserId == Alldata.ID); //поиск пользователя за которого авторизовались
            if (Alldata.ID != 0)
            {


                if (user.UserRole == 3) // если авторизованный пользователь имеет айди 2 - администратор
                {
                    Add.Visibility = Visibility.Visible;
                    Edit.Visibility = Visibility.Visible;
                    Delete.Visibility = Visibility.Visible;

                    name.Content = user.FIO;
                    dolj.Content = user.dolgnost;
                }
                if (user.UserRole == 1) // если авторизованный пользователь имеет айди 1 - клиент
                {
                    name.Content = user.FIO;
                    dolj.Content = user.dolgnost;
                }
                if (user.UserRole == 2) // если авторизованный пользователь имеет айди 3 - менеджер
                {
                    name.Content = user.FIO;
                    dolj.Content = user.dolgnost;
                }
            }

            LoadData();
            Classes.Connection.con.Open();
        }
        private void Desc_Checked(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void Asc_Checked(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void Filtration_DropDownClosed(object sender, EventArgs e)
        {
            LoadData();
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoadData();
        }
        public void LoadData() //обновление окна при какихто изменениях
        {
            ProductView.Children.Clear();
            List<Models.Products> list = App.context.Products.ToList();
            if (Filtration.SelectedItem != null)
            {
                switch (Filtration.SelectedIndex)
                {
                    case 0:
                        list = App.context.Products.ToList();
                        break;
                    case 1:
                        list = list.Where(p => p.ProductDiscountAmount > 0 && p.ProductDiscountAmount < Convert.ToDecimal(9.99)).ToList();
                        break;
                    case 2:
                        list = list.Where(p => p.ProductDiscountAmount > 10 && p.ProductDiscountAmount < Convert.ToDecimal(14.99)).ToList();
                        break;
                    case 3:
                        list = list.Where(p => p.ProductDiscountAmount >= 15 && p.ProductDiscountAmount < 100).ToList();
                        break;
                }
            }
            if (Search.Text.Length != 0)
                list = list.Where(p => p.ProductName.Contains(Search.Text)).ToList();
            if (Asc.IsChecked == true)
                list = list.OrderBy(p => p.ProductCost).ToList();
            else if (Desc.IsChecked == true)
                list = list.OrderByDescending(p => p.ProductCost).ToList();

            foreach (var item in list)
                ProductView.Children.Add(new UserControls.ProductCard(item.ProductArticleNumber, item.ProductName, item.ProductDescription, item.ManufacturerId.ToString(), item.ProductCost.ToString(), item.ProductDiscountAmount.ToString(), Convert.ToDecimal(item.ProductDiscountAmount), item.ProductPhoto));
        }


        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddProduct win = new AddProduct();
            win.Show();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand("DELETE FROM Products WHERE ProductArticleNumber = '" + Classes.Navigation.Atricle + "'", Classes.Connection.con);
                command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Невозможно удалить этот продукт!");
            }
            LoadData();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Authorization authorization = new Authorization();
            authorization.Show();
            this.Close();
            Classes.Connection.con.Close();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
