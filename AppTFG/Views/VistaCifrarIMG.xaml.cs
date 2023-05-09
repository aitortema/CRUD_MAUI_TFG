using System.Diagnostics;

namespace AppTFG.Views
{
    public partial class VistaCifrarIMG : ContentPage
    {
        private string dirIMG;

        public VistaCifrarIMG()
        {
            InitializeComponent();
        }

        private async void CargarIMG_Clicked(object sender, EventArgs e)
        {
            try
            {
                var result = await FilePicker.PickAsync(new PickOptions
                {
                    FileTypes = FilePickerFileType.Images,
                    PickerTitle = "Selecciona una imagen"
                });

                if (result != null)
                {
                    dirIMG = result.FullPath; // Guardar ruta IMG
                    imgCargada.Source = ImageSource.FromFile(dirIMG);
                }
                else
                {
                    await DisplayAlert("😥", "No has seleccionado ninguna imagen", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Vaya...");
            }
        }

        private async void BtnCargarTXT_Clicked(object sender, EventArgs e)
        {
            try
            {
                var customFileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
        {
            { DevicePlatform.Android, new[] { "text/plain" } },
            { DevicePlatform.iOS, new[] { "public.text" } },
            { DevicePlatform.MacCatalyst, new[] { "public.text" } },
            { DevicePlatform.WinUI, new[] { ".txt" } }
        });

                var pickOptions = new PickOptions
                {
                    PickerTitle = "Seleccione un archivo de texto",
                    FileTypes = customFileTypes
                };

                var fileResult = await FilePicker.PickAsync(pickOptions);

                if (fileResult != null)
                {
                    string txtUserLeido = await ReadFileContentAsync(fileResult);
                    mensEnIMG.Text = txtUserLeido;
                }
                else
                {
                    await DisplayAlert("😥", "No se ha seleccionado ningún archivo de texto", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async Task<string> ReadFileContentAsync(FileResult fileResult) // Para leer txt 
        {
            using var stream = await fileResult.OpenReadAsync();
            using var streamReader = new StreamReader(stream);
            return await streamReader.ReadToEndAsync();
        }

        private async void EncriptarIMG_Clicked(object sender, EventArgs e)
        {
            // 1. Usar la imagen cargada.
            if (string.IsNullOrEmpty(dirIMG))
            {
                await DisplayAlert("😥", "No has seleccionado ninguna imagen", "Volver");
                return;
            }

            // 2. Usar el texto cargado.
            string mensajeAOcultar = mensEnIMG.Text; // Obtener txt del Entry
            if (string.IsNullOrEmpty(mensajeAOcultar))
            {
                await DisplayAlert("😥", "No has introducido ningún mensaje", "Volver");
                return;
            }

            // 3. Concatenar la imagen y el texto.
            string nombreIMGSaliente = await DisplayPromptAsync("Escribe un nombre:", "Introduce el nombre de la imagen de salida");
            if (!string.IsNullOrEmpty(nombreIMGSaliente))
            {
                var directorio = Path.GetDirectoryName(dirIMG);
                var nombreIMG = Path.GetFileName(dirIMG);
                var directorioSalida = Path.Combine(directorio, nombreIMGSaliente + Path.GetExtension(dirIMG));
                var cmdMagico = $"copy /b \"{nombreIMG}\" + \"{mensajeAOcultar}\" \"{directorioSalida}\"";

                var startInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/c {cmdMagico}",
                    WorkingDirectory = directorio,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = false
                };

                var proceso = new Process
                {
                    StartInfo = startInfo
                };
                proceso.Start();
                proceso.WaitForExit();

                // 4. Guardar el resultado de la concatenación en el dispositivo.
                await DisplayAlert("😁", $"Imagen cifrada correctamente y guardad en; {directorioSalida}", "OK");
            }
            else
            {
                await DisplayAlert("😥", "Algo ha salido mal", "Mecawen");
            }
        }


        private async void CompartirIMG_Clicked(object sender, EventArgs e)
        {
            //if (dirIMG != null)
            //{
            //    var compartirIMG = new Xamarin.Essentials.ShareFile(dirIMG);
            //    await Xamarin.Essentials.Share.RequestAsync(new Xamarin.Essentials.ShareFileRequest
            //    {
            //        Title = "Compartir imagen",
            //        File = compartirIMG
            //    });
            //}
            //else
            //{
            //    await DisplayAlert("😥", "No se ha seleccionado ninguna imagen", "OK");
            //}
        }
    }
}
