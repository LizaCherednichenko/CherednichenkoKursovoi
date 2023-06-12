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
    /// Логика взаимодействия для PageReisAdd.xaml
    /// </summary>
    public partial class PageReisAdd : Page
    {

        private Reis _currentReis = new Reis();

        public PageReisAdd(Reis selectReis)
        {
            InitializeComponent();
            if (selectReis != null)
            {
                _currentReis = selectReis;
            }
            DataContext = _currentReis;

            CBCityOtpr.ItemsSource = AirEntities.GetContext().City.ToList();
            CBCityPrib.ItemsSource = AirEntities.GetContext().City.ToList();
            CBAirplane.ItemsSource = AirEntities.GetContext().Airplane.ToList();

            
        }

        private void BtnOtm_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (_currentReis.Number == 0)
                errors.AppendLine("Введите номер рейса");
            if (_currentReis.City == null)
                errors.AppendLine("Выберите город отправления");
            if (_currentReis.City1 == null)
                errors.AppendLine("Выберите город прибытия");
            if (_currentReis.DateOtpravl == null)
                errors.AppendLine("Укажите дату отправления");
            if (_currentReis.TimeOtpravl == null)
                errors.AppendLine("Укажите время отправления");
            if (_currentReis.DatePribit == null)
                errors.AppendLine("Укажите дату прибытия");
            if (_currentReis.TimePribit == null)
                errors.AppendLine("Укажите время прибытия");
            if (_currentReis.Prise == 0)
                errors.AppendLine("Укажите цену билета");
            if (_currentReis.Airplane == null)
                errors.AppendLine("Выберите самолет совершающий рейс");


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentReis.IdReis == 0)
                AirEntities.GetContext().Reis.Add(_currentReis);

            try
            {
                AirEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.GoBack();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    }

