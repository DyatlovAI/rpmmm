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
