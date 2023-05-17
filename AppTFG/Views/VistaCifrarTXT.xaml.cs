using AppTFG.Data;
using AppTFG.Modelo;

namespace AppTFG.Views
{
    public partial class VistaCifrarTXT : ContentPage
    {
        public int CifradoEscogido { get; set; }
        //public int IdUsuarioActivo { get; set; }

        public VistaCifrarTXT()
        {
            InitializeComponent();
        }

        private void CifradoEscogido_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(e.NewTextValue, out int valorCifrador) && valorCifrador >= 1 && valorCifrador <= 25)
            {
                CifradoEscogido = valorCifrador;
            }
        }

        private void PickerCifrado(object sender, EventArgs e)
        {
            if (picker.SelectedItem != null && picker.SelectedItem.ToString() == "Cesar" || picker.SelectedItem.ToString() == "Vigenere")
            {
                cifradoEscogido.IsVisible = true;
            }
            else
            {
                cifradoEscogido.IsVisible = false;
            }
        }

        private void PickerDescifrado(object sender, EventArgs e)
        {
            if (pickerDescifrar.SelectedItem != null && pickerDescifrar.SelectedItem.ToString() == "Cesar" || pickerDescifrar.SelectedItem.ToString() == "Vigenere")
            {
                cifradoEscogido.IsVisible = true;
            }
            else
            {
                cifradoEscogido.IsVisible = false;
            }
        }

        private void Cifrar_Clicked(object sender, EventArgs e)
        {
            string mensaje = mensajeAcifrar.Text;
            string cifrado = "";
            string clave = cifradoEscogido.Text;

            switch (picker.SelectedItem.ToString())
            {
                case "Morse":
                    cifrado = CifradorTXT.CifrarMorse(mensaje);
                    break;
                case "Base64":
                    cifrado = CifradorTXT.CifrarBase64(mensaje);
                    break;
                case "Binario":
                    cifrado = CifradorTXT.CifrarBinario(mensaje);
                    break;
                case "Cesar":
                    cifrado = CifradorTXT.CifrarCesar(mensaje, CifradoEscogido);
                    break;
                case "Vigenere":
                    cifrado = CifradorTXT.CifrarVigenere(mensaje, clave);
                    break;
                default:
                    break;
            }

            txtResEditorCifrado.Text = cifrado;
            Clipboard.SetTextAsync(cifrado);
            DisplayAlert("Éxito 😀", $"Mensaje copiado al portapapeles: {cifrado}", "OK");

        }

        private void Descifrar_Clicked(object sender, EventArgs e)
        {
            string mensaje = mensajeAdescifrar.Text;
            string descifrado = "";

            switch (pickerDescifrar.SelectedItem.ToString())
            {
                case "Morse":
                    descifrado = DescifradorTXT.DescifrarMorse(mensaje);
                    break;
                case "Base64":
                    descifrado = DescifradorTXT.DescifrarBase64(mensaje);
                    break;
                case "Binario":
                    descifrado = DescifradorTXT.DescifrarBinario(mensaje);
                    break;
                case "Cesar":
                    descifrado = DescifradorTXT.DescifrarCesar(mensaje, CifradoEscogido);
                    break;
                case "Vigenere":
                    descifrado = DescifradorTXT.DescifrarVigenere(mensaje, "CLAVE");
                    break;
                default:
                    break;
            }

            txtResEditorDescifrado.Text = descifrado;
            Clipboard.SetTextAsync(descifrado);
            DisplayAlert("Éxito 😀", $"Mensaje copiado al portapapeles: {descifrado}", "OK");
        }

        private async void Salir_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void GuardarResultado_Clicked(object sender, EventArgs e)
        {
            string mensajeCifrado = txtResEditorCifrado.Text;
            string mensajeDescifrado = txtResEditorDescifrado.Text;
            int idUsuario = Preferences.Get("idUsuario", 1);
            //int idUsuario = IdUsuarioActivo;

            UserRepository repoUsuario = new UserRepository();
            User usuario = repoUsuario.GetUserById(idUsuario);

            if (usuario != null)
            {
                Mensaje mensaje = new Mensaje
                {
                    MensajeG = mensajeCifrado + " / " + mensajeDescifrado,
                    Usuario = usuario
                };

                repoUsuario.AgregarMensajes(mensaje, usuario);
                DisplayAlert("Éxito 😀", "¡Mensajes guardados!", "OK");
            }
            else
            {
                DisplayAlert("😥", "No se encontró el usuario.", "OK");
            }
        }
    }
}
