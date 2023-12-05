using System;
using System.Collections.Generic;
using System.Globalization;
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
using Xceed.Wpf.Toolkit;

namespace rpmmm
{
    /// <summary>
    /// Логика взаимодействия для zakazaAddAdmin.xaml
    /// </summary>
    public partial class zakazaAddAdmin : Window
    {
        public zakazaAddAdmin()
        {
            InitializeComponent();
            Loaded += zakazaAddAdmins;

        }
        private void zakazaAddAdmins(object sender, RoutedEventArgs e)
        {
            InitializeComboBox();
        }
        private void InitializeComboBox()
        {
            using (WiseLanceEntities2 db = new WiseLanceEntities2())
            {
                var zakazchikData = db.Zakazchik.ToList();
                firstt.ItemsSource = zakazchikData;
                firstt.DisplayMemberPath = "ID_zakazchik";
                firstt.SelectedValuePath = "ID_zakazchik";
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                string timeText = timeTextBox.Text;
                int selectedZakazchikId = (int)firstt.SelectedValue;
                string opisaniye = second.Text;
                int price = int.Parse(third.Text);

                using (WiseLanceEntities2 db = new WiseLanceEntities2())
                {
                    if (TimeSpan.TryParse(timeText, out TimeSpan fixedTime))
                    {
                        Zakaz newEntity = new Zakaz
                        {
                            Opisaniye = opisaniye,
                            Price = price,
                            Vremya = fixedTime,
                            IdZakazchik = selectedZakazchikId
                        };

                        db.Zakaz.Add(newEntity);
                        db.SaveChanges();
                        System.Windows.MessageBox.Show("Запись успешно добавлена.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                        Close();
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Некорректный формат времени. Пожалуйста, введите время в формате HH:mm.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }
        }
  
      
    }

    

