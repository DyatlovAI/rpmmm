
using System.Windows;


namespace rpmmm
{
    /// <summary>
    /// Логика взаимодействия для konadd.xaml
    /// </summary>
    public partial class konadd : Window
    {
        public konadd()
        {
            InitializeComponent();
            
        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string secondName = first.Text;
            string reytingText = second.Text;
            string summaText = third.Text;
            string opiss = opis.Text;
            string dnText = dni.Text;
            if (string.IsNullOrEmpty(secondName))
            {
                System.Windows.MessageBox.Show("Пожалуйста, введите имя.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!int.TryParse(reytingText, out int reyting) || reyting < 1 || reyting > 5)
            {
                System.Windows.MessageBox.Show("Пожалуйста, введите корректный рейтинг от 1 до 5.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!int.TryParse(summaText, out int summa) || summa <= 0)
            {
                System.Windows.MessageBox.Show("Пожалуйста, введите корректную положительную сумму.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!int.TryParse(dnText, out int dn) || dn <= 0)
            {
                System.Windows.MessageBox.Show("Пожалуйста, введите корректное положительное количество дней.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            using (WiseLanceEntities3 db = new WiseLanceEntities3())
            {
                Koncurs newEntity = new Koncurs
                {
                    Opisanie = opiss,
                    Summa = summa,
                    MinReyt = reyting,
                    Dni = dn,
                    SecondName = secondName
                };

                db.Koncurs.Add(newEntity);
                db.SaveChanges();
                System.Windows.MessageBox.Show("Запись успешно добавлена.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }


        }
            


        }
    }
 
