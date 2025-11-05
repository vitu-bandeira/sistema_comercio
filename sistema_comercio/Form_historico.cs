// Substitua TUDO no seu Form_historico.cs por isto:
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
            // Importante: Faça os controles ficarem responsivos
            // Use as propriedades Dock e Anchor no Designer!
        }

        private void Form_historico_Load(object sender, EventArgs e)
        {
            ConfigurarGridVendas();
            ConfigurarGridItens();

            // LIGUE SEUS BOTÕES NO DESIGNER
            // (Dê dois cliques em cada botão no Designer para criar estes eventos)
            

            // Carrega os dados de hoje
            btnHoje_Click(sender, e);
          
        }

        #region Configuração dos Grids
        private void ConfigurarGridVendas()
        {
            dgvVendas.Columns.Clear();
            dgvVendas.AutoGenerateColumns = false;
            dgvVendas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVendas.MultiSelect = false;
            dgvVendas.Columns.Add(new DataGridViewTextBoxColumn { Name = "IdVenda", DataPropertyName = "IdVenda", HeaderText = "Recibo" });
            dgvVendas.Columns.Add(new DataGridViewTextBoxColumn { Name = "DataVenda", DataPropertyName = "DataVenda", HeaderText = "Data/Hora", Width = 450, DefaultCellStyle = { Format = "g" } });
            dgvVendas.Columns.Add(new DataGridViewTextBoxColumn { Name = "Cliente", DataPropertyName = "Cliente", HeaderText = "Cliente", Width = 400 });
            dgvVendas.Columns.Add(new DataGridViewTextBoxColumn { Name = "ValorTotal", DataPropertyName = "ValorTotal", HeaderText = "Valor", DefaultCellStyle = { Format = "C2" } });
            dgvVendas.DefaultCellStyle.Font = new Font("Segoe UI", 14); // Fonte das linhas
            dgvVendas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 16, FontStyle.Bold); // Fonte do cabeçalho
            dgvVendas.RowTemplate.Height = 35;

            dgvVendas.SelectionChanged += dgvVendas_SelectionChanged;
           
        }

        private void ConfigurarGridItens()
        {
            dgvItens.Columns.Clear();
            dgvItens.AutoGenerateColumns = false;
            dgvItens.Columns.Add(new DataGridViewTextBoxColumn { Name = "NomeProduto", DataPropertyName = "NomeProduto", HeaderText = "Produto", Width = 550 });
            dgvItens.Columns.Add(new DataGridViewTextBoxColumn { Name = "Quantidade", DataPropertyName = "Quantidade", HeaderText = "Qtd." });
            dgvItens.Columns.Add(new DataGridViewTextBoxColumn { Name = "PrecoUnitario", DataPropertyName = "PrecoUnitario", HeaderText = "Preço Unit.", DefaultCellStyle = { Format = "C2" } });
            dgvItens.Columns.Add(new DataGridViewTextBoxColumn { Name = "TotalItem", DataPropertyName = "TotalItem", HeaderText = "Total Item", DefaultCellStyle = { Format = "C2" } });
            dgvItens.DefaultCellStyle.Font = new Font("Segoe UI", 17);
            dgvItens.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 17, FontStyle.Bold);
            dgvItens.RowTemplate.Height = 35;
            dgvItens.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
           
        }
        #endregion

        #region Lógica dos Filtros
        private void FiltrarDados()
        {
            try
            {
                // 1. Limpa o grid de itens ANTES de recarregar o grid principal
                dgvItens.DataSource = null;

                // 2. Pega as Vendas com os filtros aplicados
                DataTable dtVendas = DALVendas.GetVendas(dtpInicio.Value, dtpFim.Value, txtFiltroCliente.Text);
                dgvVendas.DataSource = dtVendas;

                // 3. Calcula os resumos financeiros
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

                // --- ESTA É A NOVA PARTE ---
                // 4. Se encontrou vendas, carrega os itens da primeira venda
                if (dtVendas.Rows.Count > 0)
                {
                    // Pega o ID da primeira linha (índice 0)
                    int idPrimeiraVenda = Convert.ToInt32(dtVendas.Rows[0]["IdVenda"]);

                    // Chama o DALVendas e preenche o grid de itens
                    dgvItens.DataSource = DALVendas.GetItensPorVenda(idPrimeiraVenda);
                }
                else
                {
                    // Se não houver vendas, garante que o grid de itens esteja vazio
                    dgvItens.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao filtrar dados: " + ex.Message);
            }
        }

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

        // CRIE OS EVENTOS DE CLIQUE PARA SEUS BOTÕES NO DESIGNER
        private void btnFiltrar_Click(object sender, EventArgs e) {  }
        private void btnHoje_Click(object sender, EventArgs e)
        {
        }
        private void btnSemana_Click(object sender, EventArgs e)
        {
          
        }
        private void btnMes_Click(object sender, EventArgs e)
        {
            dtpInicio.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpFim.Value = DateTime.Today;
            txtFiltroCliente.Clear();
            FiltrarDados();
        }
        #endregion

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

        private void dgvItens_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}