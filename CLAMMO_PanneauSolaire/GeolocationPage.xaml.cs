using CLAMMO_PanneauSolaire.Panneau;

namespace CLAMMO_PanneauSolaire
{
    public partial class GeolocationPage : ContentPage
    {
        private AzyncOnStartListening _geoListener;

        public GeolocationPage()
        {
            InitializeComponent();
            _geoListener = new AzyncOnStartListening();
        }

        private async void OnGeolocationClicked(object sender, EventArgs e)
        {
            try
            {
                var location = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Best));
                if (location != null)
                {
                    double latitude = Math.Round(location.Latitude, 2);
                    double longitude = Math.Round(location.Longitude, 2);
                    double? altitude = location.Altitude.HasValue ? Math.Round(location.Altitude.Value, 2) : (double?)null;

                    GeolocationLabel.Text = $"Latitude: {latitude}, Longitude: {longitude}, Altitude: {altitude}";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unable to get location: {ex.Message}");
            }
        }

        private void OnStopListeningClicked(object sender, EventArgs e)
        {
            _geoListener.OnStopListening();
        }
    }
}
