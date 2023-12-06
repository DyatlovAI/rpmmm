using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
            AvtorizUser avt = new AvtorizUser(context);
            avt.Show();
            this.Close();
        }
    }
}
