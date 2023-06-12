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
    /// Логика взаимодействия для BiletPrint.xaml
    /// </summary>
    public partial class BiletPrint : Page
    {
        private Zakaz _currentZakaz = new Zakaz();

        public BiletPrint(Zakaz selectZakaz)
        {
            InitializeComponent();
            if (selectZakaz != null)
            {
                _currentZakaz = selectZakaz;
            }
            DataContext = _currentZakaz;
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            BtnPrint.Visibility = Visibility.Hidden;

            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(GrBilet, "Печать билета");
            }

            BtnPrint.Visibility = Visibility.Visible;
        }
    }
}
