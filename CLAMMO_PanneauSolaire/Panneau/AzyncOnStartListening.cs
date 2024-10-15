using System;
using Microsoft.Maui.Devices.Sensors; 

namespace CLAMMO_PanneauSolaire.Panneau
{
    class AzyncOnStartListening
    {
        public async Task OnStartListening(int accuracy)
        {
            try
            {
                Geolocation.LocationChanged += Geolocation_LocationChanged;
                var request = new GeolocationListeningRequest((GeolocationAccuracy)accuracy);
                var success = await Geolocation.StartListeningForegroundAsync(request);

                string status = success
                    ? "Started listening for foreground location updates"
                    : "Couldn't start listening";

                Console.WriteLine(status);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private void Geolocation_LocationChanged(object sender, GeolocationLocationChangedEventArgs e)
        {
            // Process e.Location to get the new location
            var location = e.Location;
            Console.WriteLine($"New location: Latitude {location.Latitude}, Longitude {location.Longitude}");
        }

        public void OnStopListening()
        {
            try
            {
                Geolocation.LocationChanged -= Geolocation_LocationChanged;
                Geolocation.StopListeningForeground();
                string status = "Stopped listening for foreground location updates";
                Console.WriteLine(status);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
