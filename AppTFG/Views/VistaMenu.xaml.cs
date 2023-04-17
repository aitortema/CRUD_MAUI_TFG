namespace AppTFG.Views;
using AppTFG.Views;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;


public partial class VistaMenu : ContentPage
{
	public VistaMenu()
	{
		InitializeComponent();
	}

	private void BtnVistaCifrarTXT(object sender, EventArgs e)
	{
        // Agrega la lógica necesaria para verificar las credenciales del usuario aquí
        // Si las credenciales son correctas, puedes abrir la siguiente página
        Navigation.PushAsync(new VistaCifrarTXT());
    }

    private void BtnVistaCifrarIMG(object sender, EventArgs e)
	{
		DisplayAlert("😥", "Todavía no disponible ", "OK");
	}
}