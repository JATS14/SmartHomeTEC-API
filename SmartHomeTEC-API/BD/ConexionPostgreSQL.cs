using System;
using System.Data;
using Npgsql;
using SmartHomeTEC_API.API;

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


        public void iniciar_Base_Datos()
        {
            // ------------------------------ Tipo
            string queryTipo = "SELECT * FROM TIPO";
            NpgsqlCommand conectorTipo = new NpgsqlCommand(queryTipo, coneccion);
            NpgsqlDataAdapter datosTipo = new NpgsqlDataAdapter(conectorTipo);
            DataTable tabladatosTipo = new DataTable();
            datosTipo.Fill(tabladatosTipo);
           
            foreach (DataRow row in tabladatosTipo.Rows)
            {
                string nombreT = row["Nombre"].ToString();
                string DescripcionT = row["Descripcion"].ToString();
                int TiempoGarantia = Convert.ToInt32(row["TiempoGarantia"]);
                
                Tipo tip = new Tipo(nombreT,DescripcionT,TiempoGarantia);
                Administrador.Lista_tipos.Add(tip);
                //Console.WriteLine(nombreT + " , " + DescripcionT + " , " + TiempoGarantia );
            }
            
            
            // ------------------------------ Dispositivos
            string queryDispositovos = "SELECT * FROM DISPOSITIVO";
            NpgsqlCommand conectorDispositovos = new NpgsqlCommand(queryDispositovos, coneccion);
            NpgsqlDataAdapter datosDispositovos = new NpgsqlDataAdapter(conectorDispositovos);
            DataTable tabladatosDispositovos = new DataTable();
            datosDispositovos.Fill(tabladatosDispositovos);
           
            foreach (DataRow row in tabladatosDispositovos.Rows)
            {
                int numeroSerie = Convert.ToInt32(row["NumeroSerie"]);
                string nombre = row["Nombre"].ToString();
                int precio = Convert.ToInt32(row["Precio"]);
                string marca = row["Marca"].ToString();
                int consumoElectrico = Convert.ToInt32(row["ConsumoElectrico"]);
                string nombreTipo = row["NombreTipo"].ToString();

                Tipo tipo = Administrador.obtnenerTipo(nombreTipo);
                Dispositivo dip = new Dispositivo(nombre, precio, tipo, numeroSerie, marca, consumoElectrico);
                Administrador.lista_Dispositivos.Add(dip);
                
                //Console.WriteLine(numeroSerie + " , " + nombre + " , " + precio + " , " + tipo.nombre + " , " + marca + " , " + consumoElectrico );
            }

            
            // ------------------------------ DISTRIBUIDOR
            string queryDistribuidor = "SELECT * FROM DISTRIBUIDOR";
            NpgsqlCommand conectorDistribuidor = new NpgsqlCommand(queryDistribuidor, coneccion);
            NpgsqlDataAdapter datosDistribuidor = new NpgsqlDataAdapter(conectorDistribuidor);
            DataTable tabladatosDistribuidor = new DataTable();
            datosDistribuidor.Fill(tabladatosDistribuidor);
           
            foreach (DataRow row in tabladatosDistribuidor.Rows)
            {
                int cedulaJuridica = Convert.ToInt32(row["CedulaJuridica"]);
                string regionD = row["Region"].ToString();
                string nombreD = row["Nombre"].ToString();

                Distribuidor distri = new Distribuidor(nombreD, cedulaJuridica, regionD);
                Administrador.lista_Distribuidores.Add(distri);
                
                //Console.WriteLine(cedulaJuridica + " , " + regionD + " , " + nombreD );
            }
            
            // ------------------------------ usuarios
            string queryUsuario = "SELECT * FROM USUARIO";
            NpgsqlCommand conectorUsuario = new NpgsqlCommand(queryUsuario, coneccion);
            NpgsqlDataAdapter datosUsuario = new NpgsqlDataAdapter(conectorUsuario);
            DataTable tabladatosUsuario = new DataTable();
            datosUsuario.Fill(tabladatosUsuario);
           
            foreach (DataRow row in tabladatosUsuario.Rows)
            {
                string correoU = row["Correo"].ToString();
                string contrasenaU = row["Contrasena"].ToString();
                string nombreU = row["Nombre"].ToString();
                string apellidoU = row["Apellido"].ToString();
                string regionU = row["Region"].ToString();
                string paisU = row["Pais"].ToString();
                string direccionU = row["Direccion"].ToString();

                Usuario usu = new Usuario(nombreU, apellidoU, paisU, regionU, correoU, contrasenaU, direccionU);
                Administrador.lista_Usuarios.Add(usu);
                
                //Console.WriteLine(correoU + " , " + contrasenaU + " , " + nombreU + " , " + apellidoU + " , " + regionU + " , " + paisU + " , " + direccionU);
            }
        }


        public void InsertarUsuarioBaseDatos(Usuario usuario)
        {
            string queryInsertarUsuario = "INSERT INTO USUARIO ( Correo, Contrasena, Nombre, Apellido, Region, Pais, Direccion) " +  
             "VALUES('" + usuario.correo + "'," + usuario.Contrasena + ", '" + usuario.nombre + "', '" + usuario.apellido + "', '" + usuario.region + 
             "', '" + usuario.pais + "', '" + usuario.direccion + "');";

            Console.WriteLine(queryInsertarUsuario);
            //NpgsqlCommand conectorTipo = new NpgsqlCommand(queryInsertarUsuario, coneccion);
        }
        
        public void InsertarDispositivoBaseDatos(Dispositivo dispositivo)
        {
            string queryInsertarDispositivo = "INSERT INTO DISPOSITIVO ( NumeroSerie, Nombre, Precio, Marca, ConsumoElectrico, NombreTipo) " +  
                                          "VALUES( " + dispositivo.numero_Serie + ", '" + dispositivo.nombre + "', " + dispositivo.precio + ", '" + 
                                                        dispositivo.marca + "', " + dispositivo.consumo_Electrico + 
                                          ", '" + dispositivo.tipo.nombre + "');";

            Console.WriteLine(queryInsertarDispositivo);
            //NpgsqlCommand conectorTipo = new NpgsqlCommand(queryInsertarDispositivo, coneccion);
        }
        
    }
}