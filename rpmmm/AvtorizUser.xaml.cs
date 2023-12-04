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
using rpmmm;

namespace rpmm
{
    /// <summary>
    /// Логика взаимодействия для AvtorizUser.xaml
    /// </summary>
    public partial class AvtorizUser : Window
    {
        public AvtorizUser()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            register reg = new register();
            reg.Show();
            this.Close();
        }

        private void Button_Click_WL(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            register reg = new register();
            reg.Show();
            this.Close();
        }

        private void Button_Click_GL(object sender, RoutedEventArgs e)
        {
            string login = log.Text;
            string password = pas.Text;
            bool isZakazchik = Zakazchik.IsChecked == true;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите логин и пароль.");
                return;
            }

            bool isAuthenticated = AuthenticateUser(login, password, isZakazchik);

            if (isAuthenticated)
            {
                MessageBox.Show("Вход успешен!");
                Glavniy gl = new Glavniy();
                gl.Show();
                this.Close();
                // Здесь вы можете перейти на другую страницу, показать главное окно и т. д.
            }
            else
            {
                MessageBox.Show("Неверные логин или пароль.");
            }
        }

        private bool AuthenticateUser(string login, string password, bool isZakazchik)
        {
            using (WiseLanceEntities2 db = new WiseLanceEntities2())
            {
                if (isZakazchik)
                {
                    var user = db.Zakazchik.FirstOrDefault(u => u.Loginad == login && u.passwordd == password);
                    return user != null;
                }
                else
                {
                    var user = db.Ispolnitel.FirstOrDefault(u => u.Loginad == login && u.passwordd == password);
                    return user != null;
                }
            }
        }

            private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            forgot forl = new forgot();
            forl.Show();
            this.Close();
        }
    }
}
