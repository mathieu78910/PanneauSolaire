using Microsoft.Maui.Controls;
using Plugin.Maui.Audio;  
using System;

namespace CLAMMO_PanneauSolaire
{
    public partial class App : Application
    {
        private readonly IAudioManager _audioManager;  // Gestionnaire audio

        public App(IAudioManager audioManager)  // Injecter IAudioManager
        {
            InitializeComponent();
            _audioManager = audioManager;

            MainPage = new AppShell();
            AddGeoLocationButton();

            PlayStartupSound();  // Jouer l'audio au démarrage
        }

        private async void PlayStartupSound()
        {
            try
            {
                // Charger le fichier audio
                var player = _audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("NOUVEAUJINGLENETFLIX.mp3"));
                // Jouer l'audio
                player.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la lecture de l'audio : {ex.Message}");
            }
        }

        private void AddGeoLocationButton()
        {
            Button geoButton = new Button
            {
                Text = "Géolocalisation",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Colors.LightBlue,
                TextColor = Colors.White,
                FontSize = 18,
                CornerRadius = 20,
                HeightRequest = 50
            };

            geoButton.Clicked += async (sender, e) =>
            {
                await Shell.Current.GoToAsync("//GeolocationPage");
            };

            
        }
    }
}
