//using Microsoft.Maui.Essentials;

namespace CLAMMO_PanneauSolaire.Position
{
    public class LocationService
    {
        private CancellationTokenSource _cancelTokenSource;
        private bool _isCheckingLocation;

        public async Task GetCurrentLocationAsync()
        {
            try
            {
                _isCheckingLocation = true;

                GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                _cancelTokenSource = new CancellationTokenSource();

                Location location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);

                if (location != null)
                {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                }
                else
                {
                    Console.WriteLine("Unable to retrieve location.");
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                Console.WriteLine("Location services not supported: " + fnsEx.Message);
            }
            catch (FeatureNotEnabledException fneEx)
            {
                Console.WriteLine("Location services not enabled: " + fneEx.Message);
            }
            catch (PermissionException pEx)
            {
                Console.WriteLine("Location permissions not granted: " + pEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                _isCheckingLocation = false;
            }
        }

        public void CancelRequest()
        {
            if (_isCheckingLocation && _cancelTokenSource != null && !_cancelTokenSource.IsCancellationRequested)
            {
                _cancelTokenSource.Cancel();
            }
        }
    }
}
