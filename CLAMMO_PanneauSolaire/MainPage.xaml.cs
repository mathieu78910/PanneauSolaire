namespace CLAMMO_PanneauSolaire
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        
        private void OnGeolocationClicked(object sender, EventArgs e)
        {
            /*
            try
            {
                var location = Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Best));
                if (location != null)
                {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unable to get location: {ex.Message}");
            }
            */
            
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
                    double heading = Math.Round(data.HeadingMagneticNorth, 2);
                    CompassLabel.Text = $"Heading: {heading} degrees";
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
                    // Arrondir l'inclinaison au centième
                    double inclinationRounded = Math.Round(inclination, 2);
                    InclinationLabel.Text = $"Inclination: {inclinationRounded} degrees";
                };
                Accelerometer.Start(SensorSpeed.UI); 
                Console.WriteLine("Accelerometer started.");
            }
        }

    }

}
