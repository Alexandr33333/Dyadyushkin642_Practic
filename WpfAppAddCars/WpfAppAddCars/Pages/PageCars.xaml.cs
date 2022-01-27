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
using WpfAppAddCars.Pages;
using WpfAppAddCars.Models;
using WpfAppAddCars.Classes;

namespace WpfAppAddCars.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageCars.xaml
    /// </summary>
    public partial class PageCars : Page
    {
        public PageCars()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ClassManager.BaseFrame.Navigate(new PageAddCars());
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы точно хотите выйти?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Environment.Exit(0);
            }
            else
            {
                return;
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                bdAvtoLider2Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                dGridCars.ItemsSource = bdAvtoLider2Entities.GetContext().Cars.ToList();
            }
        }
    }
}
