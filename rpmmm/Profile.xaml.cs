
using System.Windows;

namespace rpmmm
{
    /// <summary>
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        Ispolnitel user;
        
        public Profile(Ispolnitel user)
        {
            InitializeComponent();
            
            this.user = user;
            NewData();
        }

        public void NewData()
        {
            using (WiseLanceEntities3 db = new WiseLanceEntities3())
            {
                foreach (var e in db.Ispolnitel)
                {
                    if (e.ID_Ispolnitel == user.ID_Ispolnitel)
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
