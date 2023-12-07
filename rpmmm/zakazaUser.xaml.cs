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
        private Zakaz _originalData;
        private WiseLanceEntities3 db;
        private List<Zakaz> allZakazData;
        public zakazaUser()
        {
            InitializeComponent();
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
        private void Button_Click_Vibr(object sender, RoutedEventArgs e)
        {
            var selectedZakaz = dataGrid.SelectedItem as Zakaz;

            if (selectedZakaz != null)
            {
                zakazFril editWindow = new zakazFril(selectedZakaz,this); 
                editWindow.ShowDialog();
            }
        }

        public void UpdateSelectedZakaz(Zakaz updatedZakaz)
        {
          
            var itemsSource = dataGrid.ItemsSource as List<Zakaz>;

            if (itemsSource != null)
            {
       
                var index = itemsSource.IndexOf(_originalData);

                if (index != -1)
                {

                    itemsSource[index] = updatedZakaz;
                }
            }
        }
        private void ResetFilter_Click(object sender, RoutedEventArgs e)
        {
            categoryFilter.SelectedItem = null;
            LoadData();
        }
    }
}
    

