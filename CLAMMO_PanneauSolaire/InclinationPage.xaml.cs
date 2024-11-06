using Microsoft.Maui.Devices.Sensors;

namespace CLAMMO_PanneauSolaire
{
    public partial class InclinationPage : ContentPage
    {
        private bool isAccelerometerActive = false; // Suivi de l'état de l'accéléromètre

        public InclinationPage()
        {
            InitializeComponent();
        }

        private void OnInclinationClicked(object sender, EventArgs e)
        {
            if (!isAccelerometerActive)
            {
                // Démarre l'accéléromètre
                Accelerometer.ReadingChanged += OnAccelerometerReadingChanged;
                Accelerometer.Start(SensorSpeed.UI);

                // Met à jour l'état
                isAccelerometerActive = true;
                ((Button)sender).Text = "Arrêter l'inclinaison";
                ((Button)sender).BackgroundColor = Colors.Red;
            }
            else
            {
                // Arrête l'accéléromètre
                Accelerometer.ReadingChanged -= OnAccelerometerReadingChanged;
                Accelerometer.Stop();

                // Met à jour l'état
                isAccelerometerActive = false;
                ((Button)sender).Text = "Activer l'inclinaison";
                ((Button)sender).BackgroundColor = Color.FromArgb("#4CAF50");
            }
        }

        private void OnAccelerometerReadingChanged(object sender, AccelerometerChangedEventArgs args)
        {
            var data = args.Reading;
            double inclination = Math.Round(data.Acceleration.Z * 90);
            inclination = inclination < 0 ? -inclination : inclination;
            if (inclination >50 && inclination <70)
            {
                InclinationLabel.Text = $"{inclination}°";
                InclinationLabel.TextColor = Colors.Green;
            }
            else
            {
                InclinationLabel.Text = $"{inclination}°";
                InclinationLabel.TextColor = Colors.White;
            }
        }
    }
}