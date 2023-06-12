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
    /// Логика взаимодействия для PageHome.xaml
    /// </summary>
    public partial class PageZakaz : Page
    {
        public PageZakaz()
        {
            InitializeComponent();
            DGZakaz.SelectedItem = AirEntities.GetContext().Zakaz.ToList();
        }

        private void BtnZakAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PageOformZak(null));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                AirEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGZakaz.ItemsSource = AirEntities.GetContext().Zakaz.ToList();
            }
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var DateForDel = DGZakaz.SelectedItems.Cast<Zakaz>().ToList();

            if (MessageBox.Show("Вы действительно хотите удалить выбранные данные?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AirEntities.GetContext().Zakaz.RemoveRange(DateForDel);
                    AirEntities.GetContext().SaveChanges();

                    MessageBox.Show("Данные удалены!");

                    DGZakaz.ItemsSource = AirEntities.GetContext().Zakaz.ToList();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BtnRedact_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PageOformZak((sender as Button).DataContext as Zakaz));
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new BiletPrint((sender as Button).DataContext as Zakaz));
        }
    }
}
