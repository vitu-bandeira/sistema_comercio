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
        }

        private void Form_historico_Load(object sender, EventArgs e)
        {
            // Configura os grids para terem um visual profissional
            ConfigurarGridVendas();
            ConfigurarGridItens();

            // Adiciona os eventos de clique aos botões
            btnHoje.Click += btnHoje_Click;
            btnSemana.Click += btnSemana_Click;
            btnMes.Click += btnMes_Click;
            btnFiltrar.Click += btnFiltrar_Click;

            // Simula o clique no botão "Hoje" para carregar os dados do dia
            btnHoje_Click(sender, e);
        }

        #region Configuração dos Grids

        private void ConfigurarGridVendas()
        {
            dgvVendas.Columns.Clear();
            dgvVendas.AutoGenerateColumns = false;
            dgvVendas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVendas.MultiSelect = false;

            // Adiciona as colunas
            dgvVendas.Columns.Add(new DataGridViewTextBoxColumn { Name = "IdVenda", DataPropertyName = "IdVenda", HeaderText = "Recibo" });
            dgvVendas.Columns.Add(new DataGridViewTextBoxColumn { Name = "DataVenda", DataPropertyName = "DataVenda", HeaderText = "Data/Hora", Width = 150, DefaultCellStyle = { Format = "g" } });
            dgvVendas.Columns.Add(new DataGridViewTextBoxColumn { Name = "Cliente", DataPropertyName = "Cliente", HeaderText = "Cliente", Width = 200 });
            dgvVendas.Columns.Add(new DataGridViewTextBoxColumn { Name = "ValorTotal", DataPropertyName = "ValorTotal", HeaderText = "Valor", DefaultCellStyle = { Format = "C2" } });

            dgvVendas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVendas.DefaultCellStyle.Font = new Font("Segoe UI", 11);
            dgvVendas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            // Evento que carrega os detalhes quando uma venda é selecionada
            dgvVendas.SelectionChanged += dgvVendas_SelectionChanged;
        }

        private void ConfigurarGridItens()
        {
            dgvItens.Columns.Clear();
            dgvItens.AutoGenerateColumns = false;

            dgvItens.Columns.Add(new DataGridViewTextBoxColumn { Name = "NomeProduto", DataPropertyName = "NomeProduto", HeaderText = "Produto", Width = 250 });
            dgvItens.Columns.Add(new DataGridViewTextBoxColumn { Name = "Quantidade", DataPropertyName = "Quantidade", HeaderText = "Qtd." });
            dgvItens.Columns.Add(new DataGridViewTextBoxColumn { Name = "PrecoUnitario", DataPropertyName = "PrecoUnitario", HeaderText = "Preço Unit.", DefaultCellStyle = { Format = "C2" } });
            dgvItens.Columns.Add(new DataGridViewTextBoxColumn { Name = "TotalItem", DataPropertyName = "TotalItem", HeaderText = "Total Item", DefaultCellStyle = { Format = "C2" } });

            dgvItens.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        #endregion

        #region Lógica dos Filtros

        // O cérebro principal: busca os dados e atualiza a tela
        private void FiltrarDados()
        {
            try
            {
                // 1. Pega as Vendas com os filtros aplicados
                DataTable dtVendas = DALVendas.GetVendas(dtpInicio.Value, dtpFim.Value, txtFiltroCliente.Text);
                dgvVendas.DataSource = dtVendas;

                // 2. Calcula os resumos financeiros
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

                // 3. Mostra os resumos nos Labels
                lblTotalFaturado.Text = totalFaturado.ToString("C2");
                lblTotalDebito.Text = totalDebito.ToString("C2");

                // Limpa os detalhes se não houver vendas
                if (dtVendas.Rows.Count == 0)
                {
                    dgvItens.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao filtrar dados: " + ex.Message);
            }
        }

        // Quando o usuário clica em uma venda, mostra os itens dela
        private void dgvVendas_SelectionChanged(object sender, EventArgs e)
        {
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

        // --- Eventos dos Botões de Filtro ---
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            FiltrarDados();
        }

        private void btnHoje_Click(object sender, EventArgs e)
        {
            dtpInicio.Value = DateTime.Today;
            dtpFim.Value = DateTime.Today;
            txtFiltroCliente.Clear();
            FiltrarDados();
        }

        private void btnSemana_Click(object sender, EventArgs e)
        {
            dtpInicio.Value = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
            dtpFim.Value = DateTime.Today;
            txtFiltroCliente.Clear();
            FiltrarDados();
        }

        private void btnMes_Click(object sender, EventArgs e)
        {
            dtpInicio.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpFim.Value = DateTime.Today;
            txtFiltroCliente.Clear();
            FiltrarDados();
        }

        #endregion

        private void dtpInicio_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}