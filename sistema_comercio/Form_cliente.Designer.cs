namespace sistema_comercio
{
    partial class FormCliente
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_adicionar = new System.Windows.Forms.Button();
            this.sidebar_timer = new System.Windows.Forms.Timer(this.components);
            this.panelMain = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.buttonAtualizar = new System.Windows.Forms.Button();
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
            this.Buscar = new System.Windows.Forms.Label();
            this.textBoxBuscar = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.buttonCliente = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonVenda = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonEstoque = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonHome = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.button_menu = new System.Windows.Forms.PictureBox();
            this.sidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.panelMain.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.button_menu)).BeginInit();
            this.sidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_adicionar
            // 
            this.btn_adicionar.BackColor = System.Drawing.Color.SlateBlue;
            this.btn_adicionar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_adicionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_adicionar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_adicionar.ForeColor = System.Drawing.Color.White;
            this.btn_adicionar.Location = new System.Drawing.Point(18, 353);
            this.btn_adicionar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_adicionar.Name = "btn_adicionar";
            this.btn_adicionar.Size = new System.Drawing.Size(243, 50);
            this.btn_adicionar.TabIndex = 87;
            this.btn_adicionar.Text = "Adicionar";
            this.btn_adicionar.UseVisualStyleBackColor = false;
            this.btn_adicionar.Click += new System.EventHandler(this.btn_adicionar_Click);
            // 
            // sidebar_timer
            // 
            this.sidebar_timer.Interval = 10;
            this.sidebar_timer.Tick += new System.EventHandler(this.sidebar_timer_Tick_1);
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelMain.Controls.Add(this.panel8);
            this.panelMain.Controls.Add(this.Buscar);
            this.panelMain.Controls.Add(this.textBoxBuscar);
            this.panelMain.Controls.Add(this.dataGridView1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1548, 844);
            this.panelMain.TabIndex = 95;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.White;
            this.panel8.Controls.Add(this.buttonAtualizar);
            this.panel8.Controls.Add(this.labelInserirValor);
            this.panel8.Controls.Add(this.labelInserirTelefone);
            this.panel8.Controls.Add(this.labelInsiraNome);
            this.panel8.Controls.Add(this.textBoxSaldo);
            this.panel8.Controls.Add(this.labelSaldo);
            this.panel8.Controls.Add(this.textBoxTelefone);
            this.panel8.Controls.Add(this.btn_adicionar);
            this.panel8.Controls.Add(this.labelTelefone);
            this.panel8.Controls.Add(this.textBoxEndereco);
            this.panel8.Controls.Add(this.labelEndereco);
            this.panel8.Controls.Add(this.labelCliente);
            this.panel8.Controls.Add(this.textBoxNome);
            this.panel8.Location = new System.Drawing.Point(124, 162);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(288, 501);
            this.panel8.TabIndex = 96;
            // 
            // buttonAtualizar
            // 
            this.buttonAtualizar.BackColor = System.Drawing.Color.DarkGreen;
            this.buttonAtualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAtualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAtualizar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAtualizar.ForeColor = System.Drawing.Color.White;
            this.buttonAtualizar.Location = new System.Drawing.Point(19, 411);
            this.buttonAtualizar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonAtualizar.Name = "buttonAtualizar";
            this.buttonAtualizar.Size = new System.Drawing.Size(242, 48);
            this.buttonAtualizar.TabIndex = 95;
            this.buttonAtualizar.Text = "Atualizar";
            this.buttonAtualizar.UseVisualStyleBackColor = false;
            this.buttonAtualizar.Click += new System.EventHandler(this.buttonAtualizar_Click);
            // 
            // labelInserirValor
            // 
            this.labelInserirValor.AutoSize = true;
            this.labelInserirValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInserirValor.ForeColor = System.Drawing.Color.Red;
            this.labelInserirValor.Location = new System.Drawing.Point(24, 324);
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
            this.labelInserirTelefone.Location = new System.Drawing.Point(24, 158);
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
            this.labelInsiraNome.Location = new System.Drawing.Point(23, 72);
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
            this.textBoxSaldo.Location = new System.Drawing.Point(18, 287);
            this.textBoxSaldo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxSaldo.Multiline = true;
            this.textBoxSaldo.Name = "textBoxSaldo";
            this.textBoxSaldo.Size = new System.Drawing.Size(243, 34);
            this.textBoxSaldo.TabIndex = 89;
            this.textBoxSaldo.TextChanged += new System.EventHandler(this.textBoxSaldo_TextChanged);
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
            this.labelSaldo.Location = new System.Drawing.Point(15, 256);
            this.labelSaldo.Name = "labelSaldo";
            this.labelSaldo.Size = new System.Drawing.Size(63, 24);
            this.labelSaldo.TabIndex = 88;
            this.labelSaldo.Text = "Saldo";
            // 
            // textBoxTelefone
            // 
            this.textBoxTelefone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxTelefone.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.2F);
            this.textBoxTelefone.Location = new System.Drawing.Point(18, 121);
            this.textBoxTelefone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxTelefone.Multiline = true;
            this.textBoxTelefone.Name = "textBoxTelefone";
            this.textBoxTelefone.Size = new System.Drawing.Size(243, 34);
            this.textBoxTelefone.TabIndex = 83;
            this.textBoxTelefone.TextChanged += new System.EventHandler(this.textBoxTelefone_TextChanged);
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
            this.labelTelefone.Location = new System.Drawing.Point(15, 96);
            this.labelTelefone.Name = "labelTelefone";
            this.labelTelefone.Size = new System.Drawing.Size(93, 24);
            this.labelTelefone.TabIndex = 82;
            this.labelTelefone.Text = "Telefone";
            // 
            // textBoxEndereco
            // 
            this.textBoxEndereco.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxEndereco.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.2F);
            this.textBoxEndereco.Location = new System.Drawing.Point(18, 211);
            this.textBoxEndereco.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxEndereco.Multiline = true;
            this.textBoxEndereco.Name = "textBoxEndereco";
            this.textBoxEndereco.Size = new System.Drawing.Size(243, 34);
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
            this.labelEndereco.Location = new System.Drawing.Point(15, 184);
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
            this.labelCliente.Location = new System.Drawing.Point(15, 7);
            this.labelCliente.Name = "labelCliente";
            this.labelCliente.Size = new System.Drawing.Size(66, 24);
            this.labelCliente.TabIndex = 79;
            this.labelCliente.Text = "Nome";
            // 
            // textBoxNome
            // 
            this.textBoxNome.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.2F);
            this.textBoxNome.Location = new System.Drawing.Point(18, 35);
            this.textBoxNome.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxNome.Multiline = true;
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(243, 34);
            this.textBoxNome.TabIndex = 78;
            // 
            // Buscar
            // 
            this.Buscar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Buscar.AutoSize = true;
            this.Buscar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.Buscar.Location = new System.Drawing.Point(446, 136);
            this.Buscar.Name = "Buscar";
            this.Buscar.Size = new System.Drawing.Size(67, 24);
            this.Buscar.TabIndex = 94;
            this.Buscar.Text = "Busca";
            // 
            // textBoxBuscar
            // 
            this.textBoxBuscar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.2F);
            this.textBoxBuscar.Location = new System.Drawing.Point(522, 128);
            this.textBoxBuscar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxBuscar.Multiline = true;
            this.textBoxBuscar.Name = "textBoxBuscar";
            this.textBoxBuscar.Size = new System.Drawing.Size(532, 34);
            this.textBoxBuscar.TabIndex = 93;
            this.textBoxBuscar.TextChanged += new System.EventHandler(this.textBoxBuscar_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MediumSlateBlue;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CausesValidation = false;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.MediumSlateBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(1);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.Location = new System.Drawing.Point(451, 176);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.DarkViolet;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1048, 549);
            this.dataGridView1.TabIndex = 77;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.panel6.Controls.Add(this.label3);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1548, 79);
            this.panel6.TabIndex = 96;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 18.8F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(775, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 45);
            this.label3.TabIndex = 79;
            this.label3.Text = "CLIENTES";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.buttonCliente);
            this.panel5.Location = new System.Drawing.Point(3, 326);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(273, 73);
            this.panel5.TabIndex = 4;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.GhostWhite;
            this.panel7.Location = new System.Drawing.Point(-1, -9);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(10, 90);
            this.panel7.TabIndex = 80;
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
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.buttonVenda);
            this.panel4.Location = new System.Drawing.Point(3, 247);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(273, 73);
            this.panel4.TabIndex = 3;
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
            this.buttonVenda.Click += new System.EventHandler(this.buttonVenda_Click_1);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.buttonEstoque);
            this.panel3.Location = new System.Drawing.Point(3, 168);
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
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonHome);
            this.panel2.Location = new System.Drawing.Point(3, 89);
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
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.button_menu);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(273, 80);
            this.panel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(78, 25);
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
            this.button_menu.Location = new System.Drawing.Point(10, 12);
            this.button_menu.Name = "button_menu";
            this.button_menu.Size = new System.Drawing.Size(52, 52);
            this.button_menu.TabIndex = 0;
            this.button_menu.TabStop = false;
            this.button_menu.Click += new System.EventHandler(this.button_menu_Click_1);
            // 
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.Color.SlateBlue;
            this.sidebar.Controls.Add(this.panel1);
            this.sidebar.Controls.Add(this.panel2);
            this.sidebar.Controls.Add(this.panel3);
            this.sidebar.Controls.Add(this.panel4);
            this.sidebar.Controls.Add(this.panel5);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.Location = new System.Drawing.Point(0, 79);
            this.sidebar.MaximumSize = new System.Drawing.Size(240, 801);
            this.sidebar.MinimumSize = new System.Drawing.Size(83, 801);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(83, 801);
            this.sidebar.TabIndex = 97;
            // 
            // FormCliente
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1548, 844);
            this.Controls.Add(this.sidebar);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panelMain);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_cliente";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_cliente_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.button_menu)).EndInit();
            this.sidebar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_adicionar;
        private System.Windows.Forms.Timer sidebar_timer;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.Label labelCliente;
        private System.Windows.Forms.TextBox textBoxEndereco;
        private System.Windows.Forms.Label labelEndereco;
        private System.Windows.Forms.TextBox textBoxTelefone;
        private System.Windows.Forms.Label labelTelefone;
        private System.Windows.Forms.TextBox textBoxSaldo;
        private System.Windows.Forms.Label labelSaldo;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelInsiraNome;
        private System.Windows.Forms.Label labelInserirValor;
        private System.Windows.Forms.Label labelInserirTelefone;
        private System.Windows.Forms.TextBox textBoxBuscar;
        private System.Windows.Forms.Label Buscar;
        private System.Windows.Forms.Button buttonAtualizar;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button buttonCliente;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button buttonVenda;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonEstoque;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox button_menu;
        private System.Windows.Forms.FlowLayoutPanel sidebar;
        private System.Windows.Forms.Panel panel8;
    }
}