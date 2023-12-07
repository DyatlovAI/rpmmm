
using System.Windows;


namespace rpmmm
{
    /// <summary>
    /// Логика взаимодействия для zakazFril.xaml
    /// </summary>
    public partial class zakazFril : Window
    {
        private Zakaz _originalData;

        private zakazaUser _parentWindow;

        public zakazFril(Zakaz dataToEdit, zakazaUser parentWindow)
        {
            InitializeComponent();
            _originalData = dataToEdit;
            _parentWindow = parentWindow;

            if (dataToEdit.IdZakazchik.HasValue)
            {
                second.Text = dataToEdit.IdZakazchik.Value.ToString();
            }
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
                var existingData = dbContext.Zakaz.Find(_originalData.ID_zakaz);

                if (existingData != null)
                {
                    existingData.IdZakazchik = editedData.IdZakazchik;

                    dbContext.SaveChanges();
                }
            }

            _parentWindow.UpdateSelectedZakaz(editedData);

            DialogResult = true;
            Close();
        }
        public Zakaz GetEditedData()
        {

            var editedData = new Zakaz
            {
                
                IdZakazchik = int.Parse(second.Text),
                

            };


            return editedData;
        }
        private bool IsDataChanged()
        {
            var editedData = GetEditedData();

            return _originalData != null &&
                   _originalData.IdZakazchik != editedData.IdZakazchik;
        }
    }
}
