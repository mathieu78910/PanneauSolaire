using System;
using Microsoft.Maui.Devices.Sensors; 
using Microsoft.Maui.Graphics; 

namespace CLAMMO_PanneauSolaire.Panneau
{
    public class CompassService
    {
        public Label CompassLabel { get; set; }

        public CompassService(Label compassLabel)
        {
            CompassLabel = compassLabel;
        }

        public void ToggleCompass()
        {
            if (Compass.Default.IsSupported)
            {
                if (!Compass.Default.IsMonitoring)
                {
                    Compass.Default.ReadingChanged += Compass_ReadingChanged;
                    Compass.Default.Start(SensorSpeed.UI);
                }
                else
                {
                    Compass.Default.Stop();
                    Compass.Default.ReadingChanged -= Compass_ReadingChanged;
                }
            }
            else
            {
                CompassLabel.Text = "Compass is not supported on this device.";
                CompassLabel.TextColor = Colors.Red;
            }
        }

        private void Compass_ReadingChanged(object sender, CompassChangedEventArgs e)
        {
            
            CompassLabel.TextColor = Colors.Green;
            CompassLabel.Text = $"Compass: {e.Reading.HeadingMagneticNorth:F1}°"; 
        }
    }
}
