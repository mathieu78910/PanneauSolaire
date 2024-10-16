using CLAMMO_PanneauSolaire.Panneau;

namespace CLAMMO_PanneauSolaire
{
    public partial class GeolocationPage : ContentPage
    {
        private AzyncOnStartListening _geoListener;

        public GeolocationPage()
        {
            InitializeComponent();
            _geoListener = new AzyncOnStartListening();
        }

        private async void OnGeolocationClicked(object sender, EventArgs e)
        {
            //précision de 1m
            await _geoListener.OnStartListening(1);
        }

        private void OnStopListeningClicked(object sender, EventArgs e)
        {
            _geoListener.OnStopListening();
        }
    }
}
