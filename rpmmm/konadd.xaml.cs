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
    /// Логика взаимодействия для konadd.xaml
    /// </summary>
    public partial class konadd : Window
    {
        public konadd()
        {
            InitializeComponent();
            
        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
                string secondName = first.Text;
                int reyting = int.Parse(second.Text);
                /*string summa = int.Parse(third.Text)*/;
                int summa = int.Parse(third.Text);
                string opiss = opis.Text;
                int dn = int.Parse(dni.Text);

                using (WiseLanceEntities3 db = new WiseLanceEntities3())
                {
                        Koncurs newEntity = new Koncurs
                        {

                            Opisanie = opiss,
                            Summa = summa,
                            MinReyt = reyting,
                            Dni = dn,
                            SecondName = secondName
                        };

                        db.Koncurs.Add(newEntity);
                        db.SaveChanges();
                        System.Windows.MessageBox.Show("Запись успешно добавлена.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                        Close();
                    }
                    
                
            }
            


        }
    }
 
