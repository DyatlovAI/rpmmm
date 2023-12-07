
using System.Windows;
using System.Windows.Controls;


namespace rpmmm
{
    /// <summary>
    /// Логика взаимодействия для topPanel.xaml
    /// </summary>
    public partial class topPanel : UserControl
    {
        public topPanel()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.CloseWindow();
        }
        private void CloseWindow() 
        {
        Window parentWindow= Window.GetWindow(this);
            if(parentWindow != null)
            {
                parentWindow.Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Glavniy gl = new Glavniy();
            gl.Show();
            this.CloseWindow();
        }

        private void Button_Click_Zakaz(object sender, RoutedEventArgs e)
        {
            zakaza zak = new zakaza();
            zak.Show();
            this.CloseWindow();
        }

        private void Button_Click_Fril(object sender, RoutedEventArgs e)
        {
            Glavniy gl = new Glavniy();
            gl.Show();
            this.CloseWindow();
        }

        private void Button_Click_Concurs(object sender, RoutedEventArgs e)
        {
            Koncurs kon = new Koncurs();
            kon.Show();
            this.CloseWindow();
        }
    }
}
