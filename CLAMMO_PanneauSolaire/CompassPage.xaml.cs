using Microsoft.Maui.Controls;
/*using Microsoft.Maui.Essentials;*/
using System;

namespace CLAMMO_PanneauSolaire
{
    public partial class CompassPage : ContentPage
    {
        public CompassPage()
        {
            InitializeComponent();
        }

        private void OnCompassClicked(object sender, EventArgs e)
        {
            Compass.ReadingChanged += (s, args) =>
            {
                var data = args.Reading;
                CompassLabel.Text = $"Direction: {data.HeadingMagneticNorth}°";
            };
            Compass.Start(SensorSpeed.UI);
        }
    }
}
