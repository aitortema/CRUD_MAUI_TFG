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
            conexionBBDD.CreateTable<Mensajes>();
        }

        public User GetUserInfo(string username)
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
            return conexionBBDD.Get<User>(id);
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
    }
}
