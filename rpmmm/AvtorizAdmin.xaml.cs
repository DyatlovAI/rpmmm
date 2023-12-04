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
    /// Логика взаимодействия для AvtorizAdmin.xaml
    /// </summary>
    public partial class AvtorizAdmin : Window
    {
        public AvtorizAdmin()
        {
            InitializeComponent();
        }

        private void Button_Click_WL(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            

            if (log.Text != "" && log.Text != "Логин" && pas.Text != "")
            {
                using (WiseLanceEntities2 db = new WiseLanceEntities2())
                {
                    bool isUserFound = false;

                    foreach (Adminis user in db.Adminis)
                    {
                        if (user.Loginad == log.Text && user.passwordd == pas.Text)
                        {
                            MessageBox.Show("Вход успешен");
                            Profile profile = new Profile(user);
                            profile.Show();
                            this.Close();
                            log.Text = "";
                            pas.Text = "";
                            isUserFound = true;
                            break;
                        }
                    }

                    if (!isUserFound)
                    {
                        MessageBox.Show("Пользователь не найден");
                    }
                }
            }
        
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }
    }
    }

