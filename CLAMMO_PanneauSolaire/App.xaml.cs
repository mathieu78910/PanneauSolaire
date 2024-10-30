using Plugin.Maui.Audio;

namespace CLAMMO_PanneauSolaire
{
    public partial class App : Application
    {
        private readonly IAudioManager _audioManager; // Gestionnaire audio

        public App(IAudioManager audioManager) // Injecter IAudioManager
        {
            InitializeComponent();
            MainPage = new AppShell();
            _audioManager = audioManager;

            PlayStartupSound(); // Jouer l'audio au démarrage
        }

        private async void PlayStartupSound()
        {
            try
            {
                // Charger le fichier audio
                var player =
                    _audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("NOUVEAUJINGLENETFLIX.mp3"));
                // Jouer l'audio
                player.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la lecture de l'audio : {ex.Message}");
            }
        }
    }
}