using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Linq.Expressions;

namespace CapaDatos
{
    public class DCategoria : DbConnection
    {
        //Campos y propiedades
        private int _idcategoria;
        private string _nombre;
        private string _descripcion;
        private string _textobuscar;
        //refactorizar las variables privadas para generar las propiedadas
        public int Idcategoria { get => _idcategoria; set => _idcategoria = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public string Textobuscar { get => _textobuscar; set => _textobuscar = value; }
        //Constructor vacio
        public DCategoria() { }
        //Constructor con parametros
        public DCategoria(int idcategoria,string nombre,string descripcion,string textobuscar)
        {
            this.Idcategoria = idcategoria;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Textobuscar = textobuscar;
        }
        //Metodo Insertar
        public string Insertar(DCategoria Categoria)
        {
            string rpta = "";
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "spinsertar_categoria";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdcategoria = new SqlParameter();
                        ParIdcategoria.ParameterName = "@idcategoria";
                        ParIdcategoria.SqlDbType = SqlDbType.Int;
                        ParIdcategoria.Direction = ParameterDirection.Output;
                        command.Parameters.Add(ParIdcategoria);

                        SqlParameter ParNombre = new SqlParameter();
                        ParNombre.ParameterName = "@nombre";
                        ParNombre.SqlDbType = SqlDbType.VarChar;
                        ParNombre.Size = 50;
                        ParNombre.Value = Categoria.Nombre;
                        command.Parameters.Add(ParNombre);

                        SqlParameter ParDescripcion = new SqlParameter();
                        ParDescripcion.ParameterName = "@descripcion";
                        ParDescripcion.SqlDbType = SqlDbType.VarChar;
                        ParDescripcion.Size = 256;
                        ParDescripcion.Value = Categoria.Descripcion;
                        command.Parameters.Add(ParDescripcion);
                        //Ejecutamos el comando Lambda
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
        //Metodo Editar
        public string Editar(DCategoria Categoria)
        {
            string rpta = "";
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "speditar_categoria";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdcategoria = new SqlParameter();
                        ParIdcategoria.ParameterName = "@idcategoria";
                        ParIdcategoria.SqlDbType = SqlDbType.Int;
                        ParIdcategoria.Value = Categoria.Idcategoria;
                        command.Parameters.Add(ParIdcategoria);

                        SqlParameter ParNombre = new SqlParameter();
                        ParNombre.ParameterName = "@nombre";
                        ParNombre.SqlDbType = SqlDbType.VarChar;
                        ParNombre.Size = 50;
                        ParNombre.Value = Categoria.Nombre;
                        command.Parameters.Add(ParNombre);

                        SqlParameter ParDescripcion = new SqlParameter();
                        ParDescripcion.ParameterName = "@descripcion";
                        ParDescripcion.SqlDbType = SqlDbType.VarChar;
                        ParDescripcion.Size = 256;
                        ParDescripcion.Value = Categoria.Descripcion;
                        command.Parameters.Add(ParDescripcion);
                        //Ejecutamos el comando Lambda
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
        //Metodo Eliminar
        public string Eliminar(DCategoria Categoria)
        {
            string rpta = "";
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "speliminar_categoria";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdcategoria = new SqlParameter();
                        ParIdcategoria.ParameterName = "@idcategoria";
                        ParIdcategoria.SqlDbType = SqlDbType.Int;
                        ParIdcategoria.Value = Categoria.Idcategoria;
                        command.Parameters.Add(ParIdcategoria);

                        //Ejecutamos el comando Lambda
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
        //Metodo Mostrar
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("categoria");
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "spmostrar_categoria";
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
        //Metodo BuscarNombre
        public DataTable BuscarNombre(DCategoria Categoria)
        {
            DataTable DtResultado = new DataTable("categoria");
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "spbuscar_categoria";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParTextoBuscar = new SqlParameter();
                        ParTextoBuscar.ParameterName = "@textobuscar";
                        ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                        ParTextoBuscar.Size = 50;
                        ParTextoBuscar.Value = Categoria.Textobuscar;
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
    }
}
