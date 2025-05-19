using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PedidosApp1
{
    public partial class FrmProveedor : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        public FrmProveedor()
        {
            InitializeComponent();
            ttMensaje.SetToolTip(txtRazon_Social, "Ingrese la Razon Social del proveedor");
            ttMensaje.SetToolTip(txtNum_Documento, "Ingrese el Numero de Documento del proveedor");
            ttMensaje.SetToolTip(txtDireccion, "Ingrese la Direccion del proveedor");
        }
        //Mostrar mensaje de confirmacion
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Pedidos App", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //Mostrar mensaje de error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Pedidos App", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        //Limpiar todos los controles del formulario
        private void Limpiar()
        {
            txtRazon_Social.Text = string.Empty;
            txtNum_Documento.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtUrl.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtIdproveedor.Text = string.Empty;
        }
        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            txtRazon_Social.ReadOnly = !valor;
            txtNum_Documento.ReadOnly = !valor;
            cbSector_Comercial.Enabled = valor;
            cbTipo_Documento.Enabled = valor;
            txtDireccion.ReadOnly = !valor;
            txtTelefono.ReadOnly = !valor;
            txtUrl.ReadOnly = !valor;
            txtEmail.ReadOnly = !valor;
            txtIdproveedor.ReadOnly = !valor;
        }
        //Habilitar los botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                Habilitar(true);
                btnNuevo.Enabled = false;
                btnGuardar.Enabled = true;
                btnEditar.Enabled = false;
                btnCancelar.Enabled = true;
            }
            else
            {
                Habilitar(false);
                btnNuevo.Enabled = true;
                btnGuardar.Enabled = false;
                btnEditar.Enabled = true;
                btnCancelar.Enabled = false;
            }
        }
        //Metodo para ocultar columnas
        private void OcultarColumnas()
        {
            if(dataListado.RowCount > 0)
            {
                dataListado.Columns[0].Visible = false;
                dataListado.Columns[1].Visible = false;
            }
        }
        //Metodo Mostrar poblando el dataListado
        private void Mostrar()
        {
            dataListado.DataSource = NProveedor.Mostrar();
            OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
            tabControl1.SelectedIndex = 0;
        }
        //Metodo BuscarRazon_Social
        private void BuscarRazon_Social()
        {
            dataListado.DataSource = NProveedor.BuscarRazon_Social(txtBuscar.Text);
            OcultarColumnas();
            lblTotal.Text= "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        //Metodo BuscarNum_Documento
        private void BuscarNum_Documento()
        {
            dataListado.DataSource = NProveedor.BuscarNum_Documento(txtBuscar.Text);
            OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void FrmProveedor_Load(object sender, EventArgs e)
        {
            Mostrar();
            Habilitar(false);
            Botones();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(cboBuscar.Text.Equals("Razón Social"))
            {
                BuscarRazon_Social();
            }
            else if(cboBuscar.Text.Equals("Documento Numero"))
            {
                BuscarNum_Documento();
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("¿Esta seguro que desea elimnar los registros?",
                    "Pedidos App", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if(Opcion == DialogResult.OK)
                {
                    int Codigo;
                    string Rpta = "";
                    foreach(DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToInt32(row.Cells[1].Value);
                            Rpta = NProveedor.Eliminar(Codigo);

                            if (Rpta.Equals("OK"))
                            {
                                MensajeOk("Se elimino correctamente el registro");
                            }
                            else
                            {
                                MensajeError(Rpta);
                            }
                        }
                    }
                    Mostrar();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                dataListado.Columns[0].Visible=true;
            }
            else
            {
                dataListado.Columns[0].Visible = false;
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            IsNuevo = true;
            IsEditar = false;
            Botones();
            Limpiar();
            Habilitar(true);
            txtRazon_Social.Focus();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                if(txtRazon_Social.Text == string.Empty || txtNum_Documento.Text == string.Empty 
                    || txtDireccion.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, seran remarcados");
                    errorIcono.SetError(txtRazon_Social, "Ingrese el nombre del proveedor");
                    errorIcono.SetError(txtNum_Documento, "Ingrese el numero de documento");
                    errorIcono.SetError(txtDireccion, "Ingrese la direccion del proveedor");
                }
                else
                {
                    if (IsNuevo)
                    {
                        Rpta = NProveedor.Insertar(txtRazon_Social.Text.Trim().ToUpper(),
                            cbSector_Comercial.Text, cbTipo_Documento.Text, txtNum_Documento.Text.Trim(),
                            txtDireccion.Text, txtTelefono.Text, txtEmail.Text, txtUrl.Text.Trim());
                    }
                    else
                    {
                        Rpta = NProveedor.Editar(Convert.ToInt32(txtIdproveedor.Text),
                            txtRazon_Social.Text.Trim().ToUpper(), cbSector_Comercial.Text, 
                            cbTipo_Documento.Text, txtNum_Documento.Text.Trim(), txtDireccion.Text, 
                            txtTelefono.Text, txtEmail.Text, txtUrl.Text.Trim());
                    }
                    if (Rpta.Equals("OK"))
                    {
                        if (IsNuevo)
                        {
                            MensajeOk("Se inserto de forma correcta el registro");
                        }
                        else
                        {
                            MensajeOk("Se actualizo de forma correcta el registro");
                        }
                    }
                    else
                    {
                        MensajeError(Rpta);
                    }
                    IsNuevo = false;
                    IsEditar = false;
                    Botones();
                    Limpiar();
                    Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!txtIdproveedor.Text.Equals(""))
            {
                IsEditar = true;
                Botones();
                Habilitar(true);
            }
            else
            {
                MensajeError("Debe seleccionar de la grilla el registro para modificar");
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            IsNuevo = false;
            IsEditar = false;
            Botones();
            Limpiar();
            txtIdproveedor.Text = string.Empty;
        }
        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }
        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            txtIdproveedor.Text = Convert.ToString(dataListado.CurrentRow.Cells["idproveedor"].Value);
            txtRazon_Social.Text = Convert.ToString(dataListado.CurrentRow.Cells["razon_social"].Value);
            cbSector_Comercial.Text = Convert.ToString(dataListado.CurrentRow.Cells["sector_comercial"].Value);
            cbTipo_Documento.Text = Convert.ToString(dataListado.CurrentRow.Cells["tipo_documento"].Value);
            txtNum_Documento.Text = Convert.ToString(dataListado.CurrentRow.Cells["num_documento"].Value);
            txtDireccion.Text = Convert.ToString(dataListado.CurrentRow.Cells["direccion"].Value);
            txtTelefono.Text = Convert.ToString(dataListado.CurrentRow.Cells["telefono"].Value);
            txtEmail.Text = Convert.ToString(dataListado.CurrentRow.Cells["email"].Value);
            txtUrl.Text = Convert.ToString(dataListado.CurrentRow.Cells["url"].Value);
            tabControl1.SelectedIndex = 1;
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (cboBuscar.Text.Equals("Razón Social"))
            {
                BuscarRazon_Social();
            }
            else if (cboBuscar.Text.Equals("Documento Numero"))
            {
                BuscarNum_Documento();
            }
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //Reportes.FrmReporteProveedor frm = new Reportes.FrmReporteProveedor();
            //frm.Text = txtBuscar.Text;
            //frm.ShowDialog();
        }       
    }
}
