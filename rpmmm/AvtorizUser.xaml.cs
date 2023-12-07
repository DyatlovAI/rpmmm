
using System.Linq;
using System.Windows;


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
