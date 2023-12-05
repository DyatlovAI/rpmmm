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
    /// Логика взаимодействия для zad.xaml
    /// </summary>
    public partial class zad : Window
    {
        Zakaz zak;
        public zad(Zakaz zak)
        {
            InitializeComponent();
            this.zak = zak;
            NewData();
        }
        public void NewData()
        {
            using (WiseLanceEntities3 db = new WiseLanceEntities3())
            {
                foreach (var e in db.Zakaz)
                {
                    if (e.ID_zakaz == zak.ID_zakaz)
                    {
                        op.Text = e.Opisaniye;
                        pr.Text = e.Price.ToString();
                    }
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
