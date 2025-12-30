namespace sistema_comercio
{
    partial class Form_AjustarSaldo
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
            this.panelBorda = new System.Windows.Forms.Panel();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.txtValorAjuste = new System.Windows.Forms.TextBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panelBorda.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBorda
            // 
            this.panelBorda.BackColor = System.Drawing.Color.White;
            this.panelBorda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBorda.Controls.Add(this.labelTitulo);
            this.panelBorda.Controls.Add(this.txtValorAjuste);
            this.panelBorda.Controls.Add(this.btnConfirmar);
            this.panelBorda.Controls.Add(this.btnCancelar);
            this.panelBorda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBorda.Location = new System.Drawing.Point(0, 0);
            this.panelBorda.Name = "panelBorda";
            this.panelBorda.Size = new System.Drawing.Size(400, 280);
            this.panelBorda.TabIndex = 0;
            // 
            // labelTitulo
            // 
            this.labelTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.labelTitulo.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.labelTitulo.Location = new System.Drawing.Point(0, 0);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.labelTitulo.Size = new System.Drawing.Size(398, 68);
            this.labelTitulo.TabIndex = 0;
            this.labelTitulo.Text = "AJUSTAR SALDO";
            this.labelTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtValorAjuste
            // 
            this.txtValorAjuste.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtValorAjuste.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtValorAjuste.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.txtValorAjuste.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtValorAjuste.Location = new System.Drawing.Point(39, 90);
            this.txtValorAjuste.Margin = new System.Windows.Forms.Padding(10);
            this.txtValorAjuste.Name = "txtValorAjuste";
            this.txtValorAjuste.Size = new System.Drawing.Size(320, 63);
            this.txtValorAjuste.TabIndex = 1;
            this.txtValorAjuste.Text = "0,00";
            this.txtValorAjuste.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.LimeGreen;
            this.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmar.FlatAppearance.BorderSize = 0;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Location = new System.Drawing.Point(39, 180);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(320, 50);
            this.btnConfirmar.TabIndex = 2;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Transparent;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.Gray;
            this.btnCancelar.Location = new System.Drawing.Point(39, 236);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(320, 35);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar (ESC)";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // Form_AjustarSaldo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(400, 280);
            this.Controls.Add(this.panelBorda);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_AjustarSaldo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form_AjustarSaldo";
            this.panelBorda.ResumeLayout(false);
            this.panelBorda.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBorda;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.TextBox txtValorAjuste;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;
    }
}