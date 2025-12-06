using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace sistema_comercio
{
    public partial class Form_historico : Form
    {
        public Form_historico()
        {
            InitializeComponent();

            // 1. Configurações Visuais
            ConfigurarGridVendas();
            ConfigurarGridItens();

            // 2. BLINDAGEM DE EVENTOS (A correção principal)
            // Isso garante que os cliques funcionem mesmo se o Designer falhar
            ConfigurarEventos();
        }

        private void Form_historico_Load(object sender, EventArgs e)
        {
            // Carrega os dados de hoje ao abrir
            btnHoje_Click_1(null, null);
        }

        // --- MÉTODO NOVO PARA LIGAR TUDO ---
        private void ConfigurarEventos()
        {
            // Botões de Filtro de Data
            this.btnHoje.Click += new EventHandler(this.btnHoje_Click_1);
            this.btnSemana.Click += new EventHandler(this.btnSemana_Click_1);
            this.btnMes.Click += new EventHandler(this.btnMes_Click_1);
            this.btnFiltrar.Click += new EventHandler(this.btnFiltrar_Click_1);

            // Botões do Menu Lateral (Navegação)
            this.buttonHome.Click += new EventHandler(this.buttonHome_Click);
            this.buttonEstoque.Click += new EventHandler(this.buttonEstoque_Click);
            this.buttonVenda.Click += new EventHandler(this.buttonVenda_Click);
            this.buttonCliente.Click += new EventHandler(this.buttonCliente_Click);

            // Botão do próprio form (pode estar invisível ou desativado, mas garantimos a ligação)
            this.buttonHistorico.Click += new EventHandler(this.buttonHistorico_Click_1); // Se houver um botão para recarregar

            this.button1.Click += new EventHandler(this.button3_Click); // Botão SAIR
            this.button_menu.Click += new EventHandler(this.button_menu_Click); // Botão Menu (Hambúrguer)

            // Eventos de Grid e Timer
            this.dgvVendas.CellClick += new DataGridViewCellEventHandler(this.dgvVendas_CellContentClick);
            this.sidebar_timer.Tick += new EventHandler(this.sidebar_timer_Tick_1);
        }

        #region Configuração dos Grids

        private void ConfigurarGridVendas()
        {
            dgvVendas.Columns.Clear();
            dgvVendas.AutoGenerateColumns = false;
            dgvVendas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVendas.MultiSelect = false;
            dgvVendas.ReadOnly = true;

            // Coluna Recibo
            DataGridViewTextBoxColumn colRecibo = new DataGridViewTextBoxColumn();
            colRecibo.Name = "IdVenda";
            colRecibo.DataPropertyName = "IdVenda";
            colRecibo.HeaderText = "ID";
            colRecibo.FillWeight = 40;
            colRecibo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvVendas.Columns.Add(colRecibo);

            // Coluna Data/Hora
            DataGridViewTextBoxColumn colData = new DataGridViewTextBoxColumn();
            colData.Name = "DataVenda";
            colData.DataPropertyName = "DataVenda";
            colData.HeaderText = "Data/Hora";
            colData.FillWeight = 200;
            colData.DefaultCellStyle.Format = "g";
            dgvVendas.Columns.Add(colData);

            // Coluna Cliente
            DataGridViewTextBoxColumn colCliente = new DataGridViewTextBoxColumn();
            colCliente.Name = "Cliente";
            colCliente.DataPropertyName = "Cliente";
            colCliente.HeaderText = "Cliente";
            colCliente.FillWeight = 300;
            dgvVendas.Columns.Add(colCliente);

            // Coluna Valor
            DataGridViewTextBoxColumn colValor = new DataGridViewTextBoxColumn();
            colValor.Name = "ValorTotal";
            colValor.DataPropertyName = "ValorTotal";
            colValor.HeaderText = "Valor";
            colValor.Width = 150;
            colValor.DefaultCellStyle.Format = "C2";
            colValor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvVendas.Columns.Add(colValor);

            // Estilo do Grid
            dgvVendas.DefaultCellStyle.Font = new Font("Segoe UI", 12);
            dgvVendas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            dgvVendas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVendas.RowTemplate.Height = 35;
        }

        private void ConfigurarGridItens()
        {
            dgvItens.Columns.Clear();
            dgvItens.AutoGenerateColumns = false;
            dgvItens.ReadOnly = true;
            dgvItens.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Coluna Produto
            DataGridViewTextBoxColumn colNome = new DataGridViewTextBoxColumn();
            colNome.Name = "NomeProduto";
            colNome.DataPropertyName = "NomeProduto";
            colNome.HeaderText = "Produto";
            colNome.Width = 200;
            dgvItens.Columns.Add(colNome);

            // Coluna Quantidade
            DataGridViewTextBoxColumn colQuantidade = new DataGridViewTextBoxColumn();
            colQuantidade.Name = "Quantidade";
            colQuantidade.DataPropertyName = "Quantidade";
            colQuantidade.HeaderText = "Qtd.";
            colQuantidade.Width = 80;
            colQuantidade.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvItens.Columns.Add(colQuantidade);

            // Coluna Preço Unitário
            DataGridViewTextBoxColumn colPrecoUnitario = new DataGridViewTextBoxColumn();
            colPrecoUnitario.Name = "PrecoUnitario";
            colPrecoUnitario.DataPropertyName = "PrecoUnitario";
            colPrecoUnitario.HeaderText = "Preço Unit.";
            colPrecoUnitario.Width = 120;
            colPrecoUnitario.DefaultCellStyle.Format = "C2";
            colPrecoUnitario.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvItens.Columns.Add(colPrecoUnitario);

            // Coluna Total Item
            DataGridViewTextBoxColumn colTotalItem = new DataGridViewTextBoxColumn();
            colTotalItem.Name = "TotalItem";
            colTotalItem.DataPropertyName = "TotalItem";
            colTotalItem.HeaderText = "Total Item";
            colTotalItem.Width = 120;
            colTotalItem.DefaultCellStyle.Format = "C2";
            colTotalItem.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvItens.Columns.Add(colTotalItem);

            // Estilo do Grid
            dgvItens.DefaultCellStyle.Font = new Font("Segoe UI", 12);
            dgvItens.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            dgvItens.RowTemplate.Height = 35;
        }

        #endregion

        #region Lógica dos Filtros

        private void FiltrarDados()
        {
            try
            {
                // 1. Limpa o grid de itens
                dgvItens.DataSource = null;

                // 2. Busca vendas
                DataTable dtVendas = DALVendas.GetVendas(dtpInicio.Value, dtpFim.Value, txtFiltroCliente.Text);
                dgvVendas.DataSource = dtVendas;

                // 3. Calcula totais
                decimal totalFaturado = 0;
                decimal totalDebito = 0;
                foreach (DataRow row in dtVendas.Rows)
                {
                    totalFaturado += Convert.ToDecimal(row["ValorTotal"]);
                    if (row["Cliente"].ToString() != "À Vista")
                    {
                        totalDebito += Convert.ToDecimal(row["ValorTotal"]);
                    }
                }
                lblTotalFaturado.Text = totalFaturado.ToString("C2");
                lblTotalDebito.Text = totalDebito.ToString("C2");

                // 4. Carrega itens da primeira venda se existir
                if (dtVendas.Rows.Count > 0)
                {
                    int idPrimeiraVenda = Convert.ToInt32(dtVendas.Rows[0]["IdVenda"]);
                    dgvItens.DataSource = DALVendas.GetItensPorVenda(idPrimeiraVenda);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao filtrar dados: " + ex.Message);
            }
        }

        private void btnHoje_Click_1(object sender, EventArgs e)
        {
            dtpInicio.Value = DateTime.Today;
            dtpFim.Value = DateTime.Today;
            txtFiltroCliente.Clear();
            FiltrarDados();
        }

        private void btnSemana_Click_1(object sender, EventArgs e)
        {
            dtpInicio.Value = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
            dtpFim.Value = DateTime.Today;
            txtFiltroCliente.Clear();
            FiltrarDados();
        }

        private void btnMes_Click_1(object sender, EventArgs e)
        {
            dtpInicio.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpFim.Value = DateTime.Today;
            txtFiltroCliente.Clear();
            FiltrarDados();
        }

        private void btnFiltrar_Click_1(object sender, EventArgs e)
        {
            FiltrarDados();
        }

        // Atenção: Mudei o evento para CellClick no ConfigurarEventos, pois é mais confiável para seleção de linha
        private void dgvVendas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Ignora cabeçalho

            if (dgvVendas.CurrentRow == null) return;

            try
            {
                int idVenda = Convert.ToInt32(dgvVendas.CurrentRow.Cells["IdVenda"].Value);
                dgvItens.DataSource = DALVendas.GetItensPorVenda(idVenda);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar itens da venda: " + ex.Message);
            }
        }

        #endregion

        #region Navegação e Sidebar

        private void buttonHome_Click(object sender, EventArgs e)
        {
            Form1 newF = new Form1();
            newF.Show();
            this.Close();
        }

        private void buttonEstoque_Click(object sender, EventArgs e)
        {
            FormProduto formProduto = new FormProduto();
            formProduto.Show();
            this.Close();
        }

        private void buttonVenda_Click(object sender, EventArgs e)
        {
            Form_venda newEstoque = new Form_venda();
            newEstoque.Show();
            this.Close();
        }

        private void buttonCliente_Click(object sender, EventArgs e)
        {
            FormCliente newCliente = new FormCliente();
            newCliente.Show();
            this.Close();
        }

        private void buttonHistorico_Click_1(object sender, EventArgs e)
        {
            // Já estamos no histórico, pode apenas recarregar ou não fazer nada
            FiltrarDados();
        }

        private void button_menu_Click(object sender, EventArgs e)
        {
            sidebar_timer.Start();
        }

        bool sidebarExpanded = true;
        private void sidebar_timer_Tick_1(object sender, EventArgs e)
        {
            if (sidebarExpanded)
            {
                if (sidebar.Width > sidebar.MinimumSize.Width) sidebar.Width -= 10;
                else { sidebarExpanded = false; sidebar_timer.Stop(); }
            }
            else
            {
                if (sidebar.Width < sidebar.MaximumSize.Width) sidebar.Width += 10;
                else { sidebarExpanded = true; sidebar_timer.Stop(); }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Deseja realmente fechar o sistema?",
                                     "Confirmar Saída",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // Método vazio caso seja chamado pelo designer antigo
        private void dgvItens_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        #endregion

        private void flowLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}