using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PedidosApp1.Reportes
{
    public partial class FrmFacturaRollo : Form
    {
        //Variable
        private int _Idventa;
        //Propiedad
        public int Idventa { get => _Idventa; set => _Idventa = value; }
        public FrmFacturaRollo()
        {
            InitializeComponent();
        }

        private void FrmFacturaRollo_Load(object sender, EventArgs e)
        {
            //TODO: esta linea de codigo carga datos en la tabla 'dsPrincipal.spreporte_factura'
            //puede moverla
            try
            {
                this.spreporte_facturaTableAdapter.Fill(this.dsPrincipal.spreporte_factura, Idventa);
                this.reportViewer1.RefreshReport();
            }
            catch (Exception)
            {
                this.reportViewer1.RefreshReport();
            }
            this.reportViewer1.RefreshReport();
        }
    }
}
