// Arquivo: Form1.cs
using sistema_comercio.sistema_comercio; // Para o DALDashboard
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting; // Para os gráficos

namespace sistema_comercio
{
    public partial class Form1 : Form
    {
        // Define um limite para "estoque baixo". Altere se quiser.
        private const int LIMITE_ESTOQUE_BAIXO = 10;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            DALVendas.CriarTabelasVendas();
            DALClientes.CriarTabelaClientes();
            DALProdutos.CriarTabelaProdutos();

            // Carrega todos os dados do dashboard
            CarregarDashboard();
        }
        private void CarregarDashboard()
        {
            try
            {
          
                CarregarKPIs();

                CarregarChartVendasSemana();

               
                CarregarChartVistaPrazo();

                CarregarGridTopProdutos();

             
                CarregarGridTopDevedores();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar o dashboard: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Métodos de Carregamento do Dashboard

        private void CarregarKPIs()
        {
            // Vendas Hoje
            lblVendasHoje.Text = DALDashboard.GetVendasHoje().ToString("C2");

            // Estoque Baixo
            lblEstoqueBaixo.Text = DALProdutos.GetContagemEstoqueBaixo(LIMITE_ESTOQUE_BAIXO).ToString();

            // Faturamento Mês
            lblFaturamentoMes.Text = DALDashboard.GetFaturamentoMesAtual().ToString("C2");

            // Total a Receber (soma de saldos negativos)
            // O valor já vem negativo, então usamos Math.Abs para mostrar positivo
            lblTotalReceber.Text = Math.Abs(DALClientes.GetTotalSaldosDevedores()).ToString("C2");
        }

        private void CarregarChartVendasSemana()
        {
            DataTable dt = DALDashboard.GetFaturamentoUltimos7Dias();
            chartVendasSemana.Series[0].Points.Clear();
            chartVendasSemana.Series[0].LabelFormat = "C2";

            foreach (DataRow row in dt.Rows)
            {
                string dia = Convert.ToDateTime(row["Dia"]).ToString("dd/MM");
                decimal total = Convert.ToDecimal(row["Total"]);
                chartVendasSemana.Series[0].Points.AddXY(dia, total);
            }
        }

        private void CarregarChartVistaPrazo()
        {
            DataTable dt = DALDashboard.GetFaturamentoVistaPrazoMes();
            chartVistaPrazo.Series[0].Points.Clear();

            // Cores personalizadas
            Color corVista = Color.FromArgb(77, 182, 172); // Teal
            Color corPrazo = Color.FromArgb(239, 83, 80);  // Red

            foreach (DataRow row in dt.Rows)
            {
                string tipo = row["Tipo"].ToString();
                decimal total = Convert.ToDecimal(row["Total"]);

                int pontoIndex = chartVistaPrazo.Series[0].Points.AddXY(tipo, total);
                DataPoint ponto = chartVistaPrazo.Series[0].Points[pontoIndex];
                ponto.LegendText = $"{tipo} ({total:C2})";

                // Aplica a cor
                if (tipo == "À Vista")
                    ponto.Color = corVista;
                else
                    ponto.Color = corPrazo;
            }
        }

        private void CarregarGridTopProdutos()
        {
            dgvTopProdutos.DataSource = null;
            dgvTopProdutos.Columns.Clear();
            dgvTopProdutos.AutoGenerateColumns = false;

            // Configurar Colunas
            DataGridViewTextBoxColumn colProduto = new DataGridViewTextBoxColumn();
            colProduto.Name = "NomeProduto";
            colProduto.DataPropertyName = "NomeProduto";
            colProduto.HeaderText = "Produto";
            colProduto.FillWeight = 70; // 70% do espaço
            dgvTopProdutos.Columns.Add(colProduto);

            DataGridViewTextBoxColumn colQtd = new DataGridViewTextBoxColumn();
            colQtd.Name = "QuantidadeVendida";
            colQtd.DataPropertyName = "QuantidadeVendida";
            colQtd.HeaderText = "Qtd. Vendida";
            colQtd.FillWeight = 30; // 30% do espaço
            colQtd.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTopProdutos.Columns.Add(colQtd);

            // Carregar dados
            dgvTopProdutos.DataSource = DALDashboard.GetTop5ProdutosVendidosMes();
        }

        private void CarregarGridTopDevedores()
        {
            dgvTopDevedores.DataSource = null;
            dgvTopDevedores.Columns.Clear();
            dgvTopDevedores.AutoGenerateColumns = false;

            // Configurar Colunas
            DataGridViewTextBoxColumn colClienteNome = new DataGridViewTextBoxColumn();
            colClienteNome.Name = "nome";
            colClienteNome.DataPropertyName = "nome";
            colClienteNome.HeaderText = "Cliente";
            colClienteNome.FillWeight = 60; // 60% do espaço
            dgvTopDevedores.Columns.Add(colClienteNome);

            DataGridViewTextBoxColumn colSaldo = new DataGridViewTextBoxColumn();
            colSaldo.Name = "saldo";
            colSaldo.DataPropertyName = "saldo";
            colSaldo.HeaderText = "Dívida";
            colSaldo.FillWeight = 40; // 40% do espaço
            colSaldo.DefaultCellStyle.Format = "C2";
            colSaldo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colSaldo.DefaultCellStyle.ForeColor = Color.Red; // Destaque em vermelho
            dgvTopDevedores.Columns.Add(colSaldo);

            // Carregar dados
            dgvTopDevedores.DataSource = DALClientes.GetTop5Devedores();
        }

        #endregion


        private void buttonVenda_Click_1(object sender, EventArgs e)
        {
            Form_venda newEstoque = new Form_venda();
            newEstoque.Show();
            this.Hide();

        }

        private void buttonCliente_Click(object sender, EventArgs e)
        {
            FormCliente cliente = new FormCliente();
            cliente.Show();
            this.Hide();

        }

        private void buttonHistorico_Click_1(object sender, EventArgs e)
        {
            Form_historico historico = new Form_historico();
            historico.Show();
            this.Hide();

        }

        private void buttonEstoque_Click_1(object sender, EventArgs e)
        {
            FormProduto produto = new FormProduto();
            produto.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Deseja realmente fechar o sistema?",
                                     "Confirmar Saída",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question);

            // Se o usuário clicar em "Sim", o aplicativo fecha.
            if (confirmResult == DialogResult.Yes)
            {
                Application.Exit(); // Este comando fecha o programa INTEIRO.
            }
        }
        bool sidebarExpanded = true;
        private void sidebar_timer_Tick(object sender, EventArgs e)
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

        private void button_menu_Click_1(object sender, EventArgs e)
        {
            sidebar_timer.Start();
        }
        
    }
}