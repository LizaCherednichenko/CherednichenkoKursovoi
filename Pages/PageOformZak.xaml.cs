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
    /// Логика взаимодействия для PageOformZak.xaml
    /// </summary>
    public partial class PageOformZak : Page
    {
        public PageOformZak()
        {
            InitializeComponent();

            CBPass.ItemsSource = AirEntities.GetContext().Passajir.ToList();
            CBReis.ItemsSource = AirEntities.GetContext().Reis.ToList();
        }

        private void BtnReis_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PageReis());
        }

        private void BtnPass_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PageZakaz());
        }
    }
}
