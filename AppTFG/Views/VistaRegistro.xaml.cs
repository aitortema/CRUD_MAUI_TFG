using SQLite;
using AppTFG.Modelo;

namespace AppTFG
{
    public partial class VistaRegistro : ContentPage
    {
        private string _dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "usuarios.db3");

        public VistaRegistro(string dbPath, Entry usernameEntry, Entry passwordEntry)
        {
            _dbPath = dbPath;
            UsernameEntry = usernameEntry;
            PasswordEntry = passwordEntry;
        }

        private void OnRegisterClicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.CreateTable<User>();

            var userExists = db.Table<User>().FirstOrDefault(u => u.Username == UsernameEntry.Text);
            if (userExists != null)
            {
                DisplayAlert("REGISTRO", "El usuario ya existe.", "OK");
                Navigation.PushAsync(new MainPage());
            }
            else
            {
                string granito3 = EncriptadorPWD.GranitoDeSal();
                string pwdHasheada = EncriptadorPWD.HashearPWD(PasswordEntry.Text, granito3);
                var nuevoUser = new User(UsernameEntry.Text, pwdHasheada, granito3);

                db.Insert(nuevoUser);
                // Registro correcto
                DisplayAlert("REGISTRO", "Registro correcto.", "OK");
                // Volver a MainPage
                Navigation.PushAsync(new MainPage());
            }
        }

        private async void OnTermsButtonClicked(object sender, EventArgs e)
        {
            await Launcher.OpenAsync(new Uri("https://policies.google.com/terms?hl=es"));
        }
    }
}
