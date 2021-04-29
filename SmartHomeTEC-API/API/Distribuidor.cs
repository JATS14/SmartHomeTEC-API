namespace SmartHomeTEC_API.API
{
    public class Distribuidor
    {
        
        public string nombre;
        public int cedula_Juridica;
        public string region;

        public Distribuidor(string nombre, int cedulaJuridica, string region)
        {
            this.nombre = nombre;
            cedula_Juridica = cedulaJuridica;
            this.region = region;
        }

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