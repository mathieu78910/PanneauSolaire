using Microsoft.Maui.Devices.Sensors;

namespace CLAMMO_PanneauSolaire
{
    public partial class InclinationPage : ContentPage
    {
        private Label _inclinationLabel;

        public InclinationPage()
        {
            InitializeComponent();
        }

        private void OnInclinationClicked(object sender, EventArgs e)
        {
            Accelerometer.ReadingChanged += (s, args) =>
            {
                var data = args.Reading;
                double inclination = Math.Round(data.Acceleration.Z * 90);
                InclinationLabel.Text = $"Inclinaison: {inclination}°";            };
            Accelerometer.Start(SensorSpeed.UI); 
        }
        private void OnStopListeningClicked(object sender, EventArgs e)
        {
            Accelerometer.Stop();
        }
    }
}