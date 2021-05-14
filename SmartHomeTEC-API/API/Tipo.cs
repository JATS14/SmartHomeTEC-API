namespace SmartHomeTEC_API.API
{
    //Clase que contiene los datos de los Tipos del sistema
    //contiene los datos necesarios para proceder con la funcionalidad
    public class Tipo
    {
        public string nombre;
        public string descripcion;
        public int tiempoGarantia;

        //Contructor
        public Tipo(string nombre, string descripcion, int tiempoGarantia)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.tiempoGarantia = tiempoGarantia;
        }
        //getters y setters
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