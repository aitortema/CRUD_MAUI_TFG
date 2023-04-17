using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTFG.Modelo;
using SQLite;

namespace AppTFG.Data
{
    public class UserRepository
    {
        private readonly SQLiteConnection conexionBBDD;

        public UserRepository()
        {
            var dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "usuarios.db3");
            conexionBBDD = new SQLiteConnection(dbPath);
            conexionBBDD.CreateTable<User>();
        }

        public User GetUserInfo(string username, string password)
        {
            var user = conexionBBDD.Table<User>().FirstOrDefault(u => u.Username == username && u.Password == password);
            return user;
        }

        public List<User> GetAllUsers()
        {
            return conexionBBDD.Table<User>().ToList();
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
