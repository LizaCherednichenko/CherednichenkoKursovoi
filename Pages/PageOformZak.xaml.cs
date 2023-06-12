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
    /// Логика взаимодействия для PageOformZak.xaml
    /// </summary>
    public partial class PageOformZak : Page
    {

        private Zakaz _currentZakaz = new Zakaz();

        public PageOformZak(Zakaz selectZakaz)
        {
            InitializeComponent();

            if (selectZakaz != null)
                _currentZakaz = selectZakaz;
             DataContext = _currentZakaz;

            CBPass.ItemsSource = AirEntities.GetContext().Passajir.ToList();
            CBReis.ItemsSource = AirEntities.GetContext().Reis.ToList();
        }

        private void BtnReis_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PageReis());
        }

        private void BtnPass_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PagePass());
        }

        private void BtnOtm_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (_currentZakaz.Reis == null)
                errors.AppendLine("Выберите рейс");
            if (_currentZakaz.Passajir == null)
                errors.AppendLine("Укажите пассажира");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentZakaz.IdZakaz == 0)
            {
                AirEntities.GetContext().Zakaz.Add(_currentZakaz);
            }
                
            
            try
            {

                AirEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                Manager.MainFrame.GoBack();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }


            

        }
    }
}
