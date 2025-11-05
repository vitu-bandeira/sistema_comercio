using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using sistema_comercio.sistema_comercio;

namespace sistema_comercio
{
    public partial class Form_venda : Form
    {
        
        private BindingList<ItemVenda> itensVenda = new BindingList<ItemVenda>();
        private decimal totalVenda = 0;
 

        public Form_venda()
        {
            InitializeComponent();
            ConfigurarComponentes();
            ConfigurarGrid();
            
            CarregarComboBox();

            CarregarComboBox(); // Carrega clientes

            CarregarComboBoxProduto(); // Carrega produtos

            // Vamos ajustar a linha do KeyDown no próximo passo
            // this.txtBusca.KeyDown += new KeyEventHandler(this.TxtBusca_KeyDown); 
            this.comboBoxProduto.KeyDown += new KeyEventHandler(this.ComboBoxProduto_KeyDown); // <-- AJUSTE AQUI
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
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
        private void ComboBoxProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarProduto();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            // Remova a parte do 'else if (e.KeyCode == Keys.Down...)' se tiver
        }
        // Este método vai dentro da sua classe Form_venda
        private void BuscarProduto()
        {
            // 1. Pega o texto digitado ou selecionado no ComboBox
            string termo = comboBoxProduto.Text.Trim();
            if (string.IsNullOrEmpty(termo)) return; // Se estiver vazio, não faz nada

            try
            {
                // 2. Chama o método do DALProdutos para buscar no banco de dados
                //    (Busca por código de barras OU nome)
                DataTable dt = DALProdutos.GetProdutoParaVenda(termo);

                // 3. Verifica se o banco de dados retornou algum produto
                if (dt.Rows.Count > 0)
                {
                    // Pega a primeira linha encontrada
                    DataRow row = dt.Rows[0];

                    // 4. Cria um objeto temporário com os detalhes do produto encontrado
                    var produto = new
                    {
                        Id = Convert.ToInt32(row["id"]),
                        Nome = row["nome"].ToString(),
                        Preco = Convert.ToDecimal(row["preco"]),
                        Estoque = Convert.ToInt32(row["estoque"]), // Pega o estoque atual
                        CodigoBarras = row["codigoBarras"].ToString()
                    };

                    // 5. Chama o método que abre a janelinha para perguntar a quantidade
                    MostrarDetalhesProduto(produto);
                }
                else
                {
                    // 6. Se não encontrou nada no banco, avisa o usuário
                    MessageBox.Show("Produto não encontrado!", "Aviso",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboBoxProduto.SelectAll(); // Seleciona o texto para facilitar a correção
                    comboBoxProduto.Focus();     // Devolve o foco para a busca
                }
            }
            catch (Exception ex)
            {
                // 7. Se der qualquer erro (ex: banco de dados desconectado), mostra a mensagem
                MessageBox.Show("Erro ao buscar produto: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ConfigurarComponentes()
        {
          

            if (lblTotalVenda != null)
            {
                lblTotalVenda.Text = "Total: R$ 0,00";
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

        private void MostrarDetalhesProduto(dynamic produto)
        {
            var frmQuantidade = new Form();
            frmQuantidade.Text = "Selecionar Quantidade";
            frmQuantidade.Size = new Size(300, 150);

            // Cria controle para seleção de quantidade
            NumericUpDown nudQuantidade = new NumericUpDown()
            {
                Minimum = 1,
                Maximum = produto.Estoque, // Limite máximo = estoque
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
            comboBoxProduto.Text = "";     // Limpa campo de busca
            comboBoxProduto.Focus();
            // Coloca foco no campo
        }

        private void CalcularTotalVenda()
        {
            totalVenda =  itensVenda.Sum(item => item.TotalItem);

            lblTotalVenda.Text = $"Total da venda: {totalVenda:C2}";
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
        
        private void TxtBusca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarProduto(); // Chama a sua função de busca

                // Estas duas linhas impedem o som de "bip" do Windows
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void CarregarComboBoxProduto()
        {
            try
            {
                comboBoxProduto.Items.Clear();

                DataTable produtos = DALProdutos.GetProdutos();

                foreach (DataRow row in produtos.Rows)
                {
                    string produtoNome = row["Nome"].ToString();
                    comboBoxProduto.Items.Add(produtoNome);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar produtos: " + ex.Message);
            }
        }

            private void comboBoxProduto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            // 1. Verifica se o carrinho não está vazio
            if (itensVenda.Count == 0)
            {
                MessageBox.Show("Adicione pelo menos um produto ao carrinho!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Pede confirmação
            var confirmResult = MessageBox.Show($"Valor total: {totalVenda:C2}\n\nDeseja finalizar a venda?",
                                                "Confirmar Venda",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.No)
            {
                return; // Usuário cancelou
            }

            try
            {
                // 3. (PARA CADA ITEM) Dá baixa no estoque
                foreach (var item in itensVenda)
                {
                    DALProdutos.AtualizarEstoque(item.ProdutoId, item.Quantidade);
                }

                // 4. (SE CLIENTE SELECIONADO) Adiciona o débito (fiado)
                if (comboBoxCliente.SelectedItem != null && !string.IsNullOrEmpty(comboBoxCliente.Text))
                {
                    string nomeCliente = comboBoxCliente.Text;
                    DALClientes.AdicionarDebito(nomeCliente, totalVenda);
                    MessageBox.Show("Venda finalizada e debitada para " + nomeCliente + "!");
                }
                else
                {
                    // 5. (SE FOR À VISTA) Apenas finaliza
                    MessageBox.Show("Venda à vista finalizada com sucesso!");
                }

                // 6. Limpa a tela para a próxima venda
                itensVenda.Clear();
                CalcularTotalVenda(); // Isso vai resetar o label do total para R$ 0,00
                comboBoxCliente.Text = "";
                comboBoxProduto.Text = "";
                comboBoxProduto.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao finalizar a venda:\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
