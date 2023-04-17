namespace AppTFG.Views;

using AppTFG.Modelo;
using Microsoft.Maui.Controls;


public partial class VistaCifrarTXT : ContentPage
{
    public int CifradoEscogido { get; set; }

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
        else
        {
            CifradoEscogido = 0;
        }
    }


    private void Enviar_Clicked(object sender, EventArgs e)
    {
        // ================================== CIFRAR TEXTO
        string mensaje = mensajeAcifrar.Text;
        int cifradoEscogido = CifradoEscogido;

        switch (picker.SelectedItem.ToString())
        {
            case "Morse":
                string mensajeCifradoMorse = CifradorTXT.CifrarMorse(mensaje);
                Clipboard.SetTextAsync(mensajeCifradoMorse);
                DisplayAlert("Cifrado", "Mensaje en MORSE copiado al portapapeles", "Guay");
                txtResEditor.Text = mensajeCifradoMorse;
                break;
            case "Base64":
                string mensajeCifradoBase64 = CifradorTXT.CifrarBase64(mensaje);
                Clipboard.SetTextAsync(mensajeCifradoBase64);
                DisplayAlert("Cifrado", "Mensaje en BASE64 copiado al portapapeles", "Guay");
                txtResEditor.Text = mensajeCifradoBase64;
                break;
            case "Binario":
                string mensajeCifradoBinario = CifradorTXT.CifrarBinario(mensaje);
                Clipboard.SetTextAsync(mensajeCifradoBinario);
                DisplayAlert("Cifrado", "Mensaje en BINARIO copiado al portapapeles", "Guay");
                txtResEditor.Text = mensajeCifradoBinario;
                break;
            case "Cesar":
                string mensajeCifradoCesar = CifradorTXT.CifrarCesar(mensaje, cifradoEscogido);
                Clipboard.SetTextAsync(mensajeCifradoCesar);
                DisplayAlert("Cifrado", "Mensaje en CESAR copiado al portapapeles", "Guay");
                txtResEditor.Text = mensajeCifradoCesar;
                break;
            case "Vigenere":
                string mensajeCifradoVigenere = CifradorTXT.CifrarVigenere(mensaje);
                Clipboard.SetTextAsync(mensajeCifradoVigenere);
                DisplayAlert("Cifrado", "Mensaje en VIGENERE copiado al portapapeles", "Guay");
                txtResEditor.Text = mensajeCifradoVigenere;
                break;
            default:
                break;
        }
    }
}