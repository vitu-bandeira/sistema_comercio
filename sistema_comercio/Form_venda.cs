using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema_comercio
{
    public partial class Form_venda : Form
    {
        private string connectionString = "Data Source=produtos.db;Version=3;";
        private BindingList<ItemVenda> itensVenda = new BindingList<ItemVenda>();
        private decimal totalVenda = 0;
        private Timer sugestoesTimer;
        private ListBox listBoxSugestoes;

        public Form_venda()
        {
            InitializeComponent();
            ConfigurarComponentes();
            ConfigurarGrid();
            InicializarSugestoes();
            CarregarComboBox();

        }

        private void InicializarSugestoes()
        {
            // Configura o ListBox de sugestões
            listBoxSugestoes = new ListBox
            {
                Visible = false,
                Location = new Point(txtBusca.Left, txtBusca.Bottom + 2),
                Width = txtBusca.Width,
                Font = txtBusca.Font,
                IntegralHeight = true,
                TabStop = false
            };
            this.Controls.Add(listBoxSugestoes);
            listBoxSugestoes.BringToFront();

            // Configura o Timer
            sugestoesTimer = new Timer { Interval = 300 };
            sugestoesTimer.Tick += SugestoesTimer_Tick;
        }
        private void CarregarComboBox()
        {
            try
            {
                comboBoxCliente.Items.Clear();

                DataTable clientes = DALClientes.GetClientes();

                foreach (DataRow row in clientes.Rows)
                {
                    string clienteNome = row["Nome"].ToString();
                    comboBoxCliente.Items.Add(clienteNome);

                }
            }
            catch (Exception ex)
            { 
                MessageBox.Show("Erro ao carregar clientes: " + ex.Message);
            }
        }
        private void ConfigurarComponentes()
        {
            if (listBoxSugestoes != null)
            {
                listBoxSugestoes.Click += ListBoxSugestoes_Click;
                listBoxSugestoes.KeyDown += ListBoxSugestoes_KeyDown;
            }

            if (txtBusca != null)
            {
                txtBusca.KeyDown += TxtBusca_KeyDown;
                txtBusca.TextChanged += TxtBusca_TextChanged;
            }

            if (lblTotalVenda != null)
            {
                lblTotalVenda.Text = "Total: R$ 0,00";
            }
        }

        private void TxtBusca_TextChanged(object sender, EventArgs e)
        {
            sugestoesTimer.Stop();
            sugestoesTimer.Start();
        }

        private async void SugestoesTimer_Tick(object sender, EventArgs e)
        {
            sugestoesTimer.Stop();

            if (txtBusca.Text.Length < 2)
            {
                listBoxSugestoes.Visible = false;
                return;
            }

            var sugestoes = await ObterSugestoesProdutos(txtBusca.Text);

            listBoxSugestoes.DataSource = sugestoes;
            listBoxSugestoes.Visible = sugestoes.Any();
        }

        private async Task<List<string>> ObterSugestoesProdutos(string termo)
        {
            var sugestoes = new List<string>();

            using (var conn = new SQLiteConnection(connectionString))
            {
                await conn.OpenAsync();
                const string sql = @"SELECT Nome FROM Produtos 
                                   WHERE Nome LIKE @termo 
                                   ORDER BY Nome 
                                   LIMIT 10";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@termo", $"{termo}%");

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            sugestoes.Add(reader["Nome"].ToString());
                        }
                    }
                }
            }
            return sugestoes;
        }

        private void ListBoxSugestoes_Click(object sender, EventArgs e)
        {
            if (listBoxSugestoes.SelectedItem != null)
            {
                txtBusca.Text = listBoxSugestoes.SelectedItem.ToString();
                listBoxSugestoes.Visible = false;
                BuscarProduto();
            }
        }

        private void ListBoxSugestoes_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    ListBoxSugestoes_Click(sender, e);
                    break;

                case Keys.Escape:
                    listBoxSugestoes.Visible = false;
                    txtBusca.Focus();
                    break;
            }
        }

        private void TxtBusca_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    listBoxSugestoes.Visible = false;
                    BuscarProduto();
                    break;

                case Keys.Down when listBoxSugestoes.Visible:
                    listBoxSugestoes.Focus();
                    break;
            }
        }


        private void ConfigurarGrid()
        {
            dataGridView1.AutoGenerateColumns = false; // Desativa geração automática de colunas
            dataGridView1.DataSource = itensVenda;      // Vincula à lista de itens

       
            dataGridView1.AutoGenerateColumns = false;

            // Coluna ID (oculta)
            DataGridViewTextBoxColumn colID = new DataGridViewTextBoxColumn();
            colID.Name = "ProdutoId"; // Nome explícito
            colID.DataPropertyName = "IdProduto";
            colID.HeaderText = "ID";
            colID.Visible = false;
            dataGridView1.Columns.Add(colID);

            // Coluna Nome
            DataGridViewTextBoxColumn colNome = new DataGridViewTextBoxColumn();
            colNome.Name = "Nome"; // Nome explícito
            colNome.DataPropertyName = "Nome";
            colNome.HeaderText = "Produto";
            colNome.Width = 300;
            dataGridView1.Columns.Add(colNome);

            // Coluna Código de Barras
            DataGridViewTextBoxColumn colCodigo = new DataGridViewTextBoxColumn();
            colCodigo.Name = "CodigoBarras"; // Nome explícito
            colCodigo.DataPropertyName = "CodigoBarras";
            colCodigo.HeaderText = "Código";
            colCodigo.Width = 200;
            dataGridView1.Columns.Add(colCodigo);


            // Coluna Quantidade
            DataGridViewTextBoxColumn colQuantidade = new DataGridViewTextBoxColumn();
            colQuantidade.Name = "Quantidade"; // Nome explícito
            colQuantidade.DataPropertyName = "Quantidade";
            colQuantidade.HeaderText = "Quant";
            colQuantidade.Width = 80;
            dataGridView1.Columns.Add(colQuantidade);
            colQuantidade.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            DataGridViewTextBoxColumn colPrecoUnitario = new DataGridViewTextBoxColumn();
            colPrecoUnitario.Name = "PrecoUnitario";
            colPrecoUnitario.HeaderText = "Preço.uni";
            colPrecoUnitario.DataPropertyName = "PrecoUnitario";
            colPrecoUnitario.Width = 150;
            dataGridView1.Columns.Add(colPrecoUnitario);
            colPrecoUnitario.DefaultCellStyle.Format = "C2";
            colPrecoUnitario.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewTextBoxColumn colTotalItem = new DataGridViewTextBoxColumn();
            colTotalItem.Name = "TotalItem";
            colTotalItem.HeaderText = "Total";
            colTotalItem.Width = 150;
            colTotalItem.DataPropertyName = "TotalItem";
            dataGridView1.Columns.Add(colTotalItem);
            colTotalItem.DefaultCellStyle.Format = "C2";
            colTotalItem.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;



            // Estilo do Grid
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 17);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 17, FontStyle.Bold);
            dataGridView1.RowTemplate.Height = 35;
        }

        private void BuscarProduto()
        {
            string termo = txtBusca.Text.Trim();

            using (var conn = new SQLiteConnection(connectionString))
            {
                
                    conn.Open();
                    // Consulta corrigida com tratamento de LIKE e parâmetros nomeados
                    string sql = @"SELECT * FROM Produtos 
                        WHERE CodigoBarras = @termoExato 
                        OR Nome LIKE @termoParcial";

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@termoExato", termo);
                        cmd.Parameters.AddWithValue("@termoParcial", $"%{termo}%");

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                var produto = new
                                {
                                    Id = Convert.ToInt32(reader["IdProduto"]),
                                    Nome = reader["Nome"].ToString(),
                                    Preco = Convert.ToDecimal(reader["Preco"]),
                                    Quantidade = Convert.ToInt32(reader["Quantidade"]),
                                    CodigoBarras = reader["CodigoBarras"].ToString()
                                };

                                MostrarDetalhesProduto(produto);
                            }
                            else
                            {
                                MessageBox.Show("Produto não encontrado!", "Aviso",
                                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                                // Foco e limpeza controlados
                                txtBusca.SelectAll();
                                txtBusca.Focus();
                            }
                        }
                    }
                
               
            }
        }
        private void MostrarDetalhesProduto(dynamic produto)
        {
            var frmQuantidade = new Form();
            frmQuantidade.Text = "Selecionar Quantidade";
            frmQuantidade.Size = new Size(300, 150);

            // Cria controle para seleção de quantidade
            NumericUpDown nudQuantidade = new NumericUpDown()
            {
                Minimum = 1,
                Maximum = produto.Quantidade, // Limite máximo = estoque
                Value = 1,
                Location = new Point(20, 20),
                Width = 100
            };

            Button btnConfirmar = new Button()
            {
                Text = "Adicionar",
                Location = new Point(20, 60)
            };

            nudQuantidade.KeyDown += (s, ke) =>
            {
                if (ke.KeyCode == Keys.Enter)
                {
                    AdicionarItemVenda(produto, (int)nudQuantidade.Value);
                    frmQuantidade.Close();
                }
            };  

            // Evento ao confirmar quantidade
            btnConfirmar.Click += (s, e) =>
            {
                AdicionarItemVenda(produto, (int)nudQuantidade.Value); // Adiciona o produto
                frmQuantidade.Close();  // Fecha a janela
            };

            

            frmQuantidade.Controls.Add(nudQuantidade);
            frmQuantidade.Controls.Add(btnConfirmar);
            frmQuantidade.ShowDialog(); // Mostra a janela modal
        }

        // Adiciona item à lista de vendas
        private void AdicionarItemVenda(dynamic produto, int quantidade)
        {
            // Verifica se item já está na lista
            var itemExistente = itensVenda.FirstOrDefault(i => i.ProdutoId == produto.Id);

            if (itemExistente != null)
            {
                itemExistente.Quantidade += quantidade;
                itensVenda.ResetBindings(); // Atualiza a lista


            }
            else
            {
                itensVenda.Add(new ItemVenda()
                {
                    ProdutoId = produto.Id,
                    CodigoBarras = produto.CodigoBarras,
                    Nome = produto.Nome,
                    Quantidade = quantidade,
                    PrecoUnitario = produto.Preco
                });
            }


            CalcularTotalVenda(); // Atualiza total
            txtBusca.Clear();     // Limpa campo de busca
            txtBusca.Focus();     // Coloca foco no campo
        }

        private void CalcularTotalVenda()
        {
            totalVenda =  itensVenda.Sum(item => item.TotalItem);

            lblTotalVenda.Text = $"Total da venda: {totalVenda:C2}";
        }

       

        


 

        public class ItemVenda
        {
            public int ProdutoId { get; set; }
            public string CodigoBarras { get; set; }
            public string Nome { get; set; }
            public int Quantidade { get; set; }
            public decimal PrecoUnitario { get; set; }
            public decimal TotalItem => Quantidade * PrecoUnitario; // Propriedade calculada
        }

       

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form_venda_Load(object sender, EventArgs e)
        {

        }

        bool sidebarExpanded = true;
        private void sidebar_timer_Tick(object sender, EventArgs e)
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

        private void button_menu_Click_1(object sender, EventArgs e)
        {
            sidebar_timer.Start();
        }

        

        private void buttonHome_Click_1(object sender, EventArgs e)
        {
            Form1 newF = new Form1();
            newF.Show();
            this.Close();
        }

        private void buttonEstoque_Click_1(object sender, EventArgs e)
        {
            FormProduto produto = new FormProduto();
            produto.Show();
            this.Close();
        }

        private void buttonCliente_Click_1(object sender, EventArgs e)
        {
            FormCliente cliente = new FormCliente();
            cliente.Show();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
