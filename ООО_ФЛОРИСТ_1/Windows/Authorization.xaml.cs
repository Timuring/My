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
using ООО_ФЛОРИСТ_1.Classes;
using ООО_ФЛОРИСТ_1.Models;

namespace ООО_ФЛОРИСТ_1.Windows
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
            Classes.Navigation.auth = this;
        }
        private void Enter_Click(object sender, RoutedEventArgs e)
        {

            if (Login.Text.Length != 0 && Password.Text.Length != 0)
            {
                Users user = App.context.Users.ToList().Find(u => u.UserLogin == Login.Text && u.UserPassword == Password.Text);
                Roles roles = App.context.Roles.ToList().Find(r => r.RoleId == 1);
                if (user != null)
                {
                    Alldata.ID = user.UserId;
                    Products win = new Products();
                    win.Show();
                    this.Close();
                }

                else
                    MessageBox.Show("Вы ввели неверные данные!");
            }
            else
                MessageBox.Show("Вы должны заполнить все поля!");
        }

        private void GuestEnter_Click(object sender, RoutedEventArgs e)
        {
            Alldata.ID = 0;
            Products win = new Products();
            win.Show();
            this.Close();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

