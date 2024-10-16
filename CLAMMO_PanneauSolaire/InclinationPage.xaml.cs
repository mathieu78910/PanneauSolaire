using Microsoft.Maui.Controls;
using System;

namespace CLAMMO_PanneauSolaire
{
    public partial class InclinationPage : ContentPage
    {
        private Label _inclinationLabel; // Renamed to avoid ambiguity

        public InclinationPage()
        {
            InitializeComponent();
            _inclinationLabel = new Label();
            Content = new StackLayout
            {
                Children = { _inclinationLabel }
            };
        }

        private void OnInclinationClicked(object sender, EventArgs e)
        {
            Accelerometer.ReadingChanged += (s, args) =>
            {
                var data = args.Reading;
                _inclinationLabel.Text = $"Inclinaison: {data.Acceleration.Z * 90}°"; // Calcul de l'inclinaison
            };
            Accelerometer.Start(SensorSpeed.UI); // Démarre la lecture de l'accéléromètre
        }
    }
}
