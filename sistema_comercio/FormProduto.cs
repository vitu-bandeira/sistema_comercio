using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using sistema_comercio.sistema_comercio; // Garante que ache o DAL

namespace sistema_comercio
{
    public partial class FormProduto : Form
    {
        public FormProduto()
        {
            InitializeComponent();
            ConfigurarGrid();
            this.WindowState = FormWindowState.Maximized;

            // Associação de eventos manuais (se não estiverem no Designer)
            // Se já estiverem ligados no raiozinho do Designer, essas linhas são opcionais
            this.btn_adicionar.Click += new EventHandler(this.btn_adicionar_Click);
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void FormProduto_Load(object sender, EventArgs e)
        {
            try
            {
                DALProdutos.CriarBancoSQLite();
                DALProdutos.CriarTabelaProdutos();
                ExibirDados();
                CarregarCards();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar sistema: " + ex.Message);
            }
        }

        // --- MÉTODOS DE DADOS ---

        private void ExibirDados()
        {
            try
            {
                DataTable dt = DALProdutos.GetProdutos();
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao exibir os dados: " + ex.Message);
            }
        }

        private void CarregarCards()
        {
            try
            {
                lblValorTotal.Text = DALProdutos.GetValorTotalEstoque().ToString("C2");
                lblValorTotal.ForeColor = Color.Green;

                int baixo = DALProdutos.GetContagemEstoqueBaixo(10);
                lblEstoqueBaixo.Text = baixo.ToString();
                lblEstoqueBaixo.ForeColor = baixo > 0 ? Color.Red : Color.Gray;

                lblQtdProdutos.Text = DALProdutos.GetTotalProdutosCadastrados().ToString();
            }
            catch { }
        }

        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string busca = textBoxBuscar.Text.Trim();
                DataTable dt = DALProdutos.GetProduto(busca);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar: " + ex.Message);
            }
        }

        // --- AÇÕES DO GRID (EDITAR / EXCLUIR) ---

        private void ConfigurarGrid()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = false;

            // Coluna ID (oculta)
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "id",
                DataPropertyName = "id",
                HeaderText = "ID",
                Visible = false
            });

            // Nome
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "nome",
                DataPropertyName = "nome",
                HeaderText = "Produto",
                Width = 300
            });

            // Código
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "codigoBarras",
                DataPropertyName = "codigoBarras",
                HeaderText = "Código",
                Width = 200
            });

            // Preço
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "preco",
                DataPropertyName = "preco",
                HeaderText = "Preço",
                Width = 130,
                DefaultCellStyle = { Format = "C2" }
            });

            // Estoque
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "estoque",
                DataPropertyName = "estoque",
                HeaderText = "Estoque",
                Width = 120
            });

            // Validade
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "validade",
                DataPropertyName = "validade",
                HeaderText = "Validade",
                Width = 150
            });

            // Botões
            dataGridView1.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Editar",
                HeaderText = "Editar",
                Text = "✏️",
                UseColumnTextForButtonValue = true,
                Width = 80
            });

            dataGridView1.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Excluir",
                HeaderText = "Excluir",
                Text = "🗑",
                UseColumnTextForButtonValue = true,
                Width = 80
            });

            // Estilo
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 12);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            dataGridView1.RowTemplate.Height = 35;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            string colunaNome = dataGridView1.Columns[e.ColumnIndex].Name;

            if (colunaNome == "Excluir")
            {
                ExcluirProduto(e.RowIndex);
            }
            else if (colunaNome == "Editar")
            {
                // Preenche o objeto com os dados da linha
                Produto_dtb produto = new Produto_dtb();
                produto.Id = Convert.ToInt32(row.Cells["id"].Value);
                produto.Nome = row.Cells["nome"].Value.ToString();
                produto.CodigoBarras = row.Cells["codigoBarras"].Value.ToString();
                produto.Preco = Convert.ToDecimal(row.Cells["preco"].Value);
                produto.Estoque = Convert.ToInt32(row.Cells["estoque"].Value);

                if (row.Cells["validade"].Value != DBNull.Value)
                    produto.Validade = Convert.ToDateTime(row.Cells["validade"].Value);

                // Abre o form de detalhes passando o produto
                using (Form_DetalheProduto formEdit = new Form_DetalheProduto(produto))
                {
                    if (formEdit.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            DALProdutos.UpdateProduto(formEdit.Produto);
                            MessageBox.Show("Produto atualizado!");
                            ExibirDados();
                            CarregarCards();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao atualizar: " + ex.Message);
                        }
                    }
                }
            }
        }

        private void ExcluirProduto(int rowIndex)
        {
            try
            {
                int id = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["id"].Value);
                var confirm = MessageBox.Show("Deseja excluir este produto?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    DALProdutos.DeleteProduto(id);
                    MessageBox.Show("Produto excluído!");
                    ExibirDados();
                    CarregarCards();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir: {ex.Message}");
            }
        }

        // --- BOTÃO ADICIONAR (ESTAVA VAZIO) ---
        private void btn_adicionar_Click(object sender, EventArgs e)
        {
            // Abre o formulário passando NULL ou um Produto vazio para indicar "Novo Cadastro"
            // Certifique-se que o construtor do Form_DetalheProduto aceita isso
            using (Form_DetalheProduto formAdd = new Form_DetalheProduto(null))
            {
                if (formAdd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        DALProdutos.AddProduto(formAdd.Produto);
                        MessageBox.Show("Produto adicionado com sucesso!");
                        ExibirDados(); // Atualiza o grid
                        CarregarCards();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao salvar: " + ex.Message);
                    }
                }
            }
        }

        // --- MENU E NAVEGAÇÃO ---

        bool sidebarExpanded = true;
        private void sidebar_timer_Tick_1(object sender, EventArgs e)
        {
            if (sidebarExpanded)
            {
                sidebar.Width -= 20;
                if (sidebar.Width <= sidebar.MinimumSize.Width)
                {
                    sidebarExpanded = false;
                    sidebar_timer.Stop();
                }
            }
            else
            {
                sidebar.Width += 60;
                if (sidebar.Width >= sidebar.MaximumSize.Width)
                {
                    sidebarExpanded = true;
                    sidebar_timer.Stop();
                }
            }
        }

        private void button_menu_Click_1(object sender, EventArgs e)
        {
            sidebar_timer.Start();
        }

        private void buttonHome_Click_1(object sender, EventArgs e)
        {
            AbrirForm(new Form1());
        }

        private void buttonVenda_Click_1(object sender, EventArgs e)
        {
            AbrirForm(new Form_venda());
        }

        private void buttonCliente_Click_1(object sender, EventArgs e)
        {
            AbrirForm(new FormCliente());
        }

        private void buttonHistorico_Click(object sender, EventArgs e)
        {
            AbrirForm(new Form_historico());
        }

        // Método auxiliar para não repetir código de fechar e abrir
        private void AbrirForm(Form form)
        {
            form.Show();
            this.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}