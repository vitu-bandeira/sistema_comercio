namespace sistema_comercio
{
    partial class Form_venda
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Timer sidebar_timer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.sidebar_timer = new System.Windows.Forms.Timer(this.components);
            this.panelMain = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelCarrinho = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panelPix = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCopiaCola = new System.Windows.Forms.TextBox();
            this.pbQrCode = new System.Windows.Forms.PictureBox();
            this.panelPesquisa = new System.Windows.Forms.Panel();
            this.comboBoxProduto = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelPagamento = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxPagamento = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.rbDinheiro = new System.Windows.Forms.RadioButton();
            this.rbFiado = new System.Windows.Forms.RadioButton();
            this.rbCartao = new System.Windows.Forms.RadioButton();
            this.rbPix = new System.Windows.Forms.RadioButton();
            this.panelCliente = new System.Windows.Forms.Panel();
            this.comboBoxCliente = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.labelValorRecebido = new System.Windows.Forms.Label();
            this.labelTroco = new System.Windows.Forms.Label();
            this.lblTrocoValor = new System.Windows.Forms.Label();
            this.txtValorRecebido = new System.Windows.Forms.TextBox();
            this.lblTotalValor = new System.Windows.Forms.Label();
            this.lblTotalDescricao = new System.Windows.Forms.Label();
            this.btnCancelarVenda = new System.Windows.Forms.Button();
            this.btnFinalizarVenda = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.button_menu = new System.Windows.Forms.PictureBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.panel13 = new System.Windows.Forms.Panel();
            this.buttonHistorico = new System.Windows.Forms.Button();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.buttonCliente = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.buttonVenda = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonEstoque = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonHome = new System.Windows.Forms.Button();
            this.sidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelCarrinho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelPix.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbQrCode)).BeginInit();
            this.panelPesquisa.SuspendLayout();
            this.panelPagamento.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBoxPagamento.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panelCliente.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.button_menu)).BeginInit();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.sidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // sidebar_timer
            // 
            this.sidebar_timer.Interval = 20;
            this.sidebar_timer.Tick += new System.EventHandler(this.sidebar_timer_Tick);
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1548, 844);
            this.panelMain.TabIndex = 95;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.53632F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.46368F));
            this.tableLayoutPanel1.Controls.Add(this.panelCarrinho, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelPagamento, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 61);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1548, 783);
            this.tableLayoutPanel1.TabIndex = 101;
            // 
            // panelCarrinho
            // 
            this.panelCarrinho.Controls.Add(this.dataGridView1);
            this.panelCarrinho.Controls.Add(this.panelPix);
            this.panelCarrinho.Controls.Add(this.panelPesquisa);
            this.panelCarrinho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCarrinho.Location = new System.Drawing.Point(3, 3);
            this.panelCarrinho.Name = "panelCarrinho";
            this.panelCarrinho.Size = new System.Drawing.Size(1085, 777);
            this.panelCarrinho.TabIndex = 104;
            this.panelCarrinho.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCarrinho_Paint);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SlateBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SlateBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeight = 40;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.Gainsboro;
            this.dataGridView1.Location = new System.Drawing.Point(0, 67);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 40;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(485, 710);
            this.dataGridView1.TabIndex = 77;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // panelPix
            // 
            this.panelPix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPix.Controls.Add(this.label4);
            this.panelPix.Controls.Add(this.txtCopiaCola);
            this.panelPix.Controls.Add(this.pbQrCode);
            this.panelPix.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelPix.Enabled = false;
            this.panelPix.Location = new System.Drawing.Point(485, 67);
            this.panelPix.Name = "panelPix";
            this.panelPix.Size = new System.Drawing.Size(600, 710);
            this.panelPix.TabIndex = 78;
            this.panelPix.Visible = false;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(162, 639);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(291, 31);
            this.label4.TabIndex = 103;
            this.label4.Text = "Escaneie o QR Code acima";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtCopiaCola
            // 
            this.txtCopiaCola.Font = new System.Drawing.Font("Segoe UI", 12.8F);
            this.txtCopiaCola.Location = new System.Drawing.Point(52, 564);
            this.txtCopiaCola.Name = "txtCopiaCola";
            this.txtCopiaCola.ReadOnly = true;
            this.txtCopiaCola.Size = new System.Drawing.Size(500, 36);
            this.txtCopiaCola.TabIndex = 0;
            // 
            // pbQrCode
            // 
            this.pbQrCode.Location = new System.Drawing.Point(52, 3);
            this.pbQrCode.Name = "pbQrCode";
            this.pbQrCode.Size = new System.Drawing.Size(500, 550);
            this.pbQrCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbQrCode.TabIndex = 0;
            this.pbQrCode.TabStop = false;
            // 
            // panelPesquisa
            // 
            this.panelPesquisa.BackColor = System.Drawing.Color.White;
            this.panelPesquisa.Controls.Add(this.comboBoxProduto);
            this.panelPesquisa.Controls.Add(this.label1);
            this.panelPesquisa.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPesquisa.Location = new System.Drawing.Point(0, 0);
            this.panelPesquisa.Margin = new System.Windows.Forms.Padding(0);
            this.panelPesquisa.Name = "panelPesquisa";
            this.panelPesquisa.Size = new System.Drawing.Size(1085, 67);
            this.panelPesquisa.TabIndex = 0;
            // 
            // comboBoxProduto
            // 
            this.comboBoxProduto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxProduto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxProduto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxProduto.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxProduto.FormattingEnabled = true;
            this.comboBoxProduto.Location = new System.Drawing.Point(344, 14);
            this.comboBoxProduto.Name = "comboBoxProduto";
            this.comboBoxProduto.Size = new System.Drawing.Size(726, 39);
            this.comboBoxProduto.TabIndex = 100;
            this.comboBoxProduto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ComboBoxProduto_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(377, 31);
            this.label1.TabIndex = 10;
            this.label1.Text = "CÓDIGO OU NOME DO PRODUTO:";
            // 
            // panelPagamento
            // 
            this.panelPagamento.BackColor = System.Drawing.Color.White;
            this.panelPagamento.Controls.Add(this.tableLayoutPanel2);
            this.panelPagamento.Controls.Add(this.btnCancelarVenda);
            this.panelPagamento.Controls.Add(this.btnFinalizarVenda);
            this.panelPagamento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPagamento.Location = new System.Drawing.Point(1091, 0);
            this.panelPagamento.Margin = new System.Windows.Forms.Padding(0);
            this.panelPagamento.Name = "panelPagamento";
            this.panelPagamento.Size = new System.Drawing.Size(457, 783);
            this.panelPagamento.TabIndex = 101;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.groupBoxPagamento, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.panelCliente, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.lblTotalValor, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblTotalDescricao, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.90511F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.09489F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 161F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 145F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 172F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(457, 646);
            this.tableLayoutPanel2.TabIndex = 105;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // groupBoxPagamento
            // 
            this.groupBoxPagamento.Controls.Add(this.tableLayoutPanel4);
            this.groupBoxPagamento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxPagamento.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxPagamento.Location = new System.Drawing.Point(3, 170);
            this.groupBoxPagamento.Name = "groupBoxPagamento";
            this.groupBoxPagamento.Size = new System.Drawing.Size(451, 155);
            this.groupBoxPagamento.TabIndex = 103;
            this.groupBoxPagamento.TabStop = false;
            this.groupBoxPagamento.Text = "Forma de Pagamento";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.rbDinheiro, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.rbFiado, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.rbCartao, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.rbPix, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 34);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(445, 118);
            this.tableLayoutPanel4.TabIndex = 4;
            // 
            // rbDinheiro
            // 
            this.rbDinheiro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rbDinheiro.AutoSize = true;
            this.rbDinheiro.Checked = true;
            this.rbDinheiro.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDinheiro.Location = new System.Drawing.Point(3, 3);
            this.rbDinheiro.Name = "rbDinheiro";
            this.rbDinheiro.Size = new System.Drawing.Size(216, 53);
            this.rbDinheiro.TabIndex = 0;
            this.rbDinheiro.TabStop = true;
            this.rbDinheiro.Text = "Dinheiro (F1)";
            this.rbDinheiro.UseVisualStyleBackColor = true;
            // 
            // rbFiado
            // 
            this.rbFiado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rbFiado.AutoSize = true;
            this.rbFiado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFiado.Location = new System.Drawing.Point(225, 62);
            this.rbFiado.Name = "rbFiado";
            this.rbFiado.Size = new System.Drawing.Size(217, 53);
            this.rbFiado.TabIndex = 3;
            this.rbFiado.Text = "Fiado (F4)";
            this.rbFiado.UseVisualStyleBackColor = true;
            // 
            // rbCartao
            // 
            this.rbCartao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rbCartao.AutoSize = true;
            this.rbCartao.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCartao.Location = new System.Drawing.Point(3, 62);
            this.rbCartao.Name = "rbCartao";
            this.rbCartao.Size = new System.Drawing.Size(216, 53);
            this.rbCartao.TabIndex = 1;
            this.rbCartao.Text = "Cartão (F2)";
            this.rbCartao.UseVisualStyleBackColor = true;
            // 
            // rbPix
            // 
            this.rbPix.AutoSize = true;
            this.rbPix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbPix.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPix.Location = new System.Drawing.Point(225, 3);
            this.rbPix.Name = "rbPix";
            this.rbPix.Size = new System.Drawing.Size(217, 53);
            this.rbPix.TabIndex = 2;
            this.rbPix.Text = "Pix (F3)";
            this.rbPix.UseVisualStyleBackColor = true;
            // 
            // panelCliente
            // 
            this.panelCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCliente.Controls.Add(this.comboBoxCliente);
            this.panelCliente.Controls.Add(this.label2);
            this.panelCliente.Location = new System.Drawing.Point(3, 331);
            this.panelCliente.Name = "panelCliente";
            this.panelCliente.Size = new System.Drawing.Size(451, 139);
            this.panelCliente.TabIndex = 106;
            this.panelCliente.Visible = false;
            // 
            // comboBoxCliente
            // 
            this.comboBoxCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxCliente.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxCliente.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCliente.FormattingEnabled = true;
            this.comboBoxCliente.Location = new System.Drawing.Point(0, 31);
            this.comboBoxCliente.Name = "comboBoxCliente";
            this.comboBoxCliente.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboBoxCliente.Size = new System.Drawing.Size(451, 39);
            this.comboBoxCliente.TabIndex = 103;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 31);
            this.label2.TabIndex = 102;
            this.label2.Text = "Selecionar Cliente:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.labelValorRecebido, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelTroco, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblTrocoValor, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtValorRecebido, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 476);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.0566F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.9434F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(451, 167);
            this.tableLayoutPanel3.TabIndex = 107;
            // 
            // labelValorRecebido
            // 
            this.labelValorRecebido.AutoSize = true;
            this.labelValorRecebido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelValorRecebido.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValorRecebido.Location = new System.Drawing.Point(3, 0);
            this.labelValorRecebido.Name = "labelValorRecebido";
            this.labelValorRecebido.Size = new System.Drawing.Size(219, 81);
            this.labelValorRecebido.TabIndex = 0;
            this.labelValorRecebido.Text = "Valor Recebido:";
            this.labelValorRecebido.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelTroco
            // 
            this.labelTroco.AutoSize = true;
            this.labelTroco.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTroco.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTroco.ForeColor = System.Drawing.Color.MediumBlue;
            this.labelTroco.Location = new System.Drawing.Point(3, 81);
            this.labelTroco.Name = "labelTroco";
            this.labelTroco.Size = new System.Drawing.Size(219, 86);
            this.labelTroco.TabIndex = 2;
            this.labelTroco.Text = "TROCO:";
            this.labelTroco.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTrocoValor
            // 
            this.lblTrocoValor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTrocoValor.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrocoValor.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblTrocoValor.Location = new System.Drawing.Point(228, 81);
            this.lblTrocoValor.Name = "lblTrocoValor";
            this.lblTrocoValor.Size = new System.Drawing.Size(220, 86);
            this.lblTrocoValor.TabIndex = 3;
            this.lblTrocoValor.Text = "R$ 0,00";
            this.lblTrocoValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtValorRecebido
            // 
            this.txtValorRecebido.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtValorRecebido.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorRecebido.Location = new System.Drawing.Point(228, 18);
            this.txtValorRecebido.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.txtValorRecebido.Name = "txtValorRecebido";
            this.txtValorRecebido.Size = new System.Drawing.Size(220, 43);
            this.txtValorRecebido.TabIndex = 1;
            this.txtValorRecebido.Text = "0,00";
            this.txtValorRecebido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotalValor
            // 
            this.lblTotalValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalValor.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalValor.ForeColor = System.Drawing.Color.Green;
            this.lblTotalValor.Location = new System.Drawing.Point(3, 82);
            this.lblTotalValor.Name = "lblTotalValor";
            this.lblTotalValor.Size = new System.Drawing.Size(451, 85);
            this.lblTotalValor.TabIndex = 1;
            this.lblTotalValor.Text = "R$ 0,00";
            this.lblTotalValor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalDescricao
            // 
            this.lblTotalDescricao.AutoSize = true;
            this.lblTotalDescricao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalDescricao.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDescricao.Location = new System.Drawing.Point(3, 0);
            this.lblTotalDescricao.Name = "lblTotalDescricao";
            this.lblTotalDescricao.Size = new System.Drawing.Size(451, 82);
            this.lblTotalDescricao.TabIndex = 0;
            this.lblTotalDescricao.Text = "TOTAL DA VENDA";
            this.lblTotalDescricao.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btnCancelarVenda
            // 
            this.btnCancelarVenda.BackColor = System.Drawing.Color.DarkRed;
            this.btnCancelarVenda.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCancelarVenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarVenda.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarVenda.ForeColor = System.Drawing.Color.White;
            this.btnCancelarVenda.Location = new System.Drawing.Point(0, 646);
            this.btnCancelarVenda.Name = "btnCancelarVenda";
            this.btnCancelarVenda.Size = new System.Drawing.Size(457, 71);
            this.btnCancelarVenda.TabIndex = 104;
            this.btnCancelarVenda.Text = "CANCELAR VENDA (ESC)";
            this.btnCancelarVenda.UseVisualStyleBackColor = false;
            // 
            // btnFinalizarVenda
            // 
            this.btnFinalizarVenda.BackColor = System.Drawing.Color.DarkGreen;
            this.btnFinalizarVenda.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnFinalizarVenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalizarVenda.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizarVenda.ForeColor = System.Drawing.Color.White;
            this.btnFinalizarVenda.Location = new System.Drawing.Point(0, 717);
            this.btnFinalizarVenda.Name = "btnFinalizarVenda";
            this.btnFinalizarVenda.Size = new System.Drawing.Size(457, 66);
            this.btnFinalizarVenda.TabIndex = 103;
            this.btnFinalizarVenda.Text = "FINALIZAR VENDA (F5)";
            this.btnFinalizarVenda.UseVisualStyleBackColor = false;
            this.btnFinalizarVenda.Click += new System.EventHandler(this.btnFinalizarVenda_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.panel6.Controls.Add(this.label3);
            this.panel6.Controls.Add(this.button_menu);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1548, 61);
            this.panel6.TabIndex = 100;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 18.8F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(802, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 45);
            this.label3.TabIndex = 79;
            this.label3.Text = "CAIXA";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            // panel8
            // 
            this.panel8.Controls.Add(this.button1);
            this.panel8.Controls.Add(this.panel9);
            this.panel8.Location = new System.Drawing.Point(3, 398);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(273, 73);
            this.panel8.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::sistema_comercio.Properties.Resources.icons8_export_50;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(-3, -14);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(278, 100);
            this.button1.TabIndex = 83;
            this.button1.Text = "                 Sair";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.GhostWhite;
            this.panel9.Controls.Add(this.button2);
            this.panel9.Location = new System.Drawing.Point(3, 405);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(10, 90);
            this.panel9.TabIndex = 80;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = global::sistema_comercio.Properties.Resources.icons8_export_50;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(-134, -5);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.button2.Size = new System.Drawing.Size(278, 100);
            this.button2.TabIndex = 83;
            this.button2.Text = "                 Sair";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = true;
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
            this.buttonHistorico.Click += new System.EventHandler(this.buttonHistorico_Click_1);
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.GhostWhite;
            this.panel14.Location = new System.Drawing.Point(3, 405);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(10, 90);
            this.panel14.TabIndex = 80;
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
            // panel4
            // 
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Controls.Add(this.buttonVenda);
            this.panel4.Location = new System.Drawing.Point(3, 161);
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
            // panel3
            // 
            this.panel3.Controls.Add(this.buttonEstoque);
            this.panel3.Location = new System.Drawing.Point(3, 82);
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
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.Color.SlateBlue;
            this.sidebar.Controls.Add(this.panel2);
            this.sidebar.Controls.Add(this.panel3);
            this.sidebar.Controls.Add(this.panel4);
            this.sidebar.Controls.Add(this.panel5);
            this.sidebar.Controls.Add(this.panel13);
            this.sidebar.Controls.Add(this.panel8);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.Location = new System.Drawing.Point(0, 61);
            this.sidebar.MaximumSize = new System.Drawing.Size(75, 0);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(0, 783);
            this.sidebar.TabIndex = 99;
            // 
            // Form_venda
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1548, 844);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.sidebar);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form_venda";
            this.Text = "Caixa (Ponto de Venda)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_venda_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_venda_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelCarrinho.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelPix.ResumeLayout(false);
            this.panelPix.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbQrCode)).EndInit();
            this.panelPesquisa.ResumeLayout(false);
            this.panelPesquisa.PerformLayout();
            this.panelPagamento.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBoxPagamento.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.panelCliente.ResumeLayout(false);
            this.panelCliente.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.button_menu)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.sidebar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelCarrinho;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panelPesquisa;
        private System.Windows.Forms.ComboBox comboBoxProduto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelPagamento;
        private System.Windows.Forms.Button btnCancelarVenda;
        private System.Windows.Forms.Button btnFinalizarVenda;
        private System.Windows.Forms.Label lblTotalValor;
        private System.Windows.Forms.Label lblTotalDescricao;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblTrocoValor;
        private System.Windows.Forms.Label labelTroco;
        private System.Windows.Forms.TextBox txtValorRecebido;
        private System.Windows.Forms.Label labelValorRecebido;
        private System.Windows.Forms.Panel panelCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBoxPagamento;
        private System.Windows.Forms.RadioButton rbFiado;
        private System.Windows.Forms.RadioButton rbPix;
        private System.Windows.Forms.RadioButton rbCartao;
        private System.Windows.Forms.RadioButton rbDinheiro;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ComboBox comboBoxCliente;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Button buttonHistorico;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button buttonCliente;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button buttonVenda;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonEstoque;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.PictureBox button_menu;
        private System.Windows.Forms.FlowLayoutPanel sidebar;
        private System.Windows.Forms.Panel panelPix;
        private System.Windows.Forms.PictureBox pbQrCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCopiaCola;
    }
}