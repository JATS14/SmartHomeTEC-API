using System.Collections;
using System.Collections.Generic;

namespace SmartHomeTEC_API.API
{
    //Clase que contiene los datos de los Usuarios del sistema
    //contiene los datos necesarios para proceder con la funcionalidad
    public class Usuario
    {
        //Atributos
        public string nombre;
        public string apellido;
        public string pais;
        public string region;
        public string correo;
        private string contrasena;
        public string direccion;

        public IList<Dispositivo> lista_Disp_Usuario = new List<Dispositivo>();
        
        
        //Constructor, getters y setters
        public Usuario(string nombre, string apellido, string pais, string region, string correo, string contrasena, string direccion)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.pais = pais;
            this.region = region;
            this.correo = correo;
            this.contrasena = contrasena;
            this.direccion = direccion;
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
        
        public string Pais
        {
            get => pais;
            set => pais = value;
        }

        public string Region
        {
            get => region;
            set => region = value;
        }

        public string Correo
        {
            get => correo;
            set => correo = value;
        }

        public string Contrasena
        {
            get => contrasena;
            set => contrasena = value;
        }

        public string Direccion
        {
            get => direccion;
            set => direccion = value;
        }

        public IList<Dispositivo> obtener_lista_Dispositivos()
        {
            return lista_Disp_Usuario;
        }
        public void agregar_lista_Dispositivos(Dispositivo dispositivo)
        {
            lista_Disp_Usuario.Add(dispositivo);
        }
        
        
    }
    
}