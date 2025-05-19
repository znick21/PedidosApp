using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace PedidosApp1
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            LblHora.Text = DateTime.Now.ToString();
        }
        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            LblHora.Text = DateTime.Now.ToString();
        }
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            DataTable Datos = NTrabajador.Login(this.TxtUsuario.Text, this.TxtPassword.Text);
            //Evaluar si existe el Usuario
            try
            {
                if (Datos.Rows.Count == 0)
                {
                    MessageBox.Show("NO Tiene Acceso al Sistema", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    FrmPrincipal frm = new FrmPrincipal();
                    frm.Idtrabajador = Datos.Rows[0][0].ToString();
                    frm.Apellidos = Datos.Rows[0][1].ToString();
                    frm.Nombre = Datos.Rows[0][2].ToString();
                    frm.Acceso = Datos.Rows[0][3].ToString();

                    frm.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
