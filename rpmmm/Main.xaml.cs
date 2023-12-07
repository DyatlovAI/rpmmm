

using System.Windows;


namespace rpmmm
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        private WiseLanceEntities3 context;
        public Main()
        {
            InitializeComponent();
            this.context = context;
        }

        private void Button_Avtoriz_Click(object sender, RoutedEventArgs e)
        {

            AvtorizUser1 avt = new AvtorizUser1();
            avt.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AvtorizUser avt = new AvtorizUser();
            avt.Show();
            this.Close();
        }
    }
}
