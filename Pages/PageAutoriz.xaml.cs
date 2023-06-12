using CherednichenkoKursovoi.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CherednichenkoKursovoi.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAutoriz.xaml
    /// </summary>
    public partial class PageAutoriz : Page
    {
        public PageAutoriz()
        {
            InitializeComponent();
        }

        private void BtnEnter_Click(object sender, RoutedEventArgs e)
        {

            var userObj = AirEntities.GetContext().User.FirstOrDefault(x => x.Login == TbLog.Text && x.Password == PBPass.Password);

            try
            {
                if (userObj == null)
                {
                    MessageBox.Show("Введите верные логин и пароль");
                    return;
                }
                
                else
                {
                    switch (userObj.IdRole)
                    {
                        case 1:
                            {
                                Manager.Dostup = 1;
                                MessageBox.Show($"Здравствуйте, администратор {userObj.Familia} {userObj.Name} {userObj.Otchestvo}");
                                Manager.MainFrame.Navigate(new PageZakaz());
                                break;
                            }
                        case 2:
                            {
                                Manager.Dostup = 2;
                                MessageBox.Show($"Здравствуйте, менеджер {userObj.Familia} {userObj.Name} {userObj.Otchestvo}");
                                Manager.MainFrame.Navigate(new PageZakaz());
                                break;
                            }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
    }
}
