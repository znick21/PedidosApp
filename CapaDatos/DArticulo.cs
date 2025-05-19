﻿using System;
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
    public class DArticulo : DbConnection
    {
        //Campos y propiedades
        private int _Idarticulo;
        private string _Codigo;
        private string _Nombre;
        private string _Descripcion;
        private byte[] _Imagen;
        private int _Idcategoria;
        private int _Idpresentacion;
        private string _TextoBuscar;
        //refactorizar las variables privadas para generar las propiedadas
        public int Idarticulo { get => _Idarticulo; set => _Idarticulo = value; }
        public string Codigo { get => _Codigo; set => _Codigo = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public byte[] Imagen { get => _Imagen; set => _Imagen = value; }
        public int Idcategoria { get => _Idcategoria; set => _Idcategoria = value; }
        public int Idpresentacion { get => _Idpresentacion; set => _Idpresentacion = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        //Constructores
        public DArticulo()
        {

        }
        public DArticulo(int idarticulo, string codigo, string nombre, string descripcion,
            byte[] imagen, int idcategoria, int idpresentacion, string textobuscar)
        {
            this.Idarticulo = idarticulo;
            this.Codigo = codigo;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Imagen = imagen;
            this.Idcategoria = idcategoria;
            this.Idpresentacion = idpresentacion;
            this.TextoBuscar = textobuscar;
        }

        //Metodo Insertar
        public string Insertar(DArticulo Articulo)
        {
            string rpta = "";
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "spinsertar_articulo";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdarticulo = new SqlParameter();
                        ParIdarticulo.ParameterName = "@idarticulo";
                        ParIdarticulo.SqlDbType = SqlDbType.Int;
                        ParIdarticulo.Direction = ParameterDirection.Output;
                        command.Parameters.Add(ParIdarticulo);

                        SqlParameter ParCodigo = new SqlParameter();
                        ParCodigo.ParameterName = "@codigo";
                        ParCodigo.SqlDbType = SqlDbType.VarChar;
                        ParCodigo.Size = 50;
                        ParCodigo.Value = Articulo.Codigo;
                        command.Parameters.Add(ParCodigo);

                        SqlParameter ParNombre = new SqlParameter();
                        ParNombre.ParameterName = "@nombre";
                        ParNombre.SqlDbType = SqlDbType.VarChar;
                        ParNombre.Size = 50;
                        ParNombre.Value = Articulo.Nombre;
                        command.Parameters.Add(ParNombre);

                        SqlParameter ParDescripcion = new SqlParameter();
                        ParDescripcion.ParameterName = "@descripcion";
                        ParDescripcion.SqlDbType = SqlDbType.VarChar;
                        ParDescripcion.Size = 256;
                        ParDescripcion.Value = Articulo.Descripcion;
                        command.Parameters.Add(ParDescripcion);

                        SqlParameter ParImagen = new SqlParameter();
                        ParImagen.ParameterName = "@imagen";
                        ParImagen.SqlDbType = SqlDbType.Image;
                        ParImagen.Value = Articulo.Imagen;
                        command.Parameters.Add(ParImagen);

                        SqlParameter ParIdcategoria = new SqlParameter();
                        ParIdcategoria.ParameterName = "@idcategoria";
                        ParIdcategoria.SqlDbType = SqlDbType.Int;
                        ParIdcategoria.Value = Articulo.Idcategoria;
                        command.Parameters.Add(ParIdcategoria);

                        SqlParameter ParIdpresentacion = new SqlParameter();
                        ParIdpresentacion.ParameterName = "@idpresentacion";
                        ParIdpresentacion.SqlDbType = SqlDbType.Int;
                        ParIdpresentacion.Value = Articulo.Idpresentacion;
                        command.Parameters.Add(ParIdpresentacion);
                        //Ejecutamos el comando
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
        public string Editar(DArticulo Articulo)
        {
            string rpta = "";
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "speditar_articulo";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdarticulo = new SqlParameter();
                        ParIdarticulo.ParameterName = "@idarticulo";
                        ParIdarticulo.SqlDbType = SqlDbType.Int;
                        ParIdarticulo.Value = Articulo.Idarticulo;
                        command.Parameters.Add(ParIdarticulo);

                        SqlParameter ParCodigo = new SqlParameter();
                        ParCodigo.ParameterName = "@codigo";
                        ParCodigo.SqlDbType = SqlDbType.VarChar;
                        ParCodigo.Size = 50;
                        ParCodigo.Value = Articulo.Codigo;
                        command.Parameters.Add(ParCodigo);

                        SqlParameter ParNombre = new SqlParameter();
                        ParNombre.ParameterName = "@nombre";
                        ParNombre.SqlDbType = SqlDbType.VarChar;
                        ParNombre.Size = 50;
                        ParNombre.Value = Articulo.Nombre;
                        command.Parameters.Add(ParNombre);

                        SqlParameter ParDescripcion = new SqlParameter();
                        ParDescripcion.ParameterName = "@descripcion";
                        ParDescripcion.SqlDbType = SqlDbType.VarChar;
                        ParDescripcion.Size = 256;
                        ParDescripcion.Value = Articulo.Descripcion;
                        command.Parameters.Add(ParDescripcion);

                        SqlParameter ParImagen = new SqlParameter();
                        ParImagen.ParameterName = "@imagen";
                        ParImagen.SqlDbType = SqlDbType.Image;
                        ParImagen.Value = Articulo.Imagen;
                        command.Parameters.Add(ParImagen);

                        SqlParameter ParIdcategoria = new SqlParameter();
                        ParIdcategoria.ParameterName = "@idcategoria";
                        ParIdcategoria.SqlDbType = SqlDbType.Int;
                        ParIdcategoria.Value = Articulo.Idcategoria;
                        command.Parameters.Add(ParIdcategoria);

                        SqlParameter ParIdpresentacion = new SqlParameter();
                        ParIdpresentacion.ParameterName = "@idpresentacion";
                        ParIdpresentacion.SqlDbType = SqlDbType.Int;
                        ParIdpresentacion.Value = Articulo.Idpresentacion;
                        command.Parameters.Add(ParIdpresentacion);
                        //Ejecutamos el comando
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
        public string Eliminar(DArticulo Articulo)
        {
            string rpta = "";
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "speliminar_articulo";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIdarticulo = new SqlParameter();
                        ParIdarticulo.ParameterName = "@idarticulo";
                        ParIdarticulo.SqlDbType = SqlDbType.Int;
                        ParIdarticulo.Value = Articulo.Idarticulo;
                        command.Parameters.Add(ParIdarticulo);                       
                        //Ejecutamos el comando
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
            DataTable DtResultado = new DataTable("articulo");
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "spmostrar_articulo";
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
        public DataTable BuscarNombre(DArticulo Articulo)
        {
            DataTable DtResultado = new DataTable("articulo");
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "spbuscar_articulo_nombre";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParTextoBuscar = new SqlParameter();
                        ParTextoBuscar.ParameterName = "@textobuscar";
                        ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                        ParTextoBuscar.Size = 50;
                        ParTextoBuscar.Value = Articulo.TextoBuscar;
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
        //Metodo stock articulos
        public DataTable Stock_Articulos()
        {
            DataTable DtResultado = new DataTable("articulo");
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "spstock_articulos";
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
    }
}
