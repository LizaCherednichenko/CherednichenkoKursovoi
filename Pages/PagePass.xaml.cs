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
    public partial class PagePass : Page
    {

        private Passajir _currentPass = new Passajir();

        public PagePass()
        {
            InitializeComponent();
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
            if (_currentPass.Phone == null)
                errors.AppendLine("Введите номер телефона");
            if (_currentPass.Pasport == null)
                errors.AppendLine("Введите данные паспорта");


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentPass.IdPass == 0)
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
