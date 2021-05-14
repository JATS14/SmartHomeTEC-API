namespace SmartHomeTEC_API.API
{
    //Clase que contiene los datos de los dispositivos del sistema
    //contiene los datos necesarios para proceder con la funcionalidad
    public class Dispositivo
    {
        public string nombre;
        public int precio;
        public Tipo tipo;
        public int numero_Serie;
        public string marca;
        public int consumo_Electrico;

        //Contructor
        public Dispositivo(string nombre, int precio, Tipo tipo, int numeroSerie, string marca, int consumoElectrico)
        {
            this.nombre = nombre;
            this.precio = precio;
            this.tipo = tipo;
            numero_Serie = numeroSerie;
            this.marca = marca;
            consumo_Electrico = consumoElectrico;
        }
        //Getters y setters
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

        public Tipo Tipo
        {
            get => tipo;
            set => tipo = value;
        }

        public int NumeroSerie
        {
            get => numero_Serie;
            set => numero_Serie = value;
        }

        public string Marca
        {
            get => marca;
            set => marca = value;
        }

        public int ConsumoElectrico
        {
            get => consumo_Electrico;
            set => consumo_Electrico = value;
        }
    }
    
}