using AppTFG.Data;
using AppTFG.Views;

namespace AppTFG
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            var userRepository = new UserRepository();
            var user = userRepository.GetUserInfo(usernameEntry.Text, passwordEntry.Text);

            if (user != null)
            {
                string mensaje = "¡Bienvenido " + user.Username + "!";
                await DisplayAlert("Inicio de sesión correcto", mensaje, "OK");

                if (user.Username.ToLower() == "a" && passwordEntry.Text == "a")
                {
                    await Navigation.PushAsync(new VistaAdmin());
                }
                else
                {
                    await Navigation.PushAsync(new VistaMenu());
                }
            }
            else
            {
                await DisplayAlert("ERROR", "Credenciales incorrectas", "Volver");
            }
        }

        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VistaRegistro());
        }

        private void btnSalir_Clicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
        }
    }
}
