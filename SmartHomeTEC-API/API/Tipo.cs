namespace SmartHomeTEC_API.API
{
    public class Tipo
    {
        public string nombre;
        public string descripcion;
        public int tiempoGarantia;

        public Tipo(string nombre, string descripcion, int tiempoGarantia)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.tiempoGarantia = tiempoGarantia;
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

        public int TiempoGarantia
        {
            get => tiempoGarantia;
            set => tiempoGarantia = value;
        }
    }
}