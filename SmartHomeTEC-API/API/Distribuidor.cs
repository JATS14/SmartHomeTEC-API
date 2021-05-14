namespace SmartHomeTEC_API.API
{
    //Clase que contiene los datos de los distribuidores del sistema
    //contiene los datos necesarios para proceder con la funcionalidad
    public class Distribuidor
    {
        
        public string nombre;
        public int cedula_Juridica;
        public string region;

            //contructor
        public Distribuidor(string nombre, int cedulaJuridica, string region)
        {
            this.nombre = nombre;
            cedula_Juridica = cedulaJuridica;
            this.region = region;
        }
        //getters y setters
        public string Nombre
        {
            get => nombre;
            set => nombre = value;
        }

        public int CedulaJuridica
        {
            get => cedula_Juridica;
            set => cedula_Juridica = value;
        }

        public string Region
        {
            get => region;
            set => region = value;
        }
    }
}