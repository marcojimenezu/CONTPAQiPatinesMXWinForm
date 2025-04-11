namespace CONTPAQiPatinesMX.UI
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            txtUsuario = new TextBox();
            txtContrasenia = new TextBox();
            btnAceptar = new Button();
            btnCerrar = new Button();
            lstEmpresas = new ListView();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(201, 79);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(201, 112);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 1;
            label2.Text = "label2";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(315, 75);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(100, 23);
            txtUsuario.TabIndex = 2;
            txtUsuario.Text = "SUPERVISOR";
            // 
            // txtContrasenia
            // 
            txtContrasenia.Location = new Point(315, 104);
            txtContrasenia.Name = "txtContrasenia";
            txtContrasenia.Size = new Size(100, 23);
            txtContrasenia.TabIndex = 3;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(201, 164);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 4;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(340, 164);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(75, 23);
            btnCerrar.TabIndex = 5;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // lstEmpresas
            // 
            lstEmpresas.Location = new Point(12, 206);
            lstEmpresas.Name = "lstEmpresas";
            lstEmpresas.Size = new Size(619, 222);
            lstEmpresas.TabIndex = 6;
            lstEmpresas.UseCompatibleStateImageBehavior = false;
            lstEmpresas.Visible = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(643, 467);
            Controls.Add(lstEmpresas);
            Controls.Add(btnCerrar);
            Controls.Add(btnAceptar);
            Controls.Add(txtContrasenia);
            Controls.Add(txtUsuario);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            FormClosed += LoginForm_FormClosed;
            KeyDown += LoginForm_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtUsuario;
        private TextBox txtContrasenia;
        private Button btnAceptar;
        private Button btnCerrar;
        private ListView lstEmpresas;
    }
}