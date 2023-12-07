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
    public partial class Koncurs1 : Window
    {
        private WiseLanceEntities3 db;
        public Koncurs1()
        {
            InitializeComponent();
            db = new WiseLanceEntities3();
           
        }

        private void Border_Loaded(object sender, RoutedEventArgs e)
        {
            using (WiseLanceEntities3 db = new WiseLanceEntities3())
            {
                var ispolnitelData = db.Koncurs.Take(6).ToList();

                SetTextOrPlaceholder(TextBlock1, ispolnitelData, 0);
                SetTextOrPlaceholder(TextBlock2, ispolnitelData, 1);
                SetTextOrPlaceholder(TextBlock3, ispolnitelData, 2);
                SetTextOrPlaceholder(TextBlock4, ispolnitelData, 3);
                SetTextOrPlaceholder(TextBlock5, ispolnitelData, 4);
                SetTextOrPlaceholder(TextBlock6, ispolnitelData, 5);
            }
        }
        private void SetTextOrPlaceholder(TextBlock textBlock, List<Koncurs> ispolnitelData, int index)
        {
            if (index < ispolnitelData.Count)
            {
                string fullName = $"Фамилия:{ispolnitelData[index].SecondName}\n Минимальный рейтинг:{ispolnitelData[index].MinReyt}\n Описание заказа:{ispolnitelData[index].Opisanie}\n Сколько дней:{ispolnitelData[index].Dni}\n Оплата:{ispolnitelData[index].Summa}";
                textBlock.Text = fullName;
            }
            
        }


        private void dataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
