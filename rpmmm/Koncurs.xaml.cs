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
    /// Логика взаимодействия для Koncurs.xaml
    /// </summary>
    public partial class Koncurs : Window
    {
        private WiseLanceEntities3 db;
        public Koncurs()
        {
            InitializeComponent();
            db = new WiseLanceEntities3();
            LoadData();
        }

        private async void LoadData()
        {
            await LoadDataAsync().ConfigureAwait(true);
        }

        private async Task LoadDataAsync()
        {
            int reyt;
        }


        private void dataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
