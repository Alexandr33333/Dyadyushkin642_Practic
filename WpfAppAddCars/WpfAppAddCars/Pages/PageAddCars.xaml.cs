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
using WpfAppAddCars.Classes;
using WpfAppAddCars.Models;

namespace WpfAppAddCars.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAddCars.xaml
    /// </summary>
    public partial class PageAddCars : Page
    {
        
        public PageAddCars()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Cars _currentCars = new Cars();
            StringBuilder errors = new StringBuilder();

            if (tbBrand.Text.Length == 0)
                errors.AppendLine("Укажите марку автомобиля");
            if (!(tbBrand.Text.Intersect("#$%^&_").Count() == 0))
                errors.AppendLine("В названии марки автомобиля не должно быть специальных символов");
            if (tbModel.Text.Length == 0)
                errors.AppendLine("Укажите модель автомобиля");
            try
            {
                _currentCars.Price = Convert.ToDecimal(tbPrice.Text);
            }
            catch
            {
                if (tbPrice.Text.Length == 0)
                    errors.AppendLine("Укажите цену автомобиля");
            }
            try
            {
                _currentCars.Amount = Convert.ToInt32(tbAmount.Text);
            }
            catch
            {
                if (tbAmount.Text.Length == 0)
                    errors.AppendLine("Укажите количество автомобилей");
            }
            

            _currentCars.Brand = tbBrand.Text;
            _currentCars.Model = tbModel.Text;           

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            else
            {
                if (_currentCars.Id == 0)
                bdAvtoLider2Entities.GetContext().Cars.Add(_currentCars);
                bdAvtoLider2Entities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                ClassManager.BaseFrame.GoBack();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы точно хотите отменить изменения?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ClassManager.BaseFrame.GoBack();
            }
            else
            {
                return;
            }
        }
    }
}
