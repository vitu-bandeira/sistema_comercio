namespace sistema_comercio
{
    partial class FormProduto
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
            this.sidebar_timer = new System.Windows.Forms.Timer(this.components);
            this.sidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonHome = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.buttonEstoque = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonVenda = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.buttonCliente = new System.Windows.Forms.Button();
            this.panel13 = new System.Windows.Forms.Panel();
            this.buttonHistorico = new System.Windows.Forms.Button();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.button_menu = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.Buscar = new System.Windows.Forms.Label();
            this.textBoxBuscar = new System.Windows.Forms.TextBox();
            this.btn_adicionar = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panelVendasHoje = new System.Windows.Forms.Panel();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelFaturamentoMes = new System.Windows.Forms.Panel();
            this.lblQtdProdutos = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panelEstoqueBaixo = new System.Windows.Forms.Panel();
            this.lblEstoqueBaixo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.sidebar.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.button_menu)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panelVendasHoje.SuspendLayout();
            this.panelFaturamentoMes.SuspendLayout();
            this.panelEstoqueBaixo.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // sidebar_timer
            // 
            this.sidebar_timer.Interval = 10;
            this.sidebar_timer.Tick += new System.EventHandler(this.sidebar_timer_Tick_1);
            // 
            // sidebar
            // 
            this.sidebar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sidebar.BackColor = System.Drawing.Color.SlateBlue;
            this.sidebar.Controls.Add(this.panel2);
            this.sidebar.Controls.Add(this.panel3);
            this.sidebar.Controls.Add(this.panel4);
            this.sidebar.Controls.Add(this.panel5);
            this.sidebar.Controls.Add(this.panel13);
            this.sidebar.Controls.Add(this.panel8);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.Location = new System.Drawing.Point(0, 61);
            this.sidebar.MaximumSize = new System.Drawing.Size(185, 0);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(0, 740);
            this.sidebar.TabIndex = 101;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonHome);
            this.panel2.Location = new System.Drawing.Point(3, 3);
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
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.buttonEstoque);
            this.panel3.Location = new System.Drawing.Point(3, 82);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(273, 73);
            this.panel3.TabIndex = 2;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.GhostWhite;
            this.panel7.Location = new System.Drawing.Point(0, -9);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(10, 90);
            this.panel7.TabIndex = 81;
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
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.buttonVenda);
            this.panel4.Location = new System.Drawing.Point(3, 161);
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
            // panel5
            // 
            this.panel5.Controls.Add(this.buttonCliente);
            this.panel5.Location = new System.Drawing.Point(3, 240);
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
            // panel13
            // 
            this.panel13.Controls.Add(this.buttonHistorico);
            this.panel13.Controls.Add(this.panel14);
            this.panel13.Location = new System.Drawing.Point(3, 319);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(273, 73);
            this.panel13.TabIndex = 6;
            // 
            // buttonHistorico
            // 
            this.buttonHistorico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHistorico.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHistorico.ForeColor = System.Drawing.Color.White;
            this.buttonHistorico.Image = global::sistema_comercio.Properties.Resources.icons8_receipt_dollar_50;
            this.buttonHistorico.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonHistorico.Location = new System.Drawing.Point(-5, -6);
            this.buttonHistorico.Name = "buttonHistorico";
            this.buttonHistorico.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonHistorico.Size = new System.Drawing.Size(283, 90);
            this.buttonHistorico.TabIndex = 82;
            this.buttonHistorico.Text = "                 Historico";
            this.buttonHistorico.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonHistorico.UseVisualStyleBackColor = true;
            this.buttonHistorico.Click += new System.EventHandler(this.buttonHistorico_Click);
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.GhostWhite;
            this.panel14.Location = new System.Drawing.Point(3, 405);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(10, 90);
            this.panel14.TabIndex = 80;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.button2);
            this.panel8.Controls.Add(this.panel9);
            this.panel8.Location = new System.Drawing.Point(3, 398);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(273, 73);
            this.panel8.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = global::sistema_comercio.Properties.Resources.icons8_export_50;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(-3, -14);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.button2.Size = new System.Drawing.Size(278, 100);
            this.button2.TabIndex = 84;
            this.button2.Text = "                 Sair";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.GhostWhite;
            this.panel9.Location = new System.Drawing.Point(3, 405);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(10, 90);
            this.panel9.TabIndex = 80;
            // 
            // button_menu
            // 
            this.button_menu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_menu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_menu.Image = global::sistema_comercio.Properties.Resources.icons8_menu_50;
            this.button_menu.Location = new System.Drawing.Point(12, 6);
            this.button_menu.Name = "button_menu";
            this.button_menu.Size = new System.Drawing.Size(52, 52);
            this.button_menu.TabIndex = 0;
            this.button_menu.TabStop = false;
            this.button_menu.Click += new System.EventHandler(this.button_menu_Click_1);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.39446F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 169);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1528, 68);
            this.tableLayoutPanel1.TabIndex = 102;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.Buscar);
            this.flowLayoutPanel1.Controls.Add(this.textBoxBuscar);
            this.flowLayoutPanel1.Controls.Add(this.btn_adicionar);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1522, 50);
            this.flowLayoutPanel1.TabIndex = 102;
            // 
            // Buscar
            // 
            this.Buscar.AutoSize = true;
            this.Buscar.BackColor = System.Drawing.Color.Transparent;
            this.Buscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Buscar.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Buscar.Location = new System.Drawing.Point(3, 0);
            this.Buscar.Name = "Buscar";
            this.Buscar.Size = new System.Drawing.Size(76, 48);
            this.Buscar.TabIndex = 104;
            this.Buscar.Text = "Busca";
            this.Buscar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBoxBuscar
            // 
            this.textBoxBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxBuscar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.2F);
            this.textBoxBuscar.Location = new System.Drawing.Point(85, 4);
            this.textBoxBuscar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxBuscar.Multiline = true;
            this.textBoxBuscar.Name = "textBoxBuscar";
            this.textBoxBuscar.Size = new System.Drawing.Size(388, 31);
            this.textBoxBuscar.TabIndex = 94;
            this.textBoxBuscar.TextChanged += new System.EventHandler(this.textBoxBuscar_TextChanged);
            // 
            // btn_adicionar
            // 
            this.btn_adicionar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_adicionar.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btn_adicionar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_adicionar.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btn_adicionar.FlatAppearance.BorderSize = 10;
            this.flowLayoutPanel1.SetFlowBreak(this.btn_adicionar, true);
            this.btn_adicionar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_adicionar.ForeColor = System.Drawing.Color.White;
            this.btn_adicionar.Location = new System.Drawing.Point(479, 4);
            this.btn_adicionar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_adicionar.Name = "btn_adicionar";
            this.btn_adicionar.Size = new System.Drawing.Size(210, 40);
            this.btn_adicionar.TabIndex = 103;
            this.btn_adicionar.Text = "Adicionar Produto";
            this.btn_adicionar.UseVisualStyleBackColor = false;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.panel6.Controls.Add(this.label3);
            this.panel6.Controls.Add(this.button_menu);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1528, 61);
            this.panel6.TabIndex = 104;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 18.8F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(792, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(192, 45);
            this.label3.TabIndex = 79;
            this.label3.Text = "PRODUTOS";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Controls.Add(this.panelVendasHoje, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.panelFaturamentoMes, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.panelEstoqueBaixo, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 61);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1528, 108);
            this.tableLayoutPanel3.TabIndex = 117;
            // 
            // panelVendasHoje
            // 
            this.panelVendasHoje.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panelVendasHoje.BackColor = System.Drawing.Color.White;
            this.panelVendasHoje.Controls.Add(this.lblValorTotal);
            this.panelVendasHoje.Controls.Add(this.label2);
            this.panelVendasHoje.Location = new System.Drawing.Point(541, 3);
            this.panelVendasHoje.Name = "panelVendasHoje";
            this.panelVendasHoje.Size = new System.Drawing.Size(445, 102);
            this.panelVendasHoje.TabIndex = 99;
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.AutoSize = true;
            this.lblValorTotal.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTotal.ForeColor = System.Drawing.Color.Green;
            this.lblValorTotal.Location = new System.Drawing.Point(19, 49);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(150, 50);
            this.lblValorTotal.TabIndex = 1;
            this.lblValorTotal.Text = "R$ 0,00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(22, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(233, 31);
            this.label2.TabIndex = 0;
            this.label2.Text = "VALOR EM ESTOQUE";
            // 
            // panelFaturamentoMes
            // 
            this.panelFaturamentoMes.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panelFaturamentoMes.BackColor = System.Drawing.Color.White;
            this.panelFaturamentoMes.Controls.Add(this.lblQtdProdutos);
            this.panelFaturamentoMes.Controls.Add(this.label10);
            this.panelFaturamentoMes.Location = new System.Drawing.Point(1049, 3);
            this.panelFaturamentoMes.Name = "panelFaturamentoMes";
            this.panelFaturamentoMes.Size = new System.Drawing.Size(448, 102);
            this.panelFaturamentoMes.TabIndex = 101;
            // 
            // lblQtdProdutos
            // 
            this.lblQtdProdutos.AutoSize = true;
            this.lblQtdProdutos.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtdProdutos.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lblQtdProdutos.Location = new System.Drawing.Point(19, 49);
            this.lblQtdProdutos.Name = "lblQtdProdutos";
            this.lblQtdProdutos.Size = new System.Drawing.Size(150, 50);
            this.lblQtdProdutos.TabIndex = 1;
            this.lblQtdProdutos.Text = "R$ 0,00";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Location = new System.Drawing.Point(22, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(209, 31);
            this.label10.TabIndex = 0;
            this.label10.Text = "TOTAL PRODUTOS";
            // 
            // panelEstoqueBaixo
            // 
            this.panelEstoqueBaixo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panelEstoqueBaixo.BackColor = System.Drawing.Color.White;
            this.panelEstoqueBaixo.Controls.Add(this.lblEstoqueBaixo);
            this.panelEstoqueBaixo.Controls.Add(this.label1);
            this.panelEstoqueBaixo.Location = new System.Drawing.Point(29, 3);
            this.panelEstoqueBaixo.Name = "panelEstoqueBaixo";
            this.panelEstoqueBaixo.Size = new System.Drawing.Size(450, 102);
            this.panelEstoqueBaixo.TabIndex = 100;
            // 
            // lblEstoqueBaixo
            // 
            this.lblEstoqueBaixo.AutoSize = true;
            this.lblEstoqueBaixo.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstoqueBaixo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblEstoqueBaixo.Location = new System.Drawing.Point(63, 46);
            this.lblEstoqueBaixo.Name = "lblEstoqueBaixo";
            this.lblEstoqueBaixo.Size = new System.Drawing.Size(43, 50);
            this.lblEstoqueBaixo.TabIndex = 1;
            this.lblEstoqueBaixo.Text = "0";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(66, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "ESTOQUE BAIXO";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.dataGridView1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 237);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1528, 564);
            this.tableLayoutPanel2.TabIndex = 118;
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
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CausesValidation = false;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.MediumSlateBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(1);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.Location = new System.Drawing.Point(10, 4);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(10, 4, 4, 4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1514, 556);
            this.dataGridView1.TabIndex = 119;
            this.dataGridView1.TabStop = false;
            // 
            // FormProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1528, 801);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.sidebar);
            this.Controls.Add(this.panel6);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormProduto";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Produto";
            this.Load += new System.EventHandler(this.FormProduto_Load);
            this.sidebar.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.button_menu)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panelVendasHoje.ResumeLayout(false);
            this.panelVendasHoje.PerformLayout();
            this.panelFaturamentoMes.ResumeLayout(false);
            this.panelFaturamentoMes.PerformLayout();
            this.panelEstoqueBaixo.ResumeLayout(false);
            this.panelEstoqueBaixo.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer sidebar_timer;
        private System.Windows.Forms.FlowLayoutPanel sidebar;
        private System.Windows.Forms.PictureBox button_menu;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button buttonEstoque;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button buttonVenda;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button buttonCliente;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Button buttonHistorico;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox textBoxBuscar;
        private System.Windows.Forms.Button btn_adicionar;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panelVendasHoje;
        private System.Windows.Forms.Label lblValorTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelFaturamentoMes;
        private System.Windows.Forms.Label lblQtdProdutos;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panelEstoqueBaixo;
        private System.Windows.Forms.Label lblEstoqueBaixo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label Buscar;
    }
}