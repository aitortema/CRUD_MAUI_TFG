using SQLite;

namespace AppTFG.Modelo
{
    public class Mensajes
    {
        [Unique]
        public int Id { get; set; }
        public string Mensaje { get; set; }

        public Mensajes() { }

        public Mensajes(int id, string mensaje)
        {
            this.Id = id;
            this.Mensaje = mensaje;
        }

        public Mensajes(string mensaje)
        {
            this.Mensaje = mensaje;
        }
    }
}
