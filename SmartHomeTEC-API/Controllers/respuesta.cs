namespace SmartHomeTEC_API.Controllers
{
    //Clase que contiene el formato de todas las respuestas de los post de la API
    //Contiene un string con el estatus y un string con datos a enviar
    public class respuesta
    { 
        public string status;
        public string respuestaS;

        //Contructor los datos de respuesta no son siempre necesarios
        public respuesta(string status)
        {
            this.status = status;
        }
        //Getters y setters
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