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
        private List<Zakaz> allZakazData;
        public zakazZakaz(Zakazchik user)
        {

            InitializeComponent();
            this.user = user;
            db = new WiseLanceEntities3();
            LoadCategories();
            LoadData();
        }

        private void LoadCategories()
        {
            var categories = db.Zakaz.Select(z => z.Kategoria).Distinct().ToList();
            categoryFilter.ItemsSource = categories;
        }

        private void CategoryFilter_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            RefreshDataGrid();
        }



        private void LoadData()
        {
            allZakazData = db.Zakaz?.Include("Zakazchik").ToList();
            dataGrid.ItemsSource = allZakazData;
        }

        private void RefreshDataGrid()
        {
            string selectedCategory = categoryFilter.SelectedItem as string;

            if (!string.IsNullOrEmpty(selectedCategory))
            {
                var filteredData = allZakazData?.Where(z => z.Kategoria == selectedCategory).ToList();
                if (filteredData != null)
                {
                    dataGrid.ItemsSource = filteredData;
                }
            }
            else
            {
                LoadData();
            }
        }
        private void ResetFilter_Click(object sender, RoutedEventArgs e)
        {
            categoryFilter.SelectedItem = null;
            LoadData();
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
