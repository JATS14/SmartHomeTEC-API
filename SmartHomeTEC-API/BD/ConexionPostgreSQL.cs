using System;
using Npgsql;

namespace SmartHomeTEC_API.BD
{
    public class ConexionPostgreSQL
    {
        private NpgsqlConnection coneccion = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = admin; DataBase = postgres");


        public void Conectar()
        {
            coneccion.Open();
            Console.WriteLine("Conectado a la Base de Datos en PostgreSQL");   
        }


        public void Desconetar()
        {
            coneccion.Close();
            Console.WriteLine("Desconectado de la Base de Datos en PostgreSQL"); 
        }
        
        
    }
}