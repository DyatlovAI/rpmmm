
using System.Windows;

namespace rpmmm
{
    /// <summary>
    /// Логика взаимодействия для ProfileAZak.xaml
    /// </summary>
    public partial class ProfileAZak : Window
    {
        Zakazchik user;

        public ProfileAZak(Zakazchik user)
        {
            InitializeComponent();

            this.user = user;
            NewData();
        }

        public void NewData()
        {
            using (WiseLanceEntities3 db = new WiseLanceEntities3())
            {
                foreach (var e in db.Zakazchik)
                {
                    if (e.ID_zakazchik == user.ID_zakazchik)
                    {
                        lastNameTextBlock.Text = e.SecondName;
                        firstNameTextBlock.Text = e.FirstName;
                        patronymicTextBlock.Text = e.Patronymic;
                        ratingTextBlock.Text = e.Reyt;
                        requisitesTextBlock.Text = e.Rekvezit;

                    }
                }
            }
        }

    }
}
