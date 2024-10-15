using Android.App;
using Android.Content.PM;
using Android.OS;
using Android;

namespace CLAMMO_PanneauSolaire
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Vérifie si la permission d'accès à la localisation a été accordée
            if (CheckSelfPermission(Manifest.Permission.AccessFineLocation) != Permission.Granted)
            {
                // Si non, demande la permission à l'utilisateur
                RequestPermissions(new string[] { Manifest.Permission.AccessFineLocation, Manifest.Permission.AccessCoarseLocation }, 0);
            }
        }

        // Gérer la réponse de l'utilisateur à la demande de permission
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            if (requestCode == 0 && grantResults.Length > 0 && grantResults[0] == Permission.Granted)
            {
                // Permission accordée
                Console.WriteLine("Permission d'accès à la localisation accordée.");
            }
            else
            {
                // Permission refusée
                Console.WriteLine("Permission d'accès à la localisation refusée.");
            }
        }
    }
}
