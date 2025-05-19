using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DTrabajador : DbConnection
    {
        //Variables
        private int _Idtrabajador;
        private string _Nombre;
        private string _Apellidos;
        private string _Genero;
        private DateTime _Fecha_Nac;
        private string _Num_Documento;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private string _Acceso;
        private string _Usuario;
        private string _Clave;
        private string _TextoBuscar;
        //Propiedades
        public int Idtrabajador { get => _Idtrabajador; set => _Idtrabajador = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellidos { get => _Apellidos; set => _Apellidos = value; }
        public string Genero { get => _Genero; set => _Genero = value; }
        public DateTime Fecha_Nac { get => _Fecha_Nac; set => _Fecha_Nac = value; }
        public string Num_Documento { get => _Num_Documento; set => _Num_Documento = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Acceso { get => _Acceso; set => _Acceso = value; }
        public string Usuario { get => _Usuario; set => _Usuario = value; }
        public string Clave { get => _Clave; set => _Clave = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }
        //Constructores
        public DTrabajador()
        {

        }
        public DTrabajador(int idtrabajador, string nombre, string apellidos, string genero,
            DateTime fecha_nac, string num_documento, string direccion, string telefono,
            string email, string acceso, string usuario, string clave, string textobuscar)
        {
            this.Idtrabajador = idtrabajador;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Genero = genero;
            this.Fecha_Nac = fecha_nac;
            this.Num_Documento = num_documento;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Email = email;
            this.Acceso = acceso;
            this.Usuario = usuario;
            this.Clave = clave;
            this.TextoBuscar = textobuscar;
        }
        //Métodos
        public string Insertar(DTrabajador Trabajador)
        {
            string rpta = "";
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        //Establecer el Comando
                        command.Connection = connection;
                        command.CommandText = "spinsertar_trabajador";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdtrabajador = new SqlParameter();
                        ParIdtrabajador.ParameterName = "@idtrabajador";
                        ParIdtrabajador.SqlDbType = SqlDbType.Int;
                        ParIdtrabajador.Direction = ParameterDirection.Output;
                        command.Parameters.Add(ParIdtrabajador);

                        SqlParameter ParNombre = new SqlParameter();
                        ParNombre.ParameterName = "@nombre";
                        ParNombre.SqlDbType = SqlDbType.VarChar;
                        ParNombre.Size = 20;
                        ParNombre.Value = Trabajador.Nombre;
                        command.Parameters.Add(ParNombre);

                        SqlParameter ParApellidos = new SqlParameter();
                        ParApellidos.ParameterName = "@apellidos";
                        ParApellidos.SqlDbType = SqlDbType.VarChar;
                        ParApellidos.Size = 40;
                        ParApellidos.Value = Trabajador.Apellidos;
                        command.Parameters.Add(ParApellidos);

                        SqlParameter ParSexo = new SqlParameter();
                        ParSexo.ParameterName = "@genero";
                        ParSexo.SqlDbType = SqlDbType.VarChar;
                        ParSexo.Size = 20;
                        ParSexo.Value = Trabajador.Genero;
                        command.Parameters.Add(ParSexo);

                        SqlParameter ParFecha_Nac = new SqlParameter();
                        ParFecha_Nac.ParameterName = "@fecha_nac";
                        ParFecha_Nac.SqlDbType = SqlDbType.Date;
                        ParFecha_Nac.Value = Trabajador.Fecha_Nac;
                        command.Parameters.Add(ParFecha_Nac);

                        SqlParameter ParNum_Documento = new SqlParameter();
                        ParNum_Documento.ParameterName = "@num_documento";
                        ParNum_Documento.SqlDbType = SqlDbType.VarChar;
                        ParNum_Documento.Size = 11;
                        ParNum_Documento.Value = Trabajador.Num_Documento;
                        command.Parameters.Add(ParNum_Documento);

                        SqlParameter ParDireccion = new SqlParameter();
                        ParDireccion.ParameterName = "@direccion";
                        ParDireccion.SqlDbType = SqlDbType.VarChar;
                        ParDireccion.Size = 100;
                        ParDireccion.Value = Trabajador.Direccion;
                        command.Parameters.Add(ParDireccion);

                        SqlParameter ParTelefono = new SqlParameter();
                        ParTelefono.ParameterName = "@telefono";
                        ParTelefono.SqlDbType = SqlDbType.VarChar;
                        ParTelefono.Size = 11;
                        ParTelefono.Value = Trabajador.Telefono;
                        command.Parameters.Add(ParTelefono);

                        SqlParameter ParEmail = new SqlParameter();
                        ParEmail.ParameterName = "@email";
                        ParEmail.SqlDbType = SqlDbType.VarChar;
                        ParEmail.Size = 50;
                        ParEmail.Value = Trabajador.Email;
                        command.Parameters.Add(ParEmail);

                        SqlParameter ParAcceso = new SqlParameter();
                        ParAcceso.ParameterName = "@acceso";
                        ParAcceso.SqlDbType = SqlDbType.VarChar;
                        ParAcceso.Size = 50;
                        ParAcceso.Value = Trabajador.Acceso;
                        command.Parameters.Add(ParAcceso);

                        SqlParameter ParUsuario = new SqlParameter();
                        ParUsuario.ParameterName = "@usuario";
                        ParUsuario.SqlDbType = SqlDbType.VarChar;
                        ParUsuario.Size = 50;
                        ParUsuario.Value = Trabajador.Usuario;
                        command.Parameters.Add(ParUsuario);

                        SqlParameter ParPassword = new SqlParameter();
                        ParPassword.ParameterName = "@password";
                        ParPassword.SqlDbType = SqlDbType.VarChar;
                        ParPassword.Size = 50;
                        ParPassword.Value = Trabajador.Clave;
                        command.Parameters.Add(ParPassword);
                        //Ejecutamos nuestro comando
                        rpta = command.ExecuteNonQuery() == 1 ? "OK" : "NO SE INGRESO EL REGISTRO";
                    }
                    catch (Exception ex)
                    {
                        rpta = ex.Message;
                    }
                    finally { if (connection.State == ConnectionState.Open) connection.Close(); }
                }
            }
            return rpta;
        }

        //Método Editar
        public string Editar(DTrabajador Trabajador)
        {
            string rpta = "";
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        //Establecer el Comando
                        command.Connection = connection;
                        command.CommandText = "speditar_trabajador";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdtrabajador = new SqlParameter();
                        ParIdtrabajador.ParameterName = "@idtrabajador";
                        ParIdtrabajador.SqlDbType = SqlDbType.Int;
                        ParIdtrabajador.Value = Trabajador.Idtrabajador;
                        command.Parameters.Add(ParIdtrabajador);

                        SqlParameter ParNombre = new SqlParameter();
                        ParNombre.ParameterName = "@nombre";
                        ParNombre.SqlDbType = SqlDbType.VarChar;
                        ParNombre.Size = 20;
                        ParNombre.Value = Trabajador.Nombre;
                        command.Parameters.Add(ParNombre);

                        SqlParameter ParApellidos = new SqlParameter();
                        ParApellidos.ParameterName = "@apellidos";
                        ParApellidos.SqlDbType = SqlDbType.VarChar;
                        ParApellidos.Size = 40;
                        ParApellidos.Value = Trabajador.Apellidos;
                        command.Parameters.Add(ParApellidos);

                        SqlParameter ParSexo = new SqlParameter();
                        ParSexo.ParameterName = "@genero";
                        ParSexo.SqlDbType = SqlDbType.VarChar;
                        ParSexo.Size = 20;
                        ParSexo.Value = Trabajador.Genero;
                        command.Parameters.Add(ParSexo);

                        SqlParameter ParFecha_Nac = new SqlParameter();
                        ParFecha_Nac.ParameterName = "@fecha_nac";
                        ParFecha_Nac.SqlDbType = SqlDbType.Date;
                        ParFecha_Nac.Size = 50;
                        ParFecha_Nac.Value = Trabajador.Fecha_Nac;
                        command.Parameters.Add(ParFecha_Nac);

                        SqlParameter ParNum_Documento = new SqlParameter();
                        ParNum_Documento.ParameterName = "@num_documento";
                        ParNum_Documento.SqlDbType = SqlDbType.VarChar;
                        ParNum_Documento.Size = 11;
                        ParNum_Documento.Value = Trabajador.Num_Documento;
                        command.Parameters.Add(ParNum_Documento);

                        SqlParameter ParDireccion = new SqlParameter();
                        ParDireccion.ParameterName = "@direccion";
                        ParDireccion.SqlDbType = SqlDbType.VarChar;
                        ParDireccion.Size = 100;
                        ParDireccion.Value = Trabajador.Direccion;
                        command.Parameters.Add(ParDireccion);

                        SqlParameter ParTelefono = new SqlParameter();
                        ParTelefono.ParameterName = "@telefono";
                        ParTelefono.SqlDbType = SqlDbType.VarChar;
                        ParTelefono.Size = 11;
                        ParTelefono.Value = Trabajador.Telefono;
                        command.Parameters.Add(ParTelefono);

                        SqlParameter ParEmail = new SqlParameter();
                        ParEmail.ParameterName = "@email";
                        ParEmail.SqlDbType = SqlDbType.VarChar;
                        ParEmail.Size = 50;
                        ParEmail.Value = Trabajador.Email;
                        command.Parameters.Add(ParEmail);

                        SqlParameter ParAcceso = new SqlParameter();
                        ParAcceso.ParameterName = "@acceso";
                        ParAcceso.SqlDbType = SqlDbType.VarChar;
                        ParAcceso.Size = 50;
                        ParAcceso.Value = Trabajador.Acceso;
                        command.Parameters.Add(ParAcceso);

                        SqlParameter ParUsuario = new SqlParameter();
                        ParUsuario.ParameterName = "@usuario";
                        ParUsuario.SqlDbType = SqlDbType.VarChar;
                        ParUsuario.Size = 50;
                        ParUsuario.Value = Trabajador.Usuario;
                        command.Parameters.Add(ParUsuario);

                        SqlParameter ParPassword = new SqlParameter();
                        ParPassword.ParameterName = "@password";
                        ParPassword.SqlDbType = SqlDbType.VarChar;
                        ParPassword.Size = 50;
                        ParPassword.Value = Trabajador.Clave;
                        command.Parameters.Add(ParPassword);
                        //Ejecutamos nuestro comando
                        rpta = command.ExecuteNonQuery() == 1 ? "OK" : "NO SE ACTUALIZO EL REGISTRO";
                    }
                    catch (Exception ex)
                    {
                        rpta = ex.Message;
                    }
                    finally { if (connection.State == ConnectionState.Open) connection.Close(); }
                }
            }
            return rpta;
        }

        //Método Eliminar
        public string Eliminar(DTrabajador Trabajador)
        {
            string rpta = "";
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        //Establecer el Comando
                        command.Connection = connection;
                        command.CommandText = "speliminar_trabajador";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdtrabajador = new SqlParameter();
                        ParIdtrabajador.ParameterName = "@idtrabajador";
                        ParIdtrabajador.SqlDbType = SqlDbType.Int;
                        ParIdtrabajador.Value = Trabajador.Idtrabajador;
                        command.Parameters.Add(ParIdtrabajador);
                        //Ejecutamos nuestro comando
                        rpta = command.ExecuteNonQuery() == 1 ? "OK" : "NO SE ELIMINO EL REGISTRO";
                    }
                    catch (Exception ex)
                    {
                        rpta = ex.Message;
                    }
                    finally { if (connection.State == ConnectionState.Open) connection.Close(); }
                }
            }
            return rpta;
        }
        //Método Mostrar
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("trabajador");
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {                     
                        command.Connection = connection;
                        command.CommandText = "spmostrar_trabajador";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter SqlDat = new SqlDataAdapter(command);
                        SqlDat.Fill(DtResultado);
                    }
                    catch (Exception)
                    {
                        DtResultado = null;
                    }
                }
            }
            return DtResultado;
        }
        //Método BuscarApellidos
        public DataTable BuscarApellidos(DTrabajador Trabajador)
        {
            DataTable DtResultado = new DataTable("trabajador");
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "spbuscar_trabajador_apellidos";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParTextoBuscar = new SqlParameter();
                        ParTextoBuscar.ParameterName = "@textobuscar";
                        ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                        ParTextoBuscar.Size = 50;
                        ParTextoBuscar.Value = Trabajador.TextoBuscar;
                        command.Parameters.Add(ParTextoBuscar);

                        SqlDataAdapter SqlDat = new SqlDataAdapter(command);
                        SqlDat.Fill(DtResultado);
                    }
                    catch (Exception)
                    {
                        DtResultado = null;
                    }
                }
            }
            return DtResultado;
        }
        public DataTable BuscarNum_Documento(DTrabajador Trabajador)
        {
            DataTable DtResultado = new DataTable("trabajador");
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "spbuscar_trabajador_num_documento";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParTextoBuscar = new SqlParameter();
                        ParTextoBuscar.ParameterName = "@textobuscar";
                        ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                        ParTextoBuscar.Size = 50;
                        ParTextoBuscar.Value = Trabajador.TextoBuscar;
                        command.Parameters.Add(ParTextoBuscar);

                        SqlDataAdapter SqlDat = new SqlDataAdapter(command);
                        SqlDat.Fill(DtResultado);
                    }
                    catch (Exception)
                    {
                        DtResultado = null;
                    }
                }
            }
            return DtResultado;
        }

        public DataTable Login(DTrabajador Trabajador)
        {
            DataTable DtResultado = new DataTable("trabajador");
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "splogin";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParUsuario = new SqlParameter();
                        ParUsuario.ParameterName = "@usuario";
                        ParUsuario.SqlDbType = SqlDbType.VarChar;
                        ParUsuario.Size = 50;
                        ParUsuario.Value = Trabajador.Usuario;
                        command.Parameters.Add(ParUsuario);

                        SqlParameter ParPassword = new SqlParameter();
                        ParPassword.ParameterName = "@clave";
                        ParPassword.SqlDbType = SqlDbType.VarChar;
                        ParPassword.Size = 50;
                        ParPassword.Value = Trabajador.Clave;
                        command.Parameters.Add(ParPassword);

                        SqlDataAdapter SqlDat = new SqlDataAdapter(command);
                        SqlDat.Fill(DtResultado);
                    }
                    catch (Exception)
                    {
                        DtResultado = null;
                    }
                }
            }
            return DtResultado;
        }
    }
}
