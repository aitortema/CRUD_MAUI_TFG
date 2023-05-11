using AppTFG.Views;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using System.Diagnostics;
using Xamarin.Essentials;
using System;

namespace AppTFG.Views;
public partial class VistaMenu : ContentPage
{
    public VistaMenu()
    {
        InitializeComponent();
    }

    private void BtnVistaCifrarTXT(object sender, EventArgs e)
    {
        Navigation.PushAsync(new VistaCifrarTXT());
    }

    private void BtnVistaCifrarIMG(object sender, EventArgs e)
    {
        Navigation.PushAsync(new VistaCifrarIMG());
        //DisplayAlert("😥", "Todavía no disponible ", "OK");
    }

    private async void btnAcercaDe_Clicked(object sender, EventArgs e)
    {
        await DisplayAlert("Información", "Con esta app podrás cifrar y descifrar mensajes personales usando algoritmos clásicos, algoritmos más modernos con mejor seguridad y enviarlos codificados a un destinatario.\n\n¡Úsala y comparte! 😀", "OK");
    }

    private async void btnCodigo_Clicked(object sender, EventArgs e)
    {
        await DisplayAlert("😀", "¡A por el código fuente!", "OK");
        await Microsoft.Maui.ApplicationModel.Browser.OpenAsync("https://github.com/aitortema/CRUD_MAUI_TFG/tree/master/AppTFG");
    }

    private async void BtnCompartir_Clicked(object sender, EventArgs e)
    {
        var request = new Microsoft.Maui.ApplicationModel.DataTransfer.ShareTextRequest
        {
            Text = "¡Mira esta app para cifrar y descifrar mensajes!"
        };
        await Microsoft.Maui.ApplicationModel.DataTransfer.Share.RequestAsync(request);
    }

    private void btnSalir_Clicked(object sender, EventArgs e)
    {
        System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
    }
}
