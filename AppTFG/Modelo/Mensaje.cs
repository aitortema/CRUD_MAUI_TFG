using SQLite;
using SQLiteNetExtensions.Attributes;

namespace AppTFG.Modelo
{
    public class Mensaje
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(User))] // Relación con User
        public int IdUsuario { get; set; }

        [ManyToOne]
        public User Usuario { get; set; }

        public string MensajeG { get; set; }

        public Mensaje() { }

        public Mensaje(int userId, string mensaje)
        {
            IdUsuario = userId;
            MensajeG = mensaje;
        }

        public Mensaje(string mensaje, string mensajeDescifrado)
        {
            MensajeG = mensaje;
        }
    }
}
