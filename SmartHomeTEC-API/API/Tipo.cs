namespace SmartHomeTEC_API.API
{
    public class Tipo
    {
        public string nombre;
        public string descripcion;
        public int tiempoGrarantia;

        public Tipo(string nombre, string descripcion, int tiempoGrarantia)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.tiempoGrarantia = tiempoGrarantia;
        }

        public string Nombre
        {
            get => nombre;
            set => nombre = value;
        }

        public string Descripcion
        {
            get => descripcion;
            set => descripcion = value;
        }

        public int TiempoGrarantia
        {
            get => tiempoGrarantia;
            set => tiempoGrarantia = value;
        }
    }
}