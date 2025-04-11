using CONTPAQiPatinesMX.Core;
using CONTPAQiPatinesMX.Core.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CONTPAQiPatinesMX.UI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Core.Core.Instance.TerminarSesion();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasenia = txtContrasenia.Text.Trim();

            if (string.IsNullOrEmpty(usuario))
            {
                MessageBox.Show("Ingrese usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Core.Core.Instance.IniciarSesion(usuario, contrasenia);

            if (Core.Core.Instance.SesionSDKActiva)
            {
                this.DialogResult = DialogResult.OK;
                lstEmpresas.Visible = true;
                ListadoEmpresas();

            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListadoEmpresas()
        {
            List<Empresa> empresas = Core.Core.Instance.ObtenerEmpresas();

            lstEmpresas.View = View.Details;
            lstEmpresas.Items.Clear();
            lstEmpresas.Columns.Add("Nombre", 200); // Ancho de la columna para el Nombre
            lstEmpresas.Columns.Add("Directorio", 300); // Ancho de la columna para el Directorio

            foreach (var empresa in empresas)
            {
                ListViewItem item = new ListViewItem(empresa.Nombre);
                item.SubItems.Add(empresa.Directorio);
                item.Tag = empresa; // Guardamos el objeto completo en el Tag para referencia

                lstEmpresas.Items.Add(item);
            }

            foreach (ColumnHeader column in lstEmpresas.Columns)
            {
                column.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                column.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            }

        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (Core.Core.Instance.SesionSDKActiva && e.KeyCode == Keys.F5)
            {
                // Llamar al método ListadoEmpresas cuando se presiona F5
                ListadoEmpresas();
            }
        }
    }
}
