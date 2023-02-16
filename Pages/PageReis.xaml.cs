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
    /// Логика взаимодействия для PageReis.xaml
    /// </summary>
    public partial class PageReis : Page
    {
        public PageReis()
        {
            InitializeComponent();
            DGReis.ItemsSource = AirEntities.GetContext().Reis.ToList();
        }

        private void BtnVibor_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PageZakaz());
        }
    }
}