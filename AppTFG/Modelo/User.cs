using SQLite;

namespace AppTFG.Modelo
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Unique]
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsSelected { get; set; }
        public string GranitoUser { get; set; }

        public User() { }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public User(string username, string password, string granitoSal)
        {
            Username = username;
            Password = password;
            GranitoUser = granitoSal;
        }
    }
}
