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

namespace rpmmm
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
            int isZakazchik = Zakazchik.IsChecked == true ? 1 : 0;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите логин и пароль.");
                return;
            }

            Ispolnitel user = GetAuthenticatedUser(login, password, isZakazchik);
            if (user != null)
            {
                MessageBox.Show("Вход успешен!");
                

                Profile pr = new Profile(user);
                pr.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверные логин или пароль.");
            }
        }
    

        private dynamic GetAuthenticatedUser(string login, string password, int isZakazchik)
        {
            using (WiseLanceEntities3 db = new WiseLanceEntities3())
            {
                if (isZakazchik == 1)
                {
                    return db.Zakazchik.FirstOrDefault(u => u.Loginad == login && u.passwordd == password);
                }
                else
                {
                    return db.Ispolnitel.FirstOrDefault(u => u.Loginad == login && u.passwordd == password);
                }
            }
        }

        private bool AuthenticateUser(string login, string password, int isZakazchik)
        {
            using (WiseLanceEntities3 db = new WiseLanceEntities3())
            {
                Ispolnitel user = GetAuthenticatedUser(login, password, isZakazchik);
                return user != null;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
