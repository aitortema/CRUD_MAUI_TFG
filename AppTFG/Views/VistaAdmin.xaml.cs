using AppTFG.Data;
using AppTFG.Modelo;
using System.Collections.ObjectModel;

namespace AppTFG.Views
{
    public partial class VistaAdmin : ContentPage
    {
        private UserRepository _userRepository;
        private ObservableCollection<User> _users;

        public VistaAdmin()
        {
            InitializeComponent();
            _userRepository = new UserRepository();
            LoadData();
        }

        private void LoadData()
        {
            _users = new ObservableCollection<User>(_userRepository.GetAllUsers());
            dataCollectionView.ItemsSource = _users;
        }

        private void ClickAgregar(object sender, EventArgs e)
        {
            CreateUserGrid.IsVisible = true;
        }

        private void ClickUpdate(object sender, EventArgs e)
        {
            var userToUpdate = (User)dataCollectionView.SelectedItem;

            if (userToUpdate != null)
            {
                UsernameEntry.Text = userToUpdate.Username;
                PasswordEntry.Text = userToUpdate.Password;
                UpdateUserGrid.IsVisible = true;
            }
        }

        private async void ClickBorrar(object sender, EventArgs e)
        {
            var userToDelete = (User)dataCollectionView.SelectedItem;

            if (userToDelete != null)
            {
                bool confirmar = await DisplayAlert("Eliminar usuario", $"¿Estás seguro de que deseas eliminar a {userToDelete.Username}?", "Sí", "No");
                if (confirmar)
                {
                    _userRepository.BorrarUsuario(userToDelete.Id);
                    LoadData();

                    // Establece el elemento seleccionado en null para evitar errores
                    dataCollectionView.SelectedItem = null;
                }
            }
        }

        private void OnUserSelected(object sender, SelectionChangedEventArgs e)
        {
            var user = (User)e.CurrentSelection.FirstOrDefault();
            if (user != null)
            {
                // UpdateUserGrid.BackgroundColor = Color.FromHex("#0000FF");
                UpdateUserGrid.BackgroundColor = Color.FromHex("#2736e3");

            }
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var user = (User)e.CurrentSelection.FirstOrDefault();
            if (user != null)
            {
                UpdateUserGrid.IsVisible = true;
                UsernameEntry.Text = user.Username;
                PasswordEntry.Text = user.Password;
            }
        }

        private void SaveNewUser(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NewUsernameEntry.Text) && !string.IsNullOrWhiteSpace(NewPasswordEntry.Text))
            {
                var newUser = new User
                {
                    Username = NewUsernameEntry.Text,
                    Password = NewPasswordEntry.Text
                };

                string granito3 = EncriptadorPWD.GranitoDeSal();
                string pwdHasheada = EncriptadorPWD.HashearPWD(newUser.Password, granito3);
                newUser.Password = pwdHasheada;
                newUser.GranitoUser = granito3;

                _userRepository.AgregarUsuario(newUser);

                LoadData();

                NewUsernameEntry.Text = "";
                NewPasswordEntry.Text = "";
                CreateUserGrid.IsVisible = false;
            }
        }

        private void CancelCreateUser(object sender, EventArgs e)
        {
            // Limpiar
            NewUsernameEntry.Text = "";
            NewPasswordEntry.Text = "";

            // Ocultar vista
            CreateUserGrid.IsVisible = false;
        }

        private void GuardarUpdatedUser(object sender, EventArgs e)
        {
            var userToUpdate = (User)dataCollectionView.SelectedItem;

            if (userToUpdate != null)
            {
                string granito4 = EncriptadorPWD.GranitoDeSal();
                string pwdHasheada = EncriptadorPWD.HashearPWD(PasswordEntry.Text, granito4);
                userToUpdate.Username = UsernameEntry.Text;
                userToUpdate.Password = pwdHasheada;

                _userRepository.UpdateUsuario(userToUpdate);
                
                LoadData(); // ACTUALIZAR USUARIOS
            }

            UpdateUserGrid.IsVisible = false;
        }

        private void CancelUpdateUser(object sender, EventArgs e)
        {
            UpdateUserGrid.IsVisible = false;
        }
    }
}
