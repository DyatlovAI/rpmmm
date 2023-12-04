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

namespace rpmmm
{
    /// <summary>
    /// Логика взаимодействия для forgot.xaml
    /// </summary>
    public partial class forgot : Window
    {
        public forgot()
        {
            InitializeComponent();
        }

        private void Button_Click_GL(object sender, RoutedEventArgs e)
        {
            AvtorizUser reg = new AvtorizUser();
            reg.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AvtorizUser reg2 = new AvtorizUser();
            reg2.Show();
            this.Close();
        }

        private void Button_Click_WL(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
