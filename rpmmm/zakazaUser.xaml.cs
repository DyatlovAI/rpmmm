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
    /// Логика взаимодействия для zakazaUser.xaml
    /// </summary>
    public partial class zakazaUser : Window
    {
        private WiseLanceEntities3 db;
        public zakazaUser()
        {
            InitializeComponent();
            db = new WiseLanceEntities3();
            LoadData();
        }
        private Zakaz selectedZakaz;
        private void LoadData()
        {
            var zakazData = db.Zakaz.Include("Zakazchik").ToList();
            dataGrid.ItemsSource = zakazData;
        }
        
    }
}
