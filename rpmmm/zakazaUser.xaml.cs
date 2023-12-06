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

        public zakazaUser()
        {
            InitializeComponent();
            db = new WiseLanceEntities3();
            LoadData();
        }

        private void LoadData()
        {
            var zakazData = db.Zakaz.Include("Zakazchik").ToList();
            dataGrid.ItemsSource = zakazData;
        }

        private void Button_Click_Vibr(object sender, RoutedEventArgs e)
        {
            var selectedZakaz = dataGrid.SelectedItem as Zakaz;

            if (selectedZakaz != null)
            {
                zakazFril editWindow = new zakazFril(selectedZakaz,this); // Передаем this для обновления данных в zakazaUser
                editWindow.ShowDialog();
            }
        }

        public void UpdateSelectedZakaz(Zakaz updatedZakaz)
        {
            // Получаем коллекцию, которая является источником данных для dataGrid
            var itemsSource = dataGrid.ItemsSource as List<Zakaz>;

            if (itemsSource != null)
            {
                // Находим индекс элемента, который нужно обновить
                var index = itemsSource.IndexOf(_originalData);

                if (index != -1)
                {
                    // Заменяем элемент на обновленный
                    itemsSource[index] = updatedZakaz;
                }
            }
        }
    }
}
    

