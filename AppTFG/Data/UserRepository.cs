using AppTFG.Modelo;
using SQLite;

namespace AppTFG.Data
{
    public class UserRepository
    {
        private readonly SQLiteConnection conexionBBDD;

        public UserRepository()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "usuarios.db3");
            conexionBBDD = new SQLiteConnection(dbPath);
            conexionBBDD.CreateTable<User>();
            conexionBBDD.CreateTable<Mensaje>();
        }

        // ============== USUARIOS

        public User GetUserInfo(string username) // NOSTRAR INFO USUARIO
        {
            var user = conexionBBDD.Table<User>().FirstOrDefault(u => u.Username == username);
            return user;
        }

        public List<User> GetAllUsers()
        {
            return conexionBBDD.Table<User>().ToList();
        }

        public User GetUserById(int id)
        {
            return conexionBBDD.Table<User>().FirstOrDefault(u => u.Id == id);
        }

        public void AgregarUsuario(User user)
        {
            conexionBBDD.Insert(user);
        }

        public void UpdateUsuario(User user)
        {
            conexionBBDD.Update(user);
        }

        public void BorrarUsuario(int id)
        {
            conexionBBDD.Delete<User>(id);
        }

        public void AgregarMensajes(Mensaje mensaje, User user)
        {
            if (user != null)
            {
                mensaje.IdUsuario = user.Id;
                conexionBBDD.Insert(mensaje);
            }
        }

        // Cargar primer mensaje
        public Mensaje GetMensajes(string mensajesAguardar)
        {
            var mensaje = conexionBBDD.Table<Mensaje>().FirstOrDefault(m => m.MensajeG == mensajesAguardar);
            return mensaje;
        }

        // Cargar todos los mensajes
        public List<Mensaje> GetMensajesPorUsuario(int userId)
        {
            return conexionBBDD.Table<Mensaje>().Where(m => m.IdUsuario == userId).ToList();
        }

    }
}
