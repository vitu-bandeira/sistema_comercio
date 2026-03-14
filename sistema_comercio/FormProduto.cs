using SistemaComercio.Aplication;
using SistemaComercio.Dominio;
using SistemaComercio.Infrastructure;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace sistema_comercio
{
    public partial class FormProduto : Form
    {
        // 1. O Vendedor (Tela) contrata o Gerente!
        private readonly IProdutoService _produtoService;
        bool sidebarExpanded = true;

        public FormProduto()
        {
            InitializeComponent();
            ConfigurarGrid();
            this.WindowState = FormWindowState.Maximized;

            // Associação de eventos manuais
            this.btn_adicionar.Click += new EventHandler(this.btn_adicionar_Click);
            dataGridView1.CellClick += dataGridView1_CellClick;

            // 2. INJEÇÃO DE DEPENDÊNCIA (Preparando a equipe)
            string caminhoBanco = Directory.GetCurrentDirectory() + "\\banco.sqlite";
            string connectionString = "Data Source=" + caminhoBanco;

            // Instancia o Repositório (Estoquista) e injeta no Service (Gerente)
            IProdutosRepository repositorio = new ProdutoRepository(connectionString);
            _produtoService = new ProdutoService(repositorio);
        }

        private void FormProduto_Load(object sender, EventArgs e)
        {
            try
            {
                // A tela abre, pede os dados para o Gerente e carrega o visual
                ExibirDados();
                CarregarCards();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar sistema: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- MÉTODOS DE DADOS USANDO O GERENTE ---

        private void ExibirDados()
        {
            try
            {
                var produtos = _produtoService.ObterTodosProdutos().ToList();
                dataGridView1.DataSource = produtos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao exibir os dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarCards()
        {
            try
            {
                lblValorTotal.Text = _produtoService.ObterValorTotalEstoque().ToString("C2");
                lblValorTotal.ForeColor = Color.Green;

                int baixo = _produtoService.ObterContagemEstoqueBaixo(10);
                lblEstoqueBaixo.Text = baixo.ToString();
                lblEstoqueBaixo.ForeColor = baixo > 0 ? Color.Red : Color.Gray;

                lblQtdProdutos.Text = _produtoService.ObterTotalProdutosCadastrados().ToString();
            }
            catch { }
        }

        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string busca = textBoxBuscar.Text.Trim();
                var produtosFiltrados = _produtoService.BuscarProdutosPorNome(busca).ToList();
                dataGridView1.DataSource = produtosFiltrados;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                DataPropertyName = "Id", // Propriedade com "I" maiúsculo igual à classe Produto
                HeaderText = "ID",
                Visible = false
            });

            // Nome
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "nome",
                DataPropertyName = "Nome",
                HeaderText = "Produto",
                Width = 300,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill // Deixa o nome esticar
            });

            // Código
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "codigoBarras",
                DataPropertyName = "CodigoBarras",
                HeaderText = "Código",
                Width = 200
            });

            // Preço
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "preco",
                DataPropertyName = "Preco",
                HeaderText = "Preço",
                Width = 130,
                DefaultCellStyle = { Format = "C2" }
            });

            // Estoque
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "estoque",
                DataPropertyName = "Estoque",
                HeaderText = "Estoque",
                Width = 120
            });

            // Validade
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "validade",
                DataPropertyName = "Validade",
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
                Produto produto = new Produto();
                produto.Id = Convert.ToInt32(row.Cells["id"].Value);
                produto.Nome = row.Cells["nome"].Value.ToString();
                produto.CodigoBarras = row.Cells["codigoBarras"].Value != null ? row.Cells["codigoBarras"].Value.ToString() : null;
                produto.Preco = Convert.ToDecimal(row.Cells["preco"].Value);
                produto.Estoque = Convert.ToInt32(row.Cells["estoque"].Value);

                if (row.Cells["validade"].Value != null)
                    produto.Validade = Convert.ToDateTime(row.Cells["validade"].Value);

                using (Form_DetalheProduto formEdit = new Form_DetalheProduto(produto))
                {
                    if (formEdit.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            _produtoService.AtualizarProduto(formEdit.Produto);
                            MessageBox.Show("Produto atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ExibirDados();
                            CarregarCards();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao atualizar: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                var confirm = MessageBox.Show("Deseja realmente excluir este produto?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    _produtoService.ExcluirProduto(id);
                    MessageBox.Show("Produto excluído!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ExibirDados();
                    CarregarCards();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- BOTÃO ADICIONAR ---
        private void btn_adicionar_Click(object sender, EventArgs e)
        {
            using (Form_DetalheProduto formAdd = new Form_DetalheProduto(null))
            {
                if (formAdd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _produtoService.AdicionarProduto(formAdd.Produto);
                        MessageBox.Show("Produto adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ExibirDados();
                        CarregarCards();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao salvar: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        // --- MENU E NAVEGAÇÃO ---

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
            AbrirForm(new Form_venda()); // Se esse form já tiver sido renomeado, ajuste aqui
        }

        private void buttonCliente_Click_1(object sender, EventArgs e)
        {
            AbrirForm(new FormCliente()); // Se esse form já tiver sido renomeado, ajuste aqui
        }

        private void buttonHistorico_Click(object sender, EventArgs e)
        {
            AbrirForm(new Form_historico());
        }

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