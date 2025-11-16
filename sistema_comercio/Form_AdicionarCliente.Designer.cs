namespace sistema_comercio
{
    partial class Form_AdicionarCliente
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
            this.panel8 = new System.Windows.Forms.Panel();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.btn_adicionar = new System.Windows.Forms.Button();
            this.labelInserirValor = new System.Windows.Forms.Label();
            this.labelInserirTelefone = new System.Windows.Forms.Label();
            this.labelInsiraNome = new System.Windows.Forms.Label();
            this.textBoxSaldo = new System.Windows.Forms.TextBox();
            this.labelSaldo = new System.Windows.Forms.Label();
            this.textBoxTelefone = new System.Windows.Forms.TextBox();
            this.labelTelefone = new System.Windows.Forms.Label();
            this.textBoxEndereco = new System.Windows.Forms.TextBox();
            this.labelEndereco = new System.Windows.Forms.Label();
            this.labelCliente = new System.Windows.Forms.Label();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.White;
            this.panel8.Controls.Add(this.buttonCancelar);
            this.panel8.Controls.Add(this.btn_adicionar);
            this.panel8.Controls.Add(this.labelInserirValor);
            this.panel8.Controls.Add(this.labelInserirTelefone);
            this.panel8.Controls.Add(this.labelInsiraNome);
            this.panel8.Controls.Add(this.textBoxSaldo);
            this.panel8.Controls.Add(this.labelSaldo);
            this.panel8.Controls.Add(this.textBoxTelefone);
            this.panel8.Controls.Add(this.labelTelefone);
            this.panel8.Controls.Add(this.textBoxEndereco);
            this.panel8.Controls.Add(this.labelEndereco);
            this.panel8.Controls.Add(this.labelCliente);
            this.panel8.Controls.Add(this.textBoxNome);
            this.panel8.Location = new System.Drawing.Point(1, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(560, 425);
            this.panel8.TabIndex = 97;
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.BackColor = System.Drawing.Color.Transparent;
            this.buttonCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCancelar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelar.ForeColor = System.Drawing.Color.Black;
            this.buttonCancelar.Location = new System.Drawing.Point(157, 328);
            this.buttonCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(173, 51);
            this.buttonCancelar.TabIndex = 95;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = false;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // btn_adicionar
            // 
            this.btn_adicionar.BackColor = System.Drawing.Color.LimeGreen;
            this.btn_adicionar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_adicionar.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btn_adicionar.FlatAppearance.BorderSize = 10;
            this.btn_adicionar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_adicionar.ForeColor = System.Drawing.Color.White;
            this.btn_adicionar.Location = new System.Drawing.Point(361, 328);
            this.btn_adicionar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_adicionar.Name = "btn_adicionar";
            this.btn_adicionar.Size = new System.Drawing.Size(173, 50);
            this.btn_adicionar.TabIndex = 87;
            this.btn_adicionar.Text = "Adicionar";
            this.btn_adicionar.UseVisualStyleBackColor = false;
            this.btn_adicionar.Click += new System.EventHandler(this.btn_adicionar_Click);
            // 
            // labelInserirValor
            // 
            this.labelInserirValor.AutoSize = true;
            this.labelInserirValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInserirValor.ForeColor = System.Drawing.Color.Red;
            this.labelInserirValor.Location = new System.Drawing.Point(14, 195);
            this.labelInserirValor.Name = "labelInserirValor";
            this.labelInserirValor.Size = new System.Drawing.Size(108, 20);
            this.labelInserirValor.TabIndex = 92;
            this.labelInserirValor.Text = "Insira o Valor";
            this.labelInserirValor.Visible = false;
            // 
            // labelInserirTelefone
            // 
            this.labelInserirTelefone.AutoSize = true;
            this.labelInserirTelefone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInserirTelefone.ForeColor = System.Drawing.Color.Red;
            this.labelInserirTelefone.Location = new System.Drawing.Point(230, 195);
            this.labelInserirTelefone.Name = "labelInserirTelefone";
            this.labelInserirTelefone.Size = new System.Drawing.Size(147, 20);
            this.labelInserirTelefone.TabIndex = 91;
            this.labelInserirTelefone.Text = "Insira um Telefone";
            this.labelInserirTelefone.Visible = false;
            // 
            // labelInsiraNome
            // 
            this.labelInsiraNome.AutoSize = true;
            this.labelInsiraNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInsiraNome.ForeColor = System.Drawing.Color.Red;
            this.labelInsiraNome.Location = new System.Drawing.Point(22, 94);
            this.labelInsiraNome.Name = "labelInsiraNome";
            this.labelInsiraNome.Size = new System.Drawing.Size(127, 20);
            this.labelInsiraNome.TabIndex = 90;
            this.labelInsiraNome.Text = "Insira um Nome";
            this.labelInsiraNome.Visible = false;
            // 
            // textBoxSaldo
            // 
            this.textBoxSaldo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.2F);
            this.textBoxSaldo.Location = new System.Drawing.Point(17, 157);
            this.textBoxSaldo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxSaldo.Multiline = true;
            this.textBoxSaldo.Name = "textBoxSaldo";
            this.textBoxSaldo.Size = new System.Drawing.Size(132, 34);
            this.textBoxSaldo.TabIndex = 89;
            // 
            // labelSaldo
            // 
            this.labelSaldo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSaldo.AutoSize = true;
            this.labelSaldo.BackColor = System.Drawing.Color.White;
            this.labelSaldo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.labelSaldo.Location = new System.Drawing.Point(14, 130);
            this.labelSaldo.Name = "labelSaldo";
            this.labelSaldo.Size = new System.Drawing.Size(63, 24);
            this.labelSaldo.TabIndex = 88;
            this.labelSaldo.Text = "Saldo";
            // 
            // textBoxTelefone
            // 
            this.textBoxTelefone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxTelefone.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.2F);
            this.textBoxTelefone.Location = new System.Drawing.Point(234, 157);
            this.textBoxTelefone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxTelefone.Multiline = true;
            this.textBoxTelefone.Name = "textBoxTelefone";
            this.textBoxTelefone.Size = new System.Drawing.Size(301, 34);
            this.textBoxTelefone.TabIndex = 83;
            // 
            // labelTelefone
            // 
            this.labelTelefone.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTelefone.AutoSize = true;
            this.labelTelefone.BackColor = System.Drawing.Color.White;
            this.labelTelefone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelTelefone.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.labelTelefone.Location = new System.Drawing.Point(230, 129);
            this.labelTelefone.Name = "labelTelefone";
            this.labelTelefone.Size = new System.Drawing.Size(93, 24);
            this.labelTelefone.TabIndex = 82;
            this.labelTelefone.Text = "Telefone";
            // 
            // textBoxEndereco
            // 
            this.textBoxEndereco.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxEndereco.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.2F);
            this.textBoxEndereco.Location = new System.Drawing.Point(17, 254);
            this.textBoxEndereco.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxEndereco.Multiline = true;
            this.textBoxEndereco.Name = "textBoxEndereco";
            this.textBoxEndereco.Size = new System.Drawing.Size(518, 34);
            this.textBoxEndereco.TabIndex = 81;
            // 
            // labelEndereco
            // 
            this.labelEndereco.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelEndereco.AutoSize = true;
            this.labelEndereco.BackColor = System.Drawing.Color.White;
            this.labelEndereco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelEndereco.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.labelEndereco.Location = new System.Drawing.Point(14, 226);
            this.labelEndereco.Name = "labelEndereco";
            this.labelEndereco.Size = new System.Drawing.Size(102, 24);
            this.labelEndereco.TabIndex = 80;
            this.labelEndereco.Text = "Endereço";
            // 
            // labelCliente
            // 
            this.labelCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCliente.AutoSize = true;
            this.labelCliente.BackColor = System.Drawing.Color.White;
            this.labelCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.labelCliente.Location = new System.Drawing.Point(14, 29);
            this.labelCliente.Name = "labelCliente";
            this.labelCliente.Size = new System.Drawing.Size(66, 24);
            this.labelCliente.TabIndex = 79;
            this.labelCliente.Text = "Nome";
            // 
            // textBoxNome
            // 
            this.textBoxNome.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.2F);
            this.textBoxNome.Location = new System.Drawing.Point(17, 57);
            this.textBoxNome.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxNome.Multiline = true;
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(518, 34);
            this.textBoxNome.TabIndex = 78;
            // 
            // Form_AdicionarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(557, 423);
            this.Controls.Add(this.panel8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_AdicionarCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_AdicionarCliente";
            this.Load += new System.EventHandler(this.Form_AdicionarCliente_Load);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Label labelInserirValor;
        private System.Windows.Forms.Label labelInserirTelefone;
        private System.Windows.Forms.Label labelInsiraNome;
        private System.Windows.Forms.TextBox textBoxSaldo;
        private System.Windows.Forms.Label labelSaldo;
        private System.Windows.Forms.TextBox textBoxTelefone;
        private System.Windows.Forms.Button btn_adicionar;
        private System.Windows.Forms.Label labelTelefone;
        private System.Windows.Forms.TextBox textBoxEndereco;
        private System.Windows.Forms.Label labelEndereco;
        private System.Windows.Forms.Label labelCliente;
        private System.Windows.Forms.TextBox textBoxNome;
    }
}