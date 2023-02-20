﻿using System;
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
    /// Логика взаимодействия для PageZakaz.xaml
    /// </summary>
    public partial class PageZakaz : Page
    {


        public PageZakaz(Reis selectedReis)
        {
            InitializeComponent();

            DGPass.ItemsSource = AirEntities.GetContext().Passajir.ToList();
        }

        private void BtnAddPass_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PagePass());
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                AirEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGPass.ItemsSource = AirEntities.GetContext().Passajir.ToList();
            }
        }
    }
}
