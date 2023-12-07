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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace rpmmm
{
    /// <summary>
    /// Логика взаимодействия для topPanelZakaz.xaml
    /// </summary>
    public partial class topPanelZakaz : UserControl
    {
        Zakazchik user;
        public topPanelZakaz()
        {
            this.user = user;
            
            InitializeComponent();
        }

        private void CloseWindow()
        {
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null)
            {
                parentWindow.Close();
            }
        }
        private void Button_Click_Pr(object sender, RoutedEventArgs e)
        {
            MainWindow pr = new MainWindow();
            pr.Show();
            this.CloseWindow();
        }

        private void Button_Click_Zakaz(object sender, RoutedEventArgs e)
        {

            zakazZakaz pr = new zakazZakaz(user);
            pr.Show();
            this.CloseWindow();
        }
        private void Button_Click_Home(object sender, RoutedEventArgs e)
        {

            Glavniy pr = new Glavniy();
            pr.Show();
            this.CloseWindow();
        }

        private void Button_Click_Conc(object sender, RoutedEventArgs e)
        {
            Koncurs pr = new Koncurs();
            pr.Show();
            this.CloseWindow();
        }

        private void Button_Click_Frilance(object sender, RoutedEventArgs e)
        {
            Glavniy pr = new Glavniy();
            pr.Show();
            this.CloseWindow();
        }
    }
}
