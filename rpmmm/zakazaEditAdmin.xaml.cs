﻿
using System.Windows;


namespace rpmmm
{
    /// <summary>
    /// Логика взаимодействия для zakazaEditAdmin.xaml
    /// </summary>
    public partial class zakazaEditAdmin : Window
    {

        private Zakaz _originalData;

        public zakazaEditAdmin(Zakaz dataToEdit)
        {
            InitializeComponent();

           
            _originalData = dataToEdit;

           
            id.Text = dataToEdit.ID_zakaz.ToString();
            firstt.Text = dataToEdit.IdZakazchik.ToString();
            second.Text = dataToEdit.Opisaniye;
            third.Text = dataToEdit.Price.ToString();


        }

      
        public Zakaz GetEditedData()
        {
     
            var editedData = new Zakaz
            {
                ID_zakaz = int.Parse(id.Text),
                IdZakazchik = int.Parse(firstt.Text),
                Opisaniye = second.Text,
                Price = int.Parse(third.Text), 
                
            };

   
            return editedData;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!IsDataChanged())
            {
                MessageBox.Show("Данные не были изменены.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

          
            var editedData = GetEditedData();

            using (var dbContext = new WiseLanceEntities3()) 
            {
                var existingData = dbContext.Zakaz.Find(editedData.ID_zakaz);

                if (existingData != null)
                {
  
                    existingData.IdZakazchik = editedData.IdZakazchik;
                    existingData.Opisaniye = editedData.Opisaniye;
                    existingData.Price = editedData.Price;


                    dbContext.SaveChanges();
                }
            }

            DialogResult = true;
            Close();
        }

     
        private bool IsDataChanged()
        {
            var editedData = GetEditedData();

            return editedData.ID_zakaz != _originalData.ID_zakaz ||
                   editedData.IdZakazchik != _originalData.IdZakazchik ||
                   editedData.Opisaniye != _originalData.Opisaniye ||
                   editedData.Price != _originalData.Price ||
                   editedData.Vremya != _originalData.Vremya;
        }
    }
}