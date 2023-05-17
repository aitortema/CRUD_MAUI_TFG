using AppTFG.Data;
using AppTFG.Modelo;
using AppTFG.Views;
using Microsoft.Maui.Controls;

namespace AppTFG
{
    public partial class MainPage : ContentPage
    {
        public int IdUsuarioActivo { get; set; }

        public MainPage()
        {
            InitializeComponent();
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            var userRepository = new UserRepository();
            var user = userRepository.GetUserInfo(usernameEntry.Text);

            if (user != null)
            {
                // Hashear la contraseña ingresada con el grano de sal almacenado para el usuario
                string hashedPassword = EncriptadorPWD.HashearPWD(passwordEntry.Text, user.GranitoUser);

                // Verificar si la contraseña hasheada coincide con la almacenada en la base de datos
                if (user.Password == hashedPassword)
                {
                    //IdUsuarioActivo = user.Id; // Guardar id para después guardar mensajes
                    string mensaje = "¡Bienvenido " + user.Username + "!";
                    await DisplayAlert("Inicio de sesión correcto", mensaje, "OK");

                    if (user.Username == "aitor" && passwordEntry.Text == "1234")
                    {
                        await Navigation.PushAsync(new VistaAdmin());
                    }
                    else
                    {
                        VistaCifrarTXT vistaCifrar = new VistaCifrarTXT();
                        //vistaCifrar.IdUsuarioActivo = user.Id;
                        await Navigation.PushAsync(new VistaMenu());
                    }
                }
                else
                {
                    await DisplayAlert("ERROR", "Credenciales incorrectas", "Volver");
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
