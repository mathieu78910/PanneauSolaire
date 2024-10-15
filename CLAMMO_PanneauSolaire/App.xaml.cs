namespace CLAMMO_PanneauSolaire
{
    public partial class App : Application
    {
        public App()
        {
            MainPage = new AppShell();
            AddGeoLocationButton();
        }

        private void AddGeoLocationButton()
        {
         
            Button geoButton = new Button
            {
                Text = "Géolocalisation"
            };

            geoButton.Clicked += async (sender, e) =>
            {
                await Shell.Current.GoToAsync("//Géolocalisation");
            };
        }
    }
}
