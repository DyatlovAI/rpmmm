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
    /// Логика взаимодействия для zakazZakaz.xaml
    /// </summary>
    public partial class zakazZakaz : Window
    {
        private WiseLanceEntities3 db;
        Zakazchik user;
        public zakazZakaz(Zakazchik user)
        {

            InitializeComponent();
            this.user = user;
            db = new WiseLanceEntities3();
            LoadData();

        }

        private Zakaz selectedZakaz;
        private void LoadData()
        {
            var zakazData = db.Zakaz.Include("Zakazchik").ToList();
            dataGrid.ItemsSource = zakazData;
        }
        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            zakazaAddAdmin editWindow = new zakazaAddAdmin();
            var result = editWindow.ShowDialog();
        }
        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem is Zakaz selectedItem)
            {
                db.Zakaz.Remove(selectedItem);
                db.SaveChanges();
                LoadData();
            }
        }
        private void Button_Click_Red(object sender, RoutedEventArgs e)
        {

            var selectedData = GetSelectedData();


            zakazaEditAdmin editWindow = new zakazaEditAdmin(selectedData);
            editWindow.ShowDialog();
            if (editWindow.DialogResult == true)
            {
                var editedData = editWindow.GetEditedData();
            }
        }
        private Zakaz GetSelectedData()
        {
            var selectedRow = dataGrid.SelectedItem as Zakaz;
            return selectedRow;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
