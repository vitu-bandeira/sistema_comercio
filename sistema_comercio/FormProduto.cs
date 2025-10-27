using sistema_comercio.sistema_comercio;
using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ExplorerBar;


namespace sistema_comercio
{
    public partial class FormProduto : Form
    {
        public FormProduto()
        {
            InitializeComponent();
            AplicarEventos(textBox_preço_venda);
            AplicarEventos(textBox_quantidade);
            AplicarEventos(textBox_codigo_barra);
            ConfigurarGrid();
    
            this.WindowState = FormWindowState.Maximized;
            this.btn_adicionar.Click += new System.EventHandler(this.btn_adicionar_Click);
           

            dataGridView1.CellClick += dataGridView1_CellClick;
            

        }
        private void FormProduto_Load(object sender, EventArgs e)
        {
            DALProdutos.CriarBancoSQLite();
            DALProdutos.CriarTabelaProdutos();
            ExibirDados();
        }
        private void ExibirDados()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DALProdutos.GetProdutos();
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao exibir os dados: " + ex.Message);
            }
        }


        private void AplicarEventos(System.Windows.Forms.TextBox txt)
        {

            txt.KeyPress += ApenasValorNumerico;
        }

        private void ApenasValorNumerico(object sender, KeyPressEventArgs e)
        {
            System.Windows.Forms.TextBox txt = (System.Windows.Forms.TextBox)sender;
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(Keys.Back))
            {
                if (e.KeyChar == ',')
                {
                    e.Handled = (txt.Text.Contains(','));
                }
                else
                    e.Handled = true;
            }
        }


        private void ConfigurarGrid()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = false;

            // Coluna ID (oculta)
            DataGridViewTextBoxColumn colID = new DataGridViewTextBoxColumn();
            colID.Name = "id";
            colID.DataPropertyName = "id"; // banco
            colID.HeaderText = "ID";
            colID.Visible = false;
            dataGridView1.Columns.Add(colID);

            // Nome
            DataGridViewTextBoxColumn colNome = new DataGridViewTextBoxColumn();
            colNome.Name = "nome";
            colNome.DataPropertyName = "nome";
            colNome.HeaderText = "Produto";
            colNome.Width = 300;
            dataGridView1.Columns.Add(colNome);

            // Código de Barras
            DataGridViewTextBoxColumn colCodigo = new DataGridViewTextBoxColumn();
            colCodigo.Name = "codigoBarras";
            colCodigo.DataPropertyName = "codigoBarras";
            colCodigo.HeaderText = "Código";
            colCodigo.Width = 245;
            dataGridView1.Columns.Add(colCodigo);

            // Preço
            DataGridViewTextBoxColumn colPreco = new DataGridViewTextBoxColumn();
            colPreco.Name = "preco";
            colPreco.DataPropertyName = "preco";
            colPreco.HeaderText = "Preço";
            colPreco.DefaultCellStyle.Format = "C2";
            colPreco.Width = 130;
            dataGridView1.Columns.Add(colPreco);

            // Quantidade (estoque)
            DataGridViewTextBoxColumn colEstoque = new DataGridViewTextBoxColumn();
            colEstoque.Name = "estoque";
            colEstoque.DataPropertyName = "estoque";
            colEstoque.HeaderText = "Estoque";
            colEstoque.Width = 120;
            dataGridView1.Columns.Add(colEstoque);

            // Validade
            DataGridViewTextBoxColumn colValidade = new DataGridViewTextBoxColumn();
            colValidade.Name = "validade";
            colValidade.DataPropertyName = "validade";
            colValidade.HeaderText = "Validade";
            colValidade.Width = 150;
            dataGridView1.Columns.Add(colValidade);

            // Botão Excluir
            DataGridViewButtonColumn colExcluir = new DataGridViewButtonColumn();
            colExcluir.Name = "Excluir";
            colExcluir.HeaderText = "Excluir";
            colExcluir.Text = "🗑";
            colExcluir.UseColumnTextForButtonValue = true;
            colExcluir.Width = 100;
            dataGridView1.Columns.Add(colExcluir);

            // Estilo
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 17);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 17, FontStyle.Bold);
            dataGridView1.RowTemplate.Height = 35;
        }
        private void btn_adicionar_Click(object sender, EventArgs e)
        {
            try {
                
                if (string.IsNullOrWhiteSpace(textBox_nome_p.Text))
                {
                    labelInsiraNome.Visible = true;
                    return;
                }
                if (string.IsNullOrWhiteSpace(textBox_codigo_barra.Text))
                {
                    labelInsiraCodigo.Visible = true;
                    return;
                }
                if (string.IsNullOrWhiteSpace(textBox_preço_venda.Text))
                {
                    MessageBox.Show("Insira um Preço no Produto");
                    return;
                }
                if (string.IsNullOrWhiteSpace(textBox_quantidade.Text))
                {
                    labelInsiraQuantidade.Visible = true;
                    return;
                }
                
                Produto_dtb produto = new Produto_dtb();
                produto.Nome = textBox_nome_p.Text;
                produto.CodigoBarras = textBox_codigo_barra.Text;
                produto.Preco = decimal.Parse(textBox_preço_venda.Text.Replace(",","."), CultureInfo.InvariantCulture);
                produto.Estoque = int.Parse(textBox_quantidade.Text, CultureInfo.InvariantCulture);
                produto.Validade = dateTimePicker1.Value;
                
                DALProdutos.AddProduto(produto);
                MessageBox.Show("Produto adicionado com sucesso!");
                LimparCampos();
            }
            catch (FormatException)
            {
                MessageBox.Show("Formato inválido nos campos numéricos!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar produto: {ex.Message}");
                
            }
            finally {
                ExibirDados();
            }
        }
        private void LimparCampos()
        {
            textBox_nome_p.Clear();
            textBox_codigo_barra.Clear();
            textBox_preço_venda.Clear();
            textBox_quantidade.Clear();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica se clicou em alguma coluna de ação
            
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Excluir")
            {
                ExcluirProduto(e.RowIndex);
            }
            else if (e.RowIndex >= 0)
            {
                DataGridViewRow rows = dataGridView1.Rows[e.RowIndex];
                textBox_nome_p.Text = rows.Cells["nome"].Value.ToString();
                textBox_codigo_barra.Text = rows.Cells["codigoBarras"].Value.ToString();
                textBox_preço_venda.Text = rows.Cells["preco"].Value.ToString();
                textBox_quantidade.Text = rows.Cells["estoque"].Value.ToString();
                if (rows.Cells["validade"].Value != DBNull.Value)
                    dateTimePicker1.Value = Convert.ToDateTime(rows.Cells["validade"].Value);
                else
                    dateTimePicker1.Value = DateTime.Now;
               

            }

        }
        private void EditarProduto(int rowIndex)
        {
           
           
        }
        private void AtualizarProduto(int id, string nome, string codigo, decimal preco, int quantidade)
        {
            
        }
        private void ExcluirProduto(int rowIndex)
        {
            try
            {
                if (rowIndex < 0 || rowIndex >= dataGridView1.Rows.Count)
                    return;

                DataGridViewRow row = dataGridView1.Rows[rowIndex];
                int id = Convert.ToInt32(row.Cells["id"].Value);

                var confirmResult = MessageBox.Show("Tem certeza que deseja excluir este produto?", "Confirmação", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    DALProdutos.DeleteProduto(id);
                    MessageBox.Show("Produto excluído com sucesso!, Sucesso, MessageBoxButtons.OK, MessageBoxIcon.Information");
                    ExibirDados();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir: {ex.Message}");
            }
        }

        private bool sidebarExpanded = true;
       
        private void sidebar_timer_Tick_1(object sender, EventArgs e)
        {
            if (sidebarExpanded)
            {
                // FECHAR o sidebar (ir para o mínimo)
                if (sidebar.Width > sidebar.MinimumSize.Width)
                {
                    sidebar.Width -= 10;

                }
                else
                {
                    sidebarExpanded = false;
                    sidebar_timer.Stop();

                }
            }
            else
            {
                // ABRIR o sidebar (ir para o máximo)
                if (sidebar.Width < sidebar.MaximumSize.Width)
                {
                    sidebar.Width += 10;

                }
                else
                {
                    sidebarExpanded = true;
                    sidebar_timer.Stop();
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void button_menu_Click(object sender, EventArgs e)
        {
            sidebar_timer.Start();
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            Form1 newF = new Form1();
            newF.Show();
            this.Close();
        }

        private void buttonEstoque_Click(object sender, EventArgs e)
        {
            
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

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void labelInsiraNome_Click(object sender, EventArgs e)
        {

        }

        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string busca = textBoxBuscar.Text.Trim(); // remove espaços
                DataTable dt = DALProdutos.GetProduto(busca);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar os dados: " + ex.Message);
            }
        }

        
    }
}






