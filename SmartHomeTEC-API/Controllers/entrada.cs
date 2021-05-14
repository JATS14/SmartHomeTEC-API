namespace SmartHomeTEC_API.Controllers
{
    //Funcion con una plantilla de los datos que pueden entrar desde un post desde la aplicacion web
    public class entrada
    {
        public string entrada1;
        public string entrada2;

        //Contructor
        public entrada(string entrada1, string entrada2)
        {
            this.entrada1 = entrada1;
            this.entrada2 = entrada2;
        }
        //getters y setters
        public string Entrada1
        {
            get => entrada1;
            set => entrada1 = value;
        }

        public string Entrada2
        {
            get => entrada2;
            set => entrada2 = value;
        }
    }
}