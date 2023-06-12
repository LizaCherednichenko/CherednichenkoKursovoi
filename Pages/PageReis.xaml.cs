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
    /// Логика взаимодействия для PageReis.xaml
    /// </summary>
    public partial class PageReis : Page
    {
        public PageReis()
        {
            InitializeComponent();
            DGReis.ItemsSource = AirEntities.GetContext().Reis.ToList();

            if (Manager.Dostup == 1)
            {
                ColRedact.Visibility = Visibility.Visible;
                BtnAddReis.Visibility = Visibility.Visible;
                BtnDel.Visibility = Visibility.Visible;
            }
            if (Manager.Dostup == 2)
            {
                ColRedact.Visibility = Visibility.Hidden;
                BtnAddReis.Visibility = Visibility.Hidden;
                BtnDel.Visibility = Visibility.Hidden;
            }
        }

        private void BtnAddReis_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PageReisAdd(null));
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var DateForDel = DGReis.SelectedItems.Cast<Reis>().ToList();

            if (MessageBox.Show("Вы действительно хотите удалить выбранные данные?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AirEntities.GetContext().Reis.RemoveRange(DateForDel);
                    AirEntities.GetContext().SaveChanges();

                    MessageBox.Show("Данные удалены!");

                    DGReis.ItemsSource = AirEntities.GetContext().Reis.ToList();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BtnRedact_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PageReisAdd((sender as Button).DataContext as Reis));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                AirEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGReis.ItemsSource = AirEntities.GetContext().Reis.ToList();
            }
        }
    }
}
