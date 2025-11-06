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

            ConfigurarGridVendas();
            ConfigurarGridItens(); 
            

        }
        private void Form_historico_Load(object sender, EventArgs e)
        {
            btnHoje_Click_1(null, null);
        }



        #region Configuração dos Grids
        // Cole este método no seu Form_historico.cs
        // Cole este método no seu Form_historico.cs
        private void ConfigurarGridVendas()
        {
            dgvVendas.Columns.Clear();
            dgvVendas.AutoGenerateColumns = false;
            dgvVendas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVendas.MultiSelect = false;
            dgvVendas.ReadOnly = true;
            dgvVendas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Coluna Recibo
            DataGridViewTextBoxColumn colRecibo = new DataGridViewTextBoxColumn();
            colRecibo.Name = "IdVenda";
            colRecibo.DataPropertyName = "IdVenda";
            colRecibo.HeaderText = "ID";
            colRecibo.FillWeight = 40; // Largura fixa
            colRecibo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvVendas.Columns.Add(colRecibo);

            // Coluna Data/Hora
            DataGridViewTextBoxColumn colData = new DataGridViewTextBoxColumn();
            colData.Name = "DataVenda";
            colData.DataPropertyName = "DataVenda";
            colData.HeaderText = "Data/Hora";
            colData.FillWeight = 200; // Largura fixa
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
            colValor.Width = 150; // Largura fixa
            colValor.DefaultCellStyle.Format = "C2";
            colValor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Centralizado
            dgvVendas.Columns.Add(colValor);

            // Estilo do Grid (idêntico ao Form_venda)
            dgvVendas.DefaultCellStyle.Font = new Font("Segoe UI", 14);
            dgvVendas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            dgvVendas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVendas.RowTemplate.Height = 35;

            
        }

        // Cole este método também no seu Form_historico.cs
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
            colNome.Width = 320; // Largura fixa
            dgvItens.Columns.Add(colNome);

            // Coluna Quantidade
            DataGridViewTextBoxColumn colQuantidade = new DataGridViewTextBoxColumn();
            colQuantidade.Name = "Quantidade";
            colQuantidade.DataPropertyName = "Quantidade";
            colQuantidade.HeaderText = "Qtd.";
            colQuantidade.Width = 80; // Largura fixa
            colQuantidade.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Centralizado
            dgvItens.Columns.Add(colQuantidade);

            // Coluna Preço Unitário
            DataGridViewTextBoxColumn colPrecoUnitario = new DataGridViewTextBoxColumn();
            colPrecoUnitario.Name = "PrecoUnitario";
            colPrecoUnitario.DataPropertyName = "PrecoUnitario";
            colPrecoUnitario.HeaderText = "Preço Unit.";
            colPrecoUnitario.Width = 140; // Largura fixa
            colPrecoUnitario.DefaultCellStyle.Format = "C2";
            colPrecoUnitario.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Centralizado
            dgvItens.Columns.Add(colPrecoUnitario);

            // Coluna Total Item
            DataGridViewTextBoxColumn colTotalItem = new DataGridViewTextBoxColumn();
            colTotalItem.Name = "TotalItem";
            colTotalItem.DataPropertyName = "TotalItem";
            colTotalItem.HeaderText = "Total Item";
            colTotalItem.Width = 140; // Largura fixa
            colTotalItem.DefaultCellStyle.Format = "C2";
            colTotalItem.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Centralizado
            dgvItens.Columns.Add(colTotalItem);

            // Estilo do Grid (idêntico ao Form_venda)
            dgvItens.DefaultCellStyle.Font = new Font("Segoe UI", 14);
            dgvItens.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            dgvItens.RowTemplate.Height = 35;

            // A linha "AutoSizeColumnsMode = Fill" foi removida para que o ".Width" funcione.
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


        // CRIE OS EVENTOS DE CLIQUE PARA SEUS BOTÕES NO DESIGNER


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

        private void dgvVendas_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
    }
}