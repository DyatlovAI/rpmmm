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
    /// Логика взаимодействия для register.xaml
    /// </summary>
    public partial class register : Window
    {
        public register()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AvtorizUser avtorizUser = new AvtorizUser();
            avtorizUser.Show();
            this.Close();
        }

        private void Button_Click_WL(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click_Regist(object sender, RoutedEventArgs e)
        {
            string login = log.Text;
            string firstName = firstt.Text;
            string secondName = second.Text;
            string patronymic = third.Text;
            string rekvezit = rekv.Text;
            string password = pas1.Text;
            string repeatPassword = pas2.Text;
            string reytt = reyt.Text;


            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(secondName)
                || string.IsNullOrWhiteSpace(rekvezit) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(repeatPassword))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            if (password != repeatPassword)
            {
                MessageBox.Show("Пароли не совпадают.");
                return;
            }
            string userTypeValue = (checkBoxZakazchik.IsChecked == true) ? "Zakazchik" : "Ispolnitel";

            using (WiseLanceEntities2 db = new WiseLanceEntities2())
            {
                string userType = (checkBoxZakazchik.IsChecked == true) ? "Zakazchik" : "Ispolnitel";
                dynamic newUser = null;

                if (userType == "Zakazchik")
                {
                    Zakazchik zakazchik = new Zakazchik
                    {
                        FirstName = firstName,
                        SecondName = secondName,
                        Patronymic = patronymic,
                        Reyt = reytt,
                        Rekvezit = rekvezit,
                        Loginad = login,
                        passwordd = password
                    };

                    db.Zakazchik.Add(zakazchik);

                    newUser = zakazchik;
                }
                else if (userType == "Ispolnitel")
                {
                    Ispolnitel ispolnitel = new Ispolnitel
                    {
                        FirstName = firstName,
                        SecondName = secondName,
                        Patronymic = patronymic,
                        Reyt = reytt,
                        Rekvezit = rekvezit,
                        Loginad = login,
                        passwordd = password
                    };

                    db.Ispolnitel.Add(ispolnitel);

                    newUser = ispolnitel;
                }

                db.SaveChanges();

                MessageBox.Show("Регистрация успешна.");
            }
        }
    }
}
