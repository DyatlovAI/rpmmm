
using System.Windows;

using System.Windows.Media;

namespace rpmmm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Avtoriz_Click(object sender, RoutedEventArgs e)
        {
            Main avtorizUser = new Main();
            avtorizUser.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AvtorizAdmin avtorizAdmin = new AvtorizAdmin();
            avtorizAdmin.Show();
            this.Close();
        }

        private void TextBlock_ColorChanged(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {

        }
    }
}
