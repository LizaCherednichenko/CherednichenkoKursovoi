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
    /// Логика взаимодействия для PageZakaz.xaml
    /// </summary>
    public partial class PagePass : Page
    {

        public PagePass()
        {
            InitializeComponent();

            DGPassaj.ItemsSource = Models.AirEntities.GetContext().Passajir.ToList();
        }

        private void BtnAddPass_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PagePassAdd(null));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                AirEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGPassaj.ItemsSource = AirEntities.GetContext().Passajir.ToList();
            }
        }

        private void BtnRedact_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PagePassAdd((sender as Button).DataContext as Passajir));
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var DateForDel = DGPassaj.SelectedItems.Cast<Passajir>().ToList();

            if (MessageBox.Show("Вы действительно хотите удалить выбранные данные?", "Предупреждение",MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AirEntities.GetContext().Passajir.RemoveRange(DateForDel);
                    AirEntities.GetContext().SaveChanges();

                    MessageBox.Show("Данные удалены!");

                    DGPassaj.ItemsSource = AirEntities.GetContext().Passajir.ToList();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
