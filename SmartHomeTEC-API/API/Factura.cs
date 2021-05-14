namespace SmartHomeTEC_API.API
{
    //Clase que contiene los datos de las facturas del sistema
    //contiene los datos necesarios para proceder con la funcionalidad de compra y generar correos con PDFs
    public class Factura
    {
        public string numeroTarjeta;
        public int codigoSeguridad;
        public string nombre;
        public string apellido;
        public string direccionfacturacion;
        public int codigoPostal;
        public int celular;

        //Contructor
        public Factura(string numeroTarjeta, int codigoSeguridad, string nombre, string apellido, string direccionfacturacion, int codigoPostal, int celular)
        {
            this.numeroTarjeta = numeroTarjeta;
            this.codigoSeguridad = codigoSeguridad;
            this.nombre = nombre;
            this.apellido = apellido;
            this.direccionfacturacion = direccionfacturacion;
            this.codigoPostal = codigoPostal;
            this.celular = celular;
        }

        //getters y setters
        public string NumeroTarjeta
        {
            get => numeroTarjeta;
            set => numeroTarjeta = value;
        }

        public int CodigoSeguridad
        {
            get => codigoSeguridad;
            set => codigoSeguridad = value;
        }

        public string Nombre
        {
            get => nombre;
            set => nombre = value;
        }

        public string Apellido
        {
            get => apellido;
            set => apellido = value;
        }

        public string Direccionfacturacion
        {
            get => direccionfacturacion;
            set => direccionfacturacion = value;
        }

        public int CodigoPostal
        {
            get => codigoPostal;
            set => codigoPostal = value;
        }

        public int Celular
        {
            get => celular;
            set => celular = value;
        }
    }
}