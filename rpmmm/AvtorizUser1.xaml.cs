
using System.Windows;



namespace rpmmm
{
    /// <summary>
    /// Логика взаимодействия для AvtorizUser1.xaml
    /// </summary>
    public partial class AvtorizUser1 : Window
    {
        public AvtorizUser1()
        {
            InitializeComponent();
        }

        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (log.Text != "" && log.Text != "Логин" && pas.Password != "")
            {
                using (WiseLanceEntities3 db = new WiseLanceEntities3())
                {
                    bool isUserFound = false;

                    foreach (Zakazchik user in db.Zakazchik)
                    {
                        if (user.Loginad == log.Text && user.passwordd == pas.Password)
                        {
                            MessageBox.Show("Вход успешен");
                            ProfileAZak gl = new ProfileAZak(user);
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            register pr = new register();
            pr.Show();
            this.Close();
        }
    }
}
