using Microsoft.Maui.Controls;
namespace CLAMMO_PanneauSolaire
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
            AddGeoLocationButton();
        }

        private void AddGeoLocationButton()
        {
            Button geoButton = new Button
            {
                Text = "Géolocalisation",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Colors.LightBlue,
                TextColor = Colors.White,
                FontSize = 18,
                CornerRadius = 20,
                HeightRequest = 50
            };

            geoButton.Clicked += async (sender, e) =>
            {
          
                await Shell.Current.GoToAsync("//GeolocationPage"); 
            };

           
        }
    }
}
