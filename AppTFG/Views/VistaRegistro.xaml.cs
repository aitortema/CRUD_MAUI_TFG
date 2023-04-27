using SQLite;
using Microsoft.Maui.Controls;

namespace AppTFG
{
    public partial class VistaRegistro : ContentPage
    {
        private string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "usuarios.db3");

        public VistaRegistro(string dbPath, Entry usernameEntry, Entry passwordEntry)
        {
            _dbPath = dbPath;
            UsernameEntry = usernameEntry;
            PasswordEntry = passwordEntry;
        }

        private void OnRegisterClicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.CreateTable<AppTFG.Modelo.User>();

            var userExists = db.Table<AppTFG.Modelo.User>().FirstOrDefault(u => u.Username == UsernameEntry.Text);
            if (userExists != null)
            {
                DisplayAlert("REGISTRO", "El usuario ya existe.", "OK");
                Navigation.PushAsync(new MainPage());
            }
            else
            {
                var user = new AppTFG.Modelo.User(UsernameEntry.Text, PasswordEntry.Text);

                db.Insert(user);
                // Registro correcto
                DisplayAlert("REGISTRO", "Registro correcto.", "OK");
                // Volver a MainPage
                Navigation.PushAsync(new MainPage());
            }
        }

        private async void OnTermsButtonClicked(object sender, EventArgs e)
        {
            await Launcher.OpenAsync(new Uri("https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/label?view=net-maui-7.0"));
        }

    }
}
