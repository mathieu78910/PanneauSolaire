namespace CLAMMO_PanneauSolaire
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
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

        private void OnCompassClicked(object sender, EventArgs e)
        {
            if (Compass.IsMonitoring)
            {
                Compass.Stop();
                Console.WriteLine("Compass stopped.");
            }
            else
            {
                Compass.ReadingChanged += (s, e) =>
                {
                    var data = e.Reading;
                    double heading = Math.Round(data.HeadingMagneticNorth, 0);
                    CompassLabel.Text = $"Direction: {heading}°";
                };
                Compass.Start(SensorSpeed.UI);
                Console.WriteLine("Compass started.");
            }
        }

        private void OnInclinationClicked(object sender, EventArgs e)
        {
            if (Accelerometer.IsMonitoring)
            {
                Accelerometer.Stop();
                Console.WriteLine("Accelerometer stopped.");
            }
            else
            {
                Accelerometer.ReadingChanged += (s, e) =>
                {
                    var data = e.Reading;

                    double inclination = Math.Atan2(data.Acceleration.Y, data.Acceleration.Z) * (180 / Math.PI);
                    // Arrondir l'inclinaison 
                    double inclinationRounded = Math.Round(inclination, 0);
                    if (inclinationRounded == -0)
                        InclinationLabel.Text = "Inclination: 0°";
                    else
                        InclinationLabel.Text = $"Inclination: {inclinationRounded}°";
                };
                Accelerometer.Start(SensorSpeed.UI);
                Console.WriteLine("Accelerometer started.");
            }
        }
    }

}
