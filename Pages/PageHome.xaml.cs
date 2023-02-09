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
    /// Логика взаимодействия для PageHome.xaml
    /// </summary>
    public partial class PageHome : Page
    {
        public PageHome()
        {
            InitializeComponent();
        }

        private void BtnInManager_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PageReis());
        }

        private void BtnInAdmin_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PageReis());
        }

        private void BtnOut_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
