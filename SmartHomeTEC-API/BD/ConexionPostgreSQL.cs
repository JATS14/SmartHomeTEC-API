using System;
using System.Data;
using Npgsql;
using SmartHomeTEC_API.API;

namespace SmartHomeTEC_API.BD
{
    //Esta clase es la encargada de la coneccion con la base de datos de SMARTHOMETEC
    //posee toda la configuracion para una connecion a la base de datos de forma modular
    public class ConexionPostgreSQL
    {
        private NpgsqlConnection coneccion = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = admin; DataBase = postgres");
        private int numeroPedido = 58469755;
        private int cantPedidos = 0;
        
        //Funcion que crea una coneccion con la base de datos
        public void Conectar()
        {
            coneccion.Open();
            Console.WriteLine("Conectado a la Base de Datos en PostgreSQL");   
        }

        //Funcion que descionecta el API de la base de datos
        public void Desconetar()
        {
            coneccion.Close();
            Console.WriteLine("Desconectado de la Base de Datos en PostgreSQL"); 
        }

        //Funcion en cargada de converir todos los datos que estan en la base de datos
        //a objetos que se pueden utilizar en el API
        //Esta funcion carga los datos iniciales de populacion que se encuentran en la base de datos.
        // Lo hace para la clase tipo, usuario, distribuidor y dispositivo
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

