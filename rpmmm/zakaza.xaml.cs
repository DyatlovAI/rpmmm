using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace rpmmm
{
    public partial class zakaza : Window
    {
        private WiseLanceEntities3 db;
        private List<Zakaz> allZakazData;

        public zakaza()
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

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem is Zakaz selectedItem)
            {
                db.Zakaz.Remove(selectedItem);
                db.SaveChanges();
                RefreshDataGrid();
            }
        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {
            var selectedData = GetSelectedData();
            zakazaEditAdmin editWindow = new zakazaEditAdmin(selectedData);
            editWindow.ShowDialog();
            if (editWindow.DialogResult == true)
            {
                var editedData = editWindow.GetEditedData();
                RefreshDataGrid();
            }
        }

        private Zakaz GetSelectedData()
        {
            var selectedRow = dataGrid.SelectedItem as Zakaz;
            return selectedRow;
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            zakazaAddAdmin editWindow = new zakazaAddAdmin();
            var result = editWindow.ShowDialog();
            if (result == true)
            {
                RefreshDataGrid();
            }
        }
        private void ResetFilter_Click(object sender, RoutedEventArgs e)
        {
            categoryFilter.SelectedItem = null;
            LoadData();
        }
    }
}