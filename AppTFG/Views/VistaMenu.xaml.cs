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
        await DisplayAlert("😥", "EN CONSTRUCCIÓN", "Volver");
    }

}
