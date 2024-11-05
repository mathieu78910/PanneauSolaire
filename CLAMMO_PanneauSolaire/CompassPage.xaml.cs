namespace CLAMMO_PanneauSolaire
{
    public partial class CompassPage : ContentPage
    {
        private bool isCompassActive = false; // Suivi de l'état du compas

        public CompassPage()
        {
            InitializeComponent();
        }

        private void OnCompassClicked(object sender, EventArgs e)
        {
            if (!isCompassActive)
            {
                // Démarre le compas
                Compass.ReadingChanged += OnCompassReadingChanged;
                Compass.Start(SensorSpeed.UI);
                
                // Met à jour l'état
                isCompassActive = true;
                ((Button)sender).Text = "Arrêter le compas";
                ((Button)sender).BackgroundColor = Colors.Red;
            }
            else
            {
                // Arrête le compas
                Compass.ReadingChanged -= OnCompassReadingChanged;
                Compass.Stop();
                
                // Met à jour l'état
                isCompassActive = false;
                ((Button)sender).Text = "Activer le compas";
                ((Button)sender).BackgroundColor = Color.FromArgb("#4CAF50");
            }
        }

        private void OnCompassReadingChanged(object sender, CompassChangedEventArgs args)
        {
            var data = args.Reading;
            double heading = Math.Round(data.HeadingMagneticNorth);

            if (heading > 150 && heading < 210)
            {
                CompassLabel.Text = $"Direction: {heading}°";
                CompassLabel.TextColor = Colors.Green;
            }
            else
            {
                CompassLabel.Text = $"Direction: {heading}°";
                CompassLabel.TextColor = Colors.Black;
            }
            CompassImage.Rotation = -heading;
        }
    }
}