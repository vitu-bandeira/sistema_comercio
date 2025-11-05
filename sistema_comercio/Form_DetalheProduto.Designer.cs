namespace sistema_comercio
{
    partial class Form_DetalheProduto
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
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxPrecoBase = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPorcentagem = new System.Windows.Forms.TextBox();
            this.labelInsiraQuantidade = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_nome_p = new System.Windows.Forms.TextBox();
            this.labelInsiraNome = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_preço_custo = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.labelInsiraCodigo = new System.Windows.Forms.Label();
            this.textBox_codigo_barra = new System.Windows.Forms.TextBox();
            this.textBox_quantidade = new System.Windows.Forms.TextBox();
            this.textBox_preço_venda = new System.Windows.Forms.TextBox();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.White;
            this.panel8.Controls.Add(this.buttonCancelar);
            this.panel8.Controls.Add(this.button1);
            this.panel8.Controls.Add(this.label6);
            this.panel8.Controls.Add(this.textBoxPrecoBase);
            this.panel8.Controls.Add(this.label5);
            this.panel8.Controls.Add(this.textBoxPorcentagem);
            this.panel8.Controls.Add(this.labelInsiraQuantidade);
            this.panel8.Controls.Add(this.label4);
            this.panel8.Controls.Add(this.textBox_nome_p);
            this.panel8.Controls.Add(this.labelInsiraNome);
            this.panel8.Controls.Add(this.label3);
            this.panel8.Controls.Add(this.label2);
            this.panel8.Controls.Add(this.label_preço_custo);
            this.panel8.Controls.Add(this.dateTimePicker1);
            this.panel8.Controls.Add(this.label1);
            this.panel8.Controls.Add(this.labelInsiraCodigo);
            this.panel8.Controls.Add(this.textBox_codigo_barra);
            this.panel8.Controls.Add(this.textBox_quantidade);
            this.panel8.Controls.Add(this.textBox_preço_venda);
            this.panel8.Location = new System.Drawing.Point(1, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(666, 341);
            this.panel8.TabIndex = 102;
            this.panel8.Paint += new System.Windows.Forms.PaintEventHandler(this.panel8_Paint);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.BackColor = System.Drawing.Color.Transparent;
            this.buttonCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelar.ForeColor = System.Drawing.Color.Black;
            this.buttonCancelar.Location = new System.Drawing.Point(285, 271);
            this.buttonCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(173, 51);
            this.buttonCancelar.TabIndex = 99;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LimeGreen;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.button1.FlatAppearance.BorderSize = 10;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(482, 272);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(173, 50);
            this.button1.TabIndex = 98;
            this.button1.Text = "Adicionar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(364, 94);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 28);
            this.label6.TabIndex = 97;
            this.label6.Text = "Preço Final";
            // 
            // textBoxPrecoBase
            // 
            this.textBoxPrecoBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.2F);
            this.textBoxPrecoBase.Location = new System.Drawing.Point(201, 127);
            this.textBoxPrecoBase.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPrecoBase.Multiline = true;
            this.textBoxPrecoBase.Name = "textBoxPrecoBase";
            this.textBoxPrecoBase.Size = new System.Drawing.Size(96, 33);
            this.textBoxPrecoBase.TabIndex = 96;
            this.textBoxPrecoBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(317, 94);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 28);
            this.label5.TabIndex = 95;
            this.label5.Text = "%";
            // 
            // textBoxPorcentagem
            // 
            this.textBoxPorcentagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.2F);
            this.textBoxPorcentagem.Location = new System.Drawing.Point(305, 127);
            this.textBoxPorcentagem.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPorcentagem.Multiline = true;
            this.textBoxPorcentagem.Name = "textBoxPorcentagem";
            this.textBoxPorcentagem.Size = new System.Drawing.Size(49, 33);
            this.textBoxPorcentagem.TabIndex = 94;
            this.textBoxPorcentagem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelInsiraQuantidade
            // 
            this.labelInsiraQuantidade.AutoSize = true;
            this.labelInsiraQuantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInsiraQuantidade.ForeColor = System.Drawing.Color.Red;
            this.labelInsiraQuantidade.Location = new System.Drawing.Point(24, 164);
            this.labelInsiraQuantidade.Name = "labelInsiraQuantidade";
            this.labelInsiraQuantidade.Size = new System.Drawing.Size(154, 20);
            this.labelInsiraQuantidade.TabIndex = 93;
            this.labelInsiraQuantidade.Text = "Insira a Quantidade";
            this.labelInsiraQuantidade.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 184);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 28);
            this.label4.TabIndex = 81;
            this.label4.Text = "Data de Validade";
            // 
            // textBox_nome_p
            // 
            this.textBox_nome_p.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.2F);
            this.textBox_nome_p.Location = new System.Drawing.Point(341, 41);
            this.textBox_nome_p.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_nome_p.Multiline = true;
            this.textBox_nome_p.Name = "textBox_nome_p";
            this.textBox_nome_p.Size = new System.Drawing.Size(296, 33);
            this.textBox_nome_p.TabIndex = 2;
            // 
            // labelInsiraNome
            // 
            this.labelInsiraNome.AutoSize = true;
            this.labelInsiraNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInsiraNome.ForeColor = System.Drawing.Color.Red;
            this.labelInsiraNome.Location = new System.Drawing.Point(350, 78);
            this.labelInsiraNome.Name = "labelInsiraNome";
            this.labelInsiraNome.Size = new System.Drawing.Size(127, 20);
            this.labelInsiraNome.TabIndex = 92;
            this.labelInsiraNome.Text = "Insira um Nome";
            this.labelInsiraNome.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(336, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 28);
            this.label3.TabIndex = 76;
            this.label3.Text = "Nome do Produto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 94);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 28);
            this.label2.TabIndex = 73;
            this.label2.Text = "Quantidade ";
            // 
            // label_preço_custo
            // 
            this.label_preço_custo.AutoSize = true;
            this.label_preço_custo.BackColor = System.Drawing.Color.White;
            this.label_preço_custo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_preço_custo.Location = new System.Drawing.Point(218, 94);
            this.label_preço_custo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_preço_custo.Name = "label_preço_custo";
            this.label_preço_custo.Size = new System.Drawing.Size(65, 28);
            this.label_preço_custo.TabIndex = 79;
            this.label_preço_custo.Text = "Preço";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(28, 214);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(207, 37);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 28);
            this.label1.TabIndex = 72;
            this.label1.Text = "Codigo de Barras";
            // 
            // labelInsiraCodigo
            // 
            this.labelInsiraCodigo.AutoSize = true;
            this.labelInsiraCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInsiraCodigo.ForeColor = System.Drawing.Color.Red;
            this.labelInsiraCodigo.Location = new System.Drawing.Point(30, 74);
            this.labelInsiraCodigo.Name = "labelInsiraCodigo";
            this.labelInsiraCodigo.Size = new System.Drawing.Size(197, 20);
            this.labelInsiraCodigo.TabIndex = 91;
            this.labelInsiraCodigo.Text = "Insira o Codigo de barras";
            this.labelInsiraCodigo.Visible = false;
            // 
            // textBox_codigo_barra
            // 
            this.textBox_codigo_barra.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_codigo_barra.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.2F);
            this.textBox_codigo_barra.Location = new System.Drawing.Point(28, 41);
            this.textBox_codigo_barra.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_codigo_barra.Multiline = true;
            this.textBox_codigo_barra.Name = "textBox_codigo_barra";
            this.textBox_codigo_barra.Size = new System.Drawing.Size(289, 33);
            this.textBox_codigo_barra.TabIndex = 1;
            // 
            // textBox_quantidade
            // 
            this.textBox_quantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.2F);
            this.textBox_quantidade.Location = new System.Drawing.Point(35, 127);
            this.textBox_quantidade.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_quantidade.Multiline = true;
            this.textBox_quantidade.Name = "textBox_quantidade";
            this.textBox_quantidade.Size = new System.Drawing.Size(111, 33);
            this.textBox_quantidade.TabIndex = 3;
            this.textBox_quantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_quantidade.WordWrap = false;
            // 
            // textBox_preço_venda
            // 
            this.textBox_preço_venda.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.2F);
            this.textBox_preço_venda.Location = new System.Drawing.Point(370, 127);
            this.textBox_preço_venda.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_preço_venda.Multiline = true;
            this.textBox_preço_venda.Name = "textBox_preço_venda";
            this.textBox_preço_venda.Size = new System.Drawing.Size(107, 33);
            this.textBox_preço_venda.TabIndex = 4;
            this.textBox_preço_venda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form_DetalheProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 338);
            this.Controls.Add(this.panel8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_DetalheProduto";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_DetalheProduto";
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label labelInsiraQuantidade;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_nome_p;
        private System.Windows.Forms.Label labelInsiraNome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_preço_custo;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelInsiraCodigo;
        private System.Windows.Forms.TextBox textBox_codigo_barra;
        private System.Windows.Forms.TextBox textBox_quantidade;
        private System.Windows.Forms.TextBox textBox_preço_venda;
        private System.Windows.Forms.TextBox textBoxPorcentagem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxPrecoBase;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonCancelar;
    }
}