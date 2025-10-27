namespace sistema_comercio
{
    partial class Form_venda
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalVenda = new System.Windows.Forms.Label();
            this.sidebar_timer = new System.Windows.Forms.Timer(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.comboBoxCliente = new System.Windows.Forms.ComboBox();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.sidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.button_menu = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonHome = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonEstoque = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.buttonVenda = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.buttonCliente = new System.Windows.Forms.Button();
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelMain.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel6.SuspendLayout();
            this.sidebar.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.button_menu)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(317, 126);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 31);
            this.label1.TabIndex = 10;
            this.label1.Text = "Buscar Produto";
            // 
            // lblTotalVenda
            // 
            this.lblTotalVenda.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalVenda.Location = new System.Drawing.Point(13, 429);
            this.lblTotalVenda.Name = "lblTotalVenda";
            this.lblTotalVenda.Size = new System.Drawing.Size(270, 39);
            this.lblTotalVenda.TabIndex = 0;
            this.lblTotalVenda.Text = "Total: R$ 0,00";
            // 
            // sidebar_timer
            // 
            this.sidebar_timer.Interval = 10;
            this.sidebar_timer.Tick += new System.EventHandler(this.sidebar_timer_Tick);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.MediumSlateBlue;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CausesValidation = false;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.MediumSlateBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(1);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.Location = new System.Drawing.Point(500, 183);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1048, 549);
            this.dataGridView1.TabIndex = 77;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelMain.Controls.Add(this.panel8);
            this.panelMain.Controls.Add(this.panel6);
            this.panelMain.Controls.Add(this.sidebar);
            this.panelMain.Controls.Add(this.txtBusca);
            this.panelMain.Controls.Add(this.dataGridView1);
            this.panelMain.Controls.Add(this.label1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1548, 844);
            this.panelMain.TabIndex = 95;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.White;
            this.panel8.Controls.Add(this.label2);
            this.panel8.Controls.Add(this.comboBoxCliente);
            this.panel8.Controls.Add(this.lblTotalVenda);
            this.panel8.Controls.Add(this.btnAdicionar);
            this.panel8.Location = new System.Drawing.Point(136, 182);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(305, 538);
            this.panel8.TabIndex = 99;
            // 
            // comboBoxCliente
            // 
            this.comboBoxCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxCliente.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCliente.FormattingEnabled = true;
            this.comboBoxCliente.Items.AddRange(new object[] {
            "cafe",
            "manteiga",
            "culher",
            "afua"});
            this.comboBoxCliente.Location = new System.Drawing.Point(19, 62);
            this.comboBoxCliente.Name = "comboBoxCliente";
            this.comboBoxCliente.Size = new System.Drawing.Size(254, 39);
            this.comboBoxCliente.TabIndex = 99;
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.BackColor = System.Drawing.Color.SlateBlue;
            this.btnAdicionar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionar.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionar.ForeColor = System.Drawing.Color.White;
            this.btnAdicionar.Location = new System.Drawing.Point(13, 468);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(270, 50);
            this.btnAdicionar.TabIndex = 98;
            this.btnAdicionar.Text = "FInalizar Venda";
            this.btnAdicionar.UseVisualStyleBackColor = false;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.panel6.Controls.Add(this.label3);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1548, 79);
            this.panel6.TabIndex = 97;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 18.8F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(775, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 45);
            this.label3.TabIndex = 79;
            this.label3.Text = "CAIXA";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.Color.SlateBlue;
            this.sidebar.Controls.Add(this.panel1);
            this.sidebar.Controls.Add(this.panel2);
            this.sidebar.Controls.Add(this.panel3);
            this.sidebar.Controls.Add(this.panel4);
            this.sidebar.Controls.Add(this.panel5);
            this.sidebar.Location = new System.Drawing.Point(0, 0);
            this.sidebar.MaximumSize = new System.Drawing.Size(240, 801);
            this.sidebar.MinimumSize = new System.Drawing.Size(83, 801);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(83, 801);
            this.sidebar.TabIndex = 95;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.button_menu);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(273, 159);
            this.panel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(85, 101);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 28);
            this.label5.TabIndex = 36;
            this.label5.Text = "Menu";
            // 
            // button_menu
            // 
            this.button_menu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_menu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_menu.Image = global::sistema_comercio.Properties.Resources.icons8_menu_50;
            this.button_menu.Location = new System.Drawing.Point(9, 89);
            this.button_menu.Name = "button_menu";
            this.button_menu.Size = new System.Drawing.Size(52, 52);
            this.button_menu.TabIndex = 0;
            this.button_menu.TabStop = false;
            this.button_menu.Click += new System.EventHandler(this.button_menu_Click_1);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonHome);
            this.panel2.Location = new System.Drawing.Point(3, 168);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(273, 73);
            this.panel2.TabIndex = 1;
            // 
            // buttonHome
            // 
            this.buttonHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHome.ForeColor = System.Drawing.Color.White;
            this.buttonHome.Image = global::sistema_comercio.Properties.Resources.icons8_home_50__1_;
            this.buttonHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonHome.Location = new System.Drawing.Point(-6, -8);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonHome.Size = new System.Drawing.Size(283, 90);
            this.buttonHome.TabIndex = 35;
            this.buttonHome.Text = "                 Inicio";
            this.buttonHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonHome.UseVisualStyleBackColor = true;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click_1);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.buttonEstoque);
            this.panel3.Location = new System.Drawing.Point(3, 247);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(273, 73);
            this.panel3.TabIndex = 2;
            // 
            // buttonEstoque
            // 
            this.buttonEstoque.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEstoque.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEstoque.ForeColor = System.Drawing.Color.White;
            this.buttonEstoque.Image = global::sistema_comercio.Properties.Resources.icons8_products_50;
            this.buttonEstoque.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEstoque.Location = new System.Drawing.Point(-6, -8);
            this.buttonEstoque.Name = "buttonEstoque";
            this.buttonEstoque.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonEstoque.Size = new System.Drawing.Size(283, 90);
            this.buttonEstoque.TabIndex = 35;
            this.buttonEstoque.Text = "                 Produtos";
            this.buttonEstoque.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEstoque.UseVisualStyleBackColor = true;
            this.buttonEstoque.Click += new System.EventHandler(this.buttonEstoque_Click_1);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Controls.Add(this.buttonVenda);
            this.panel4.Location = new System.Drawing.Point(3, 326);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(273, 73);
            this.panel4.TabIndex = 3;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.GhostWhite;
            this.panel7.Location = new System.Drawing.Point(-4, -3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(10, 90);
            this.panel7.TabIndex = 79;
            // 
            // buttonVenda
            // 
            this.buttonVenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVenda.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonVenda.ForeColor = System.Drawing.Color.White;
            this.buttonVenda.Image = global::sistema_comercio.Properties.Resources.icons8_products_64;
            this.buttonVenda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonVenda.Location = new System.Drawing.Point(-8, -8);
            this.buttonVenda.Name = "buttonVenda";
            this.buttonVenda.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonVenda.Size = new System.Drawing.Size(283, 90);
            this.buttonVenda.TabIndex = 35;
            this.buttonVenda.Text = "                 Caixa";
            this.buttonVenda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonVenda.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.buttonCliente);
            this.panel5.Location = new System.Drawing.Point(3, 405);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(273, 73);
            this.panel5.TabIndex = 4;
            // 
            // buttonCliente
            // 
            this.buttonCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCliente.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCliente.ForeColor = System.Drawing.Color.White;
            this.buttonCliente.Image = global::sistema_comercio.Properties.Resources.icons8_user_50;
            this.buttonCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCliente.Location = new System.Drawing.Point(-6, -8);
            this.buttonCliente.Name = "buttonCliente";
            this.buttonCliente.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonCliente.Size = new System.Drawing.Size(283, 90);
            this.buttonCliente.TabIndex = 35;
            this.buttonCliente.Text = "                 Clientes";
            this.buttonCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCliente.UseVisualStyleBackColor = true;
            this.buttonCliente.Click += new System.EventHandler(this.buttonCliente_Click_1);
            // 
            // txtBusca
            // 
            this.txtBusca.BackColor = System.Drawing.Color.White;
            this.txtBusca.Font = new System.Drawing.Font("Segoe UI", 14.2F);
            this.txtBusca.Location = new System.Drawing.Point(496, 121);
            this.txtBusca.Margin = new System.Windows.Forms.Padding(4);
            this.txtBusca.Multiline = true;
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(749, 41);
            this.txtBusca.TabIndex = 97;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Window;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 31);
            this.label2.TabIndex = 100;
            this.label2.Text = "Buscar Cliente";
            // 
            // Form_venda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1548, 844);
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form_venda";
            this.Text = "Form2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_venda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.sidebar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.button_menu)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalVenda;
        private System.Windows.Forms.Timer sidebar_timer;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBusca;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.FlowLayoutPanel sidebar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox button_menu;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonEstoque;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button buttonVenda;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button buttonCliente;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.ComboBox comboBoxCliente;
        private System.Windows.Forms.Label label2;
    }
}