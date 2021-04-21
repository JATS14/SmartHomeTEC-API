namespace SmartHomeTEC_API.API
{
    public class Dispositivo
    {
        public string nombre;
        public int precio;

        public Dispositivo(string nombre, int precio)
        {
            this.nombre = nombre;
            this.precio = precio;
        }

        public string Nombre
        {
            get => nombre;
            set => nombre = value;
        }

        public int Precio
        {
            get => precio;
            set => precio = value;
        }
    }
}