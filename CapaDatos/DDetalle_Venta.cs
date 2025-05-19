﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DDetalle_Venta : DbConnection
    {
        private int _Iddetalle_venta;
        private int _Idventa;
        private int _Iddetalle_ingreso;
        private int _Cantidad;
        private decimal _Precio_venta;
        private decimal _Descuento;
        //Propiedades
        public int Iddetalle_venta { get => _Iddetalle_venta; set => _Iddetalle_venta = value; }
        public int Idventa { get => _Idventa; set => _Idventa = value; }
        public int Iddetalle_ingreso { get => _Iddetalle_ingreso; set => _Iddetalle_ingreso = value; }
        public int Cantidad { get => _Cantidad; set => _Cantidad = value; }
        public decimal Precio_venta { get => _Precio_venta; set => _Precio_venta = value; }
        public decimal Descuento { get => _Descuento; set => _Descuento = value; }
        //Constructores
        public DDetalle_Venta()
        {

        }
        public DDetalle_Venta(int iddetalle_venta, int idventa, int iddetalle_ingreso, int cantidad, 
            decimal precio_venta, decimal descuento)
        {
            Iddetalle_venta = iddetalle_venta;
            Idventa = idventa;
            Iddetalle_ingreso = iddetalle_ingreso;
            Cantidad = cantidad;
            Precio_venta = precio_venta;
            Descuento = descuento;
        }
        //Metodo Insertar
        public string Insertar(DDetalle_Venta Detalle_Venta,
            ref SqlConnection SqlCon, ref SqlTransaction SqlTra)
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
                        command.CommandText = "spinsertar_detalle_venta";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter ParIddetalle_Venta = new SqlParameter();
                        ParIddetalle_Venta.ParameterName = "@iddetalle_venta";
                        ParIddetalle_Venta.SqlDbType = SqlDbType.Int;
                        ParIddetalle_Venta.Direction = ParameterDirection.Output;
                        command.Parameters.Add(ParIddetalle_Venta);

                        SqlParameter ParIdventa = new SqlParameter();
                        ParIdventa.ParameterName = "@idventa";
                        ParIdventa.SqlDbType = SqlDbType.Int;
                        ParIdventa.Value = Detalle_Venta.Idventa;
                        command.Parameters.Add(ParIdventa);

                        SqlParameter ParIddetalle_ingreso = new SqlParameter();
                        ParIddetalle_ingreso.ParameterName = "@iddetalle_ingreso";
                        ParIddetalle_ingreso.SqlDbType = SqlDbType.Int;
                        ParIddetalle_ingreso.Value = Detalle_Venta.Iddetalle_ingreso;
                        command.Parameters.Add(ParIddetalle_ingreso);

                        SqlParameter ParCantidad = new SqlParameter();
                        ParCantidad.ParameterName = "@cantidad";
                        ParCantidad.SqlDbType = SqlDbType.Int;
                        ParCantidad.Value = Detalle_Venta.Cantidad;
                        command.Parameters.Add(ParCantidad);

                        SqlParameter ParPrecioVenta = new SqlParameter();
                        ParPrecioVenta.ParameterName = "@precio_venta";
                        ParPrecioVenta.SqlDbType = SqlDbType.Money;
                        ParPrecioVenta.Value = Detalle_Venta.Precio_venta;
                        command.Parameters.Add(ParPrecioVenta);

                        SqlParameter ParDescuento = new SqlParameter();
                        ParDescuento.ParameterName = "@descuento";
                        ParDescuento.SqlDbType = SqlDbType.Money;
                        ParDescuento.Value = Detalle_Venta.Descuento;
                        command.Parameters.Add(ParDescuento);
                        //Ejecutamos nuestro comando
                        rpta = command.ExecuteNonQuery() == 1 ? "OK" : "NO SE INGRESO EL REGISTRO";
                    }
                    catch (Exception ex)
                    {
                        rpta = ex.Message;
                    }
                }
            }
            return rpta;
        }
    }
}