namespace SmartHomeTEC_API.Controllers
{
    public class respuesta
    { 
        public string status;
        public string respuestaS;

        public respuesta(string status)
        {
            this.status = status;
        }

        public string Status
        {
            get => status;
            set => status = value;
        }

        public string RespuestaS
        {
            get => respuestaS;
            set => respuestaS = value;
        }
    }
}