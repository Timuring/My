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
using ООО_ФЛОРИСТ_1.Models;

namespace ООО_ФЛОРИСТ_1.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        public AddProduct()
        {
            InitializeComponent();
            List<Manufacturers> mfs = App.context.Manufacturers.ToList();
            foreach (Manufacturers m in mfs)
            {
                Manufacturer.Items.Add(m.ManufacturerName);
            }

            List<Suppliers> sups = App.context.Suppliers.ToList();
            foreach (Suppliers s in sups)
            {
                Supplier.Items.Add(s.SupplierName);
            }

            List<Category> cats = App.context.Category.ToList();
            foreach (Category c in cats)
            {
                Category.Items.Add(c.CategoryName);
            }
            List<Units> units = App.context.Units.ToList();
            foreach (Units u in units)
            {
                Unit.Items.Add(u.UnitName);
            }
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (Article.Text.Length != 0 && Title.Text.Length != 0 && Unit.Text.Length != 0
                && Cost.Text.Length != 0 && MaxDiscount.Text.Length != 0 && Manufacturer.Text.Length != 0
                && Supplier.Text.Length != 0 && Category.Text.Length != 0 && Discount.Text.Length != 0
                && Stock.Text.Length != 0 && Description.Text.Length != 0)
            {
                try
                {
                    MySql.Data.MySqlClient.MySqlCommand com = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO `florist`.`Products` " +
                        "(`ProductArticleNumber`, `ProductName`, `UnitId`, `ProductCost`, `MaxDiscountAmount`, `ManufacturerId`, `SupplierId`, `CategoryId`, " +
                        "`ProductDiscountAmount`, `ProductQuantityInStock`, `ProductDescription`) VALUES " + "('" + Article.Text + "', '" + Title.Text + "', '" + (Unit.SelectedIndex + 1) + "', '" + Cost.Text + "', '" + MaxDiscount.Text + "', '" + (Manufacturer.SelectedIndex + 1) + "', " +
                        "'" + (Supplier.SelectedIndex + 1) + "', '" + (Category.SelectedIndex + 1) + "', '" + Discount.Text + "', '" + Stock.Text + "', '" + Description.Text + "');", Classes.Connection.con);
                    com.ExecuteNonQuery();
                    this.Close();
                    Classes.Navigation.products.LoadData();
                }
                catch
                {
                    MessageBox.Show("Вы ввели неверные данные!");
                }
            }
            else
                MessageBox.Show("Вы должны заполнить все поля!");
        }
    }
}