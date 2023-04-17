using SQLite;
using CommunityToolkit.Mvvm;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace AppTFG.Modelo
{

    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsSelected { get; set; }

        public User() { }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }

}