        //Funcion que inserta un usuario a la base de datos
        //Entrada: un usuario nuevo para la base de datos
        //Saliada: esta funcion no tiene salidas
        //restricciones: el usuario no puede ser nulo
        public void InsertarUsuarioBaseDatos(Usuario usuario)
        {
            IDbCommand command = coneccion.CreateCommand();
            string queryInsertarUsuario = "INSERT INTO USUARIO ( Correo, Contrasena, Nombre, Apellido, Region, Pais, Direccion) VALUES( @CorreoU, @ContrasenaU, @NombreU, @ApellidoU, @RegionU, @PaisU, @DireccionU);";
            
            command.CommandText = queryInsertarUsuario;
            
            var parameter = command.CreateParameter();
            parameter.ParameterName = "CorreoU";
            parameter.Value = usuario.correo;
            command.Parameters.Add(parameter);
            
            parameter = command.CreateParameter();
            parameter.ParameterName = "ContrasenaU";
            parameter.Value = usuario.Contrasena;
            command.Parameters.Add(parameter);
            
            parameter = command.CreateParameter();
            parameter.ParameterName = "NombreU";
            parameter.Value = usuario.nombre;
            command.Parameters.Add(parameter);
            
            parameter = command.CreateParameter();
            parameter.ParameterName = "ApellidoU";
            parameter.Value = usuario.Apellido;
            command.Parameters.Add(parameter);
            
            parameter = command.CreateParameter();
            parameter.ParameterName = "RegionU";
            parameter.Value = usuario.Region;
            command.Parameters.Add(parameter);
            
            parameter = command.CreateParameter();
            parameter.ParameterName = "PaisU";
            parameter.Value = usuario.Pais;
            command.Parameters.Add(parameter);
            
            parameter = command.CreateParameter();
            parameter.ParameterName = "DireccionU";
            parameter.Value = usuario.Direccion;
            command.Parameters.Add(parameter);
            
            command.ExecuteNonQuery();
            
        }
        //Funcion que inserta un dispositivo a la base de datos
        //Entrada: un dispositivo nuevo para la base de datos
        //Saliada: esta funcion no tiene salidas
        //restricciones: el dispositivo no puede ser nulo
        public void InsertarDispositivoBaseDatos(Dispositivo dispositivo)
        {
            IDbCommand command = coneccion.CreateCommand();
            string queryInsertarDispositivo = "INSERT INTO DISPOSITIVO ( NumeroSerie, Nombre, Precio, Marca, ConsumoElectrico, NombreTipo) VALUES( @NumeroSerieD, @NombreD, @PrecioD, @MarcaD, @ConsumoElectricoD, @NombreTipoD);";

            command.CommandText = queryInsertarDispositivo;
            
            var parameter = command.CreateParameter();
            parameter.ParameterName = "NumeroSerieD";
            parameter.Value = dispositivo.numero_Serie;
            command.Parameters.Add(parameter);
            
            parameter = command.CreateParameter();
            parameter.ParameterName = "NombreD";
            parameter.Value = dispositivo.nombre;
            command.Parameters.Add(parameter);
            
            parameter = command.CreateParameter();
            parameter.ParameterName = "PrecioD";
            parameter.Value = dispositivo.precio;
            command.Parameters.Add(parameter);
            
            parameter = command.CreateParameter();
            parameter.ParameterName = "MarcaD";
            parameter.Value = dispositivo.marca;
            command.Parameters.Add(parameter);
            
            parameter = command.CreateParameter();
            parameter.ParameterName = "ConsumoElectricoD";
            parameter.Value = dispositivo.consumo_Electrico;
            command.Parameters.Add(parameter);
            
            parameter = command.CreateParameter();
            parameter.ParameterName = "NombreTipoD";
            parameter.Value = dispositivo.tipo.nombre;
            command.Parameters.Add(parameter);
            
            
            command.ExecuteNonQuery();
        }
        //Funcion que inserta un Tipo a la base de datos
        //Entrada: un Tipo nuevo para la base de datos
        //Saliada: esta funcion no tiene salidas
        //restricciones: el Tipo no puede ser nulo
        public void InsertarTipoBaseDatos(Tipo tipo)
        {
            IDbCommand command = coneccion.CreateCommand();
            string queryInsertarDispositivo = "INSERT INTO TIPO( Nombre, Descripcion, TiempoGarantia) VALUES( @NombreT, @DescripcionT, @TiempoGarantiaT);";
            
            command.CommandText = queryInsertarDispositivo;
            
            var parameter = command.CreateParameter();
            parameter.ParameterName = "NombreT";
            parameter.Value = tipo.nombre;
            command.Parameters.Add(parameter);
            
            parameter = command.CreateParameter();
            parameter.ParameterName = "DescripcionT";
            parameter.Value = tipo.descripcion;
            command.Parameters.Add(parameter);
            
            parameter = command.CreateParameter();
            parameter.ParameterName = "TiempoGarantiaT";
            parameter.Value = tipo.tiempoGarantia;
            command.Parameters.Add(parameter);
            
            command.ExecuteNonQuery();

        }
        //Funcion que inserta un pedido a la base de datos
        //Entrada: un pedido nuevo para la base de datos
        //Saliada: esta funcion no tiene salidas
        //restricciones: el pedido no puede ser nulo
        public void InsertarPedidoBaseDatos(Dispositivo dispositivo)
        {
            IDbCommand command = coneccion.CreateCommand();
            string queryInsertarDispositivo = "INSERT INTO PEDIDO ( NumeroPedido , Fecha, Hora, NombreTipo, Marca, NumeroSerie, Precio) VALUES( @NumeroPedidoF, @FechaF, @HoraF, @NombreTipoF, @MarcaF, @NumeroSerieF, @PrecioF);";

            command.CommandText = queryInsertarDispositivo;
            
            
            
            cantPedidos++;
            var parameter = command.CreateParameter();
            parameter.ParameterName = "NumeroPedidoF";
            parameter.Value = (numeroPedido+10*cantPedidos);
            command.Parameters.Add(parameter);

            parameter = command.CreateParameter();
            parameter.ParameterName = "FechaF";
            parameter.Value = DateTime.Now.ToString("yyyy-MM-dd");
            command.Parameters.Add(parameter);
            
            parameter = command.CreateParameter();
            parameter.ParameterName = "HoraF";
            parameter.Value = DateTime.Now.ToString("hh:mm:ss");
            command.Parameters.Add(parameter);
            
            parameter = command.CreateParameter();
            parameter.ParameterName = "NombreTipoF";
            parameter.Value = dispositivo.tipo.nombre;
            command.Parameters.Add(parameter);
            
            parameter = command.CreateParameter();
            parameter.ParameterName = "MarcaF";
            parameter.Value = dispositivo.marca;
            command.Parameters.Add(parameter);
            
            parameter = command.CreateParameter();
            parameter.ParameterName = "NumeroSerieF";
            parameter.Value = dispositivo.numero_Serie;
            command.Parameters.Add(parameter);
            
            parameter = command.CreateParameter();
            parameter.ParameterName = "PrecioF";
            parameter.Value = dispositivo.precio;
            command.Parameters.Add(parameter);
            
            command.ExecuteNonQuery();
        }
        
    }
}