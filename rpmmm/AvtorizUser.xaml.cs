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
using Microsoft.SqlServer.Server;
using rpmmm;

namespace rpmmm
{
    /// <summary>
    /// Логика взаимодействия для AvtorizUser.xaml
    /// </summary>
    public partial class AvtorizUser : Window
    {
        private WiseLanceEntities3 context;
        public AvtorizUser(WiseLanceEntities3 context)
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
            if (log.Text != "" && log.Text != "Логин" && pas.Password != "")
            {
                using (WiseLanceEntities3 db = new WiseLanceEntities3())
                {
                    bool isUserFound = false;

                    foreach (Ispolnitel user in db.Ispolnitel)
                    {
                        if (user.Loginad == log.Text && user.passwordd == pas.Password)
                        {
                            MessageBox.Show("Вход успешен");
                            Profile gl = new Profile(user);
                            gl.Show();
                            this.Close();
                            log.Text = "";
                            pas.Password = "";
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
        }

            
            

        
    

        private dynamic GetAuthenticatedUser(string login, string password)
        {
            using (WiseLanceEntities3 db = new WiseLanceEntities3())
            {

                
                    return db.Ispolnitel.FirstOrDefault(u => u.Loginad == login && u.passwordd == password);
               
            }
        }

    

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
