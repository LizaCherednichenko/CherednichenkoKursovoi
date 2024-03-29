﻿using CherednichenkoKursovoi.Models;
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
    /// Логика взаимодействия для PagePass.xaml
    /// </summary>
    public partial class PagePassAdd : Page
    {
        
        private Passajir _currentPass = new Passajir();

        public PagePassAdd(Passajir selectPass)
        {
            InitializeComponent();
            if (selectPass != null)
            {
                _currentPass = selectPass;
            }
            DataContext = _currentPass;

        }

        private void BtnOtm_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentPass.Familia))
                errors.AppendLine("Введите фамилию");
            if (string.IsNullOrWhiteSpace(_currentPass.Name))
                errors.AppendLine("Введите имя");
            if (string.IsNullOrWhiteSpace(_currentPass.Otchestvo))
                errors.AppendLine("Введите отчество");
            if (string.IsNullOrWhiteSpace(_currentPass.Phone))
                errors.AppendLine("Введите номер телефона");
            if (string.IsNullOrWhiteSpace(_currentPass.Pasport))
                errors.AppendLine("Введите данные паспорта: серию и номер");


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentPass.IdPassajir == 0)
                AirEntities.GetContext().Passajir.Add(_currentPass);

            try
            {
                AirEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.GoBack();
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
