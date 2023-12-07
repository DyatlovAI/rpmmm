
using System.Collections.Generic;
using System.Linq;

using System.Windows;
using System.Windows.Controls;


namespace rpmmm
{
    /// <summary>
    /// Логика взаимодействия для Glavniy.xaml
    /// </summary>
    public partial class Glavniy : Window
    {
        public Glavniy()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
          
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
         
        }
        private void Border_Loaded(object sender, RoutedEventArgs e)
        {
            using (WiseLanceEntities3 db = new WiseLanceEntities3())
            {
                var ispolnitelData = db.Ispolnitel.Take(6).ToList();

                SetTextOrPlaceholder(TextBlock1, ispolnitelData, 0);
                SetTextOrPlaceholder(TextBlock2, ispolnitelData, 1);
                SetTextOrPlaceholder(TextBlock3, ispolnitelData, 2);
                SetTextOrPlaceholder(TextBlock4, ispolnitelData, 3);
                SetTextOrPlaceholder(TextBlock5, ispolnitelData, 4);
                SetTextOrPlaceholder(TextBlock6, ispolnitelData, 5);
            }
        }
            private void SetTextOrPlaceholder(TextBlock textBlock, List<Ispolnitel> ispolnitelData, int index)
            {
                if (index < ispolnitelData.Count)
                {
                    string fullName = $"{ispolnitelData[index].SecondName} {ispolnitelData[index].FirstName}";
                    textBlock.Text = fullName;
                }
                else
                {
                    textBlock.Text = "Здесь можешь быть ты";
                }
            }
        }
    }
    

