using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CONTPAQiPatinesMX.Core;

namespace CONTPAQiPatinesMX.UI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasenia = txtContrasenia.Text.Trim();

            if (string.IsNullOrEmpty(usuario))
            {
                MessageBox.Show("Ingrese usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool autenticado = Core.Core.Instance.IniciarSesion(usuario, contrasenia);

            if (autenticado)
            {
                this.DialogResult = DialogResult.OK;
                Core.Core.Instance.TerminarSesion();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Core.Core.Instance.TerminarSesion();
        }
    }
}
