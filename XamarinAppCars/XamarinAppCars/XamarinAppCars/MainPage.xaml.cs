using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinAppCars.Model;

namespace XamarinAppCars
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnAdd_Clicked(object sender, EventArgs e)
        {
            Cars _currentCars = new Cars();
            StringBuilder errors = new StringBuilder();


            if (entryBrand.Text.Length == 0)
                errors.AppendLine("Укажите марку автомобиля");
            if (!(entryBrand.Text.Intersect("#$%^&_").Count() == 0))
                errors.AppendLine("В названии марки автомобиля не должно быть специальных символов");
            if (entryModel.Text.Length == 0)
                errors.AppendLine("Укажите модель автомобиля");
            try
            {
                _currentCars.Price = Convert.ToDecimal(entryPrice.Text);
            }
            catch
            {
                if (entryPrice.Text.Length == 0)
                    errors.AppendLine("Укажите цену автомобиля");
            }
            try
            {
                _currentCars.Amount = Convert.ToInt32(entryAmount.Text);
            }
            catch
            {
                if (entryAmount.Text.Length == 0)
                    errors.AppendLine("Укажите количество автомобилей");
            }

            _currentCars.Brand = entryBrand.Text;
            _currentCars.Model = entryModel.Text;

            if (errors.Length > 0)
            {
                string Errors = errors.ToString();
                DisplayAlert("Ошибка", Errors, "Ок");
                return;
            }
            else
            {
                var client = new WebClient();
                client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                var result = client.UploadString("http://10.0.2.2:52710/api/Cars", JsonConvert.SerializeObject(_currentCars));
                DisplayAlert("Дабавление данных", "Данные успешно добавлены", "Ок");
            }
        }
    }
}
