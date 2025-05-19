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
    public partial class FrmReporteCompras : Form
    {
        public FrmReporteCompras()
        {
            InitializeComponent();
        }

        private void FrmReporteCompras_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
