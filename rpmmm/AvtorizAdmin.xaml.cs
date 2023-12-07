
using System.Windows;

namespace rpmmm
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
            

            if (log.Text != "" && log.Text != "Логин" && pas.Password != "")
            {
                using (WiseLanceEntities3 db = new WiseLanceEntities3())
                {
                    bool isUserFound = false;

                    foreach (Adminis user in db.Adminis)
                    {
                        if (user.Loginad == log.Text && user.passwordd == pas.Password)
                        {
                            MessageBox.Show("Вход успешен");
                            Glavniy gl = new Glavniy();
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
        
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }
    }
    }

