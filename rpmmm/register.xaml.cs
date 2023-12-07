
using System.Text;
using System.Text.RegularExpressions;

using System.Windows;



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

        private void Button_Click_Regist(object sender, RoutedEventArgs e)
        {
            string login = log.Text;
            string firstName = firstt.Text;
            string secondName = second.Text;
            string patronymic = third.Text;
            string rekvezit = rekv.Text;
            string password = pas1.Password;
            string repeatPassword = pas2.Password;
            string reytt = reyt.Text;

            StringBuilder errorMessage = new StringBuilder();
            bool hasError = false;

            if (!Regex.IsMatch(firstName, @"^[а-яА-Яa-zA-Z]+$"))
            {
                errorMessage.AppendLine("Пожалуйста, введите корректное имя (только буквы).");
                hasError = true;
            }

            if (!Regex.IsMatch(secondName, @"^[а-яА-Яa-zA-Z]+$"))
            {
                errorMessage.AppendLine("Пожалуйста, введите корректную фамилию (только буквы).");
                hasError = true;
            }
            if (!Regex.IsMatch(patronymic, @"^[а-яА-Яa-zA-Z]+$"))
            {
                errorMessage.AppendLine("Пожалуйста, введите корректную фамилию (только буквы).");
                hasError = true;
            }


            if (!Regex.IsMatch(login, @"^[a-zA-Z0-9_]{4,}$"))
            {
                errorMessage.AppendLine("Пожалуйста, введите корректный логин (только буквы, цифры и _).");
                hasError = true;
            }
            if (!Regex.IsMatch(rekvezit, @"^\d+$"))
            {
                errorMessage.AppendLine("Пожалуйста, введите корректные реквезиты (только цифры).");
                hasError = true;
            }

            if (!Regex.IsMatch(reytt, @"^[1-5]$"))
            {
                errorMessage.AppendLine("Пожалуйста, введите рейтинг от 1 до 5.");
                hasError = true;
            }

            if (!Regex.IsMatch(password, @"^(?=.*[a-zA-Z])(?=.*[0-9!()-_]).{8,}$"))
            {
                errorMessage.AppendLine("Пожалуйста, введите корректный пароль (минимум 8 символов, хотя бы 1 буква, цифра или символ !()-_).");
                hasError = true;
            }

            if (hasError)
            {
                MessageBox.Show(errorMessage.ToString());
                return;
            }

            using (WiseLanceEntities3 db = new WiseLanceEntities3())
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Main avtorizUser = new Main();
            avtorizUser.Show();
            this.Close();
        }

        private void Button_Click_WL(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
