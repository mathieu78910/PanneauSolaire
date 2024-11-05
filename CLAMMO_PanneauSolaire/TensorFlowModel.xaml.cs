using Microsoft.Maui.Controls;
using ZXing.Net.Maui;
using System.IO;
using System.Reflection;

namespace CLAMMO_PanneauSolaire
{
    public partial class TensorFlowModelPage : ContentPage
    {
        private Interpreter _interpreter;

        public TensorFlowModelPage()
        {
            InitializeComponent();
        }

        private void InitializeInterpreter()
        {
            var assembly = Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream("CLAMMO_PanneauSolaire.Resources.Raw.model_unquant.tflite");
            using var memoryStream = new MemoryStream();
            stream.CopyTo(memoryStream);
            var model = memoryStream.ToArray();

            _interpreter = new Interpreter(model);
            _interpreter.ResizeInputTensor(0, new int[] { 1, 224, 224, 3 });
            _interpreter.AllocateTensors();
        }

        private float[,,] PreprocessImage(byte[] frame)
        {
            return new float[1, 224, 224];
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            InitializeInterpreter();
        }
    }
}
