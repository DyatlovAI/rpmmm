

using System.Windows;

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
