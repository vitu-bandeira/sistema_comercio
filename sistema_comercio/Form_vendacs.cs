// Cole este código completo no seu Form_venda.cs
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
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
            ConfigurarGrid();
            CarregarComboBoxClientes();
            CarregarComboBoxProdutos();
            ConfigurarEventosPagamento(); // Este método agora está VAZIO e é seguro
        }

        private void Form_venda_Load(object sender, EventArgs e)
        {
            // Limpa a venda e foca no produto
            LimparVenda();
            comboBoxProduto.Select();
            this.KeyPreview = true; // Garante que o Form intercepte as teclas (F1, F5, etc)
        }

        // Este método deve ficar VAZIO, pois o Designer.cs já está ligando os eventos
        private void ConfigurarEventosPagamento()
        {
        }

        #region Configuração e Carregamento de Dados

        private void CarregarComboBoxClientes()
        {
            try
            {
                comboBoxCliente.Items.Clear();
                DataTable clientes = DALClientes.GetClientes();

                // Opção "À Vista" não é mais necessária, pois "Fiado" é uma escolha explícita
                // comboBoxCliente.Items.Add("À Vista"); 

                foreach (DataRow row in clientes.Rows)
                {
                    comboBoxCliente.Items.Add(row["Nome"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar clientes: " + ex.Message);
            }
        }

        private void CarregarComboBoxProdutos()
        {
            try
            {
                comboBoxProduto.Items.Clear();
                DataTable produtos = DALProdutos.GetProdutos();
                foreach (DataRow row in produtos.Rows)
                {
                    comboBoxProduto.Items.Add(row["Nome"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar produtos: " + ex.Message);
            }
        }

        private void ConfigurarGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = itensVenda;

            // Fontes e Altura (do seu último pedido)
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 14);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.EnableHeadersVisualStyles = false; // Garante que nosso estilo de cabeçalho funcione

            // Coluna ID (oculta)
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ProdutoId",
                DataPropertyName = "ProdutoId",
                Visible = false
            });

            // ... (Colunas Nome, Quantidade, PrecoUnitario, TotalItem - sem alteração) ...
            // Coluna Nome (50% do espaço)
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nome",
                DataPropertyName = "Nome",
                HeaderText = "Produto",
                FillWeight = 50
            });

            // Coluna Quantidade (10% do espaço)
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Quantidade",
                DataPropertyName = "Quantidade",
                HeaderText = "Qtd.",
                FillWeight = 10,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // Coluna Preço Unitário (15% do espaço)
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PrecoUnitario",
                DataPropertyName = "PrecoUnitario",
                HeaderText = "Preço Unit.",
                FillWeight = 15,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            // Coluna Total (15% do espaço)
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TotalItem",
                DataPropertyName = "TotalItem",
                HeaderText = "Total",
                FillWeight = 15,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight }
            });


            // --- COLUNAS DE BOTÃO (COM A CORREÇÃO) ---

            // Coluna Diminuir (-)
            DataGridViewButtonColumn colDiminuir = new DataGridViewButtonColumn();
            colDiminuir.Name = "Diminuir";
            colDiminuir.HeaderText = "";
            colDiminuir.Text = "-";
            colDiminuir.UseColumnTextForButtonValue = true;
            colDiminuir.FillWeight = 5;
            colDiminuir.FlatStyle = FlatStyle.Flat; // Importante para a cor de fundo
            colDiminuir.DefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
           
            dataGridView1.Columns.Add(colDiminuir);

            // Coluna Aumentar (+)
            DataGridViewButtonColumn colAumentar = new DataGridViewButtonColumn();
            colAumentar.Name = "Aumentar";
            colAumentar.HeaderText = "";
            colAumentar.Text = "+";
            colAumentar.UseColumnTextForButtonValue = true;
            colAumentar.FillWeight = 5;
            colAumentar.FlatStyle = FlatStyle.Flat; // Importante para a cor de fundo
            colAumentar.DefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            // --- CORREÇÃO AQUI ---
                                                                              // --- FIM DA CORREÇÃO ---
            dataGridView1.Columns.Add(colAumentar);

            // Coluna Remover (Lixeira)
            DataGridViewButtonColumn colRemover = new DataGridViewButtonColumn();
            colRemover.Name = "Remover";
            colRemover.HeaderText = "";
            colRemover.Text = "🗑";
            colRemover.UseColumnTextForButtonValue = true;
            colRemover.FillWeight = 5;
            colRemover.FlatStyle = FlatStyle.Flat;
            colRemover.DefaultCellStyle.Font = new Font("Segoe UI", 12);
            dataGridView1.Columns.Add(colRemover);

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        #endregion

        #region Lógica do Carrinho (Adicionar / Remover / Buscar)

        private void ComboBoxProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarProduto();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void BuscarProduto()
        {
            string termo = comboBoxProduto.Text.Trim();
            if (string.IsNullOrEmpty(termo)) return;

            try
            {
                DataTable dt = DALProdutos.GetProdutoParaVenda(termo);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    var produto = new
                    {
                        Id = Convert.ToInt32(row["id"]),
                        Nome = row["nome"].ToString(),
                        Preco = Convert.ToDecimal(row["preco"]),
                        Estoque = Convert.ToInt32(row["estoque"]),
                        CodigoBarras = row["codigoBarras"].ToString()
                    };

                    MostrarDetalhesProduto(produto);
                }
                else
                {
                    MessageBox.Show("Produto não encontrado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboBoxProduto.SelectAll();
                    comboBoxProduto.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar produto: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarDetalhesProduto(dynamic produto)
        {
            using (var frmQuantidade = new Form())
            {
                frmQuantidade.Text = "Selecionar Quantidade";
                frmQuantidade.Size = new Size(300, 150);
                frmQuantidade.StartPosition = FormStartPosition.CenterScreen;

                NumericUpDown nudQuantidade = new NumericUpDown()
                {
                    Minimum = 1,
                    Maximum = produto.Estoque,
                    Value = 1,
                    Location = new Point(20, 20),
                    Width = 100,
                    Font = new Font("Segoe UI", 12)
                };

                Button btnConfirmar = new Button()
                {
                    Text = "Adicionar",
                    Location = new Point(20, 60),
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                };

                nudQuantidade.KeyDown += (s, ke) =>
                {
                    if (ke.KeyCode == Keys.Enter)
                    {
                        AdicionarItemVenda(produto, (int)nudQuantidade.Value);
                        frmQuantidade.Close();
                    }
                };

                btnConfirmar.Click += (s, e) =>
                {
                    AdicionarItemVenda(produto, (int)nudQuantidade.Value);
                    frmQuantidade.Close();
                };

                frmQuantidade.Controls.Add(nudQuantidade);
                frmQuantidade.Controls.Add(btnConfirmar);
                frmQuantidade.ShowDialog();
            }
        }

        private void AdicionarItemVenda(dynamic produto, int quantidade)
        {
            var itemExistente = itensVenda.FirstOrDefault(i => i.ProdutoId == produto.Id);

            if (itemExistente != null)
            {
                // Verifica se a SOMA não ultrapassa o estoque
                int novaQtde = itemExistente.Quantidade + quantidade;
                if (novaQtde > itemExistente.EstoqueDisponivel)
                {
                    MessageBox.Show($"Estoque máximo atingido ({itemExistente.EstoqueDisponivel} unidades)!", "Estoque Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    itemExistente.Quantidade = itemExistente.EstoqueDisponivel; // Trava no máximo
                }
                else
                {
                    itemExistente.Quantidade = novaQtde;
                }

                itensVenda.ResetBindings(); // Atualiza a lista
            }
            else
            {
                // Salva o estoque disponível na primeira vez que o item é adicionado
                itensVenda.Add(new ItemVenda()
                {
                    ProdutoId = produto.Id,
                    CodigoBarras = produto.CodigoBarras,
                    Nome = produto.Nome,
                    Quantidade = quantidade,
                    PrecoUnitario = produto.Preco,
                    EstoqueDisponivel = produto.Estoque // <-- SALVA O ESTOQUE AQUI
                });
            }

            CalcularTotalVenda();
            comboBoxProduto.Text = "";
            comboBoxProduto.Focus();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            ItemVenda itemSelecionado = (ItemVenda)dataGridView1.Rows[e.RowIndex].DataBoundItem;
            bool dadosAlterados = false;

            if (colName == "Aumentar")
            {
                // --- VERIFICAÇÃO DE ESTOQUE ---
                if (itemSelecionado.Quantidade < itemSelecionado.EstoqueDisponivel)
                {
                    itemSelecionado.Quantidade++;
                    dadosAlterados = true;
                }
                else
                {
                    // Apenas avisa o usuário
                    MessageBox.Show($"Estoque máximo atingido ({itemSelecionado.EstoqueDisponivel} unidades)!", "Limite Atingido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (colName == "Diminuir")
            {
                if (itemSelecionado.Quantidade > 1)
                {
                    itemSelecionado.Quantidade--;
                    dadosAlterados = true;
                }
                else if (itemSelecionado.Quantidade == 1)
                {
                    itensVenda.Remove(itemSelecionado);
                    dadosAlterados = true;
                }
            }
            else if (colName == "Remover")
            {
                itensVenda.Remove(itemSelecionado);
                dadosAlterados = true;
            }

            if (dadosAlterados)
            {
                itensVenda.ResetBindings();
                CalcularTotalVenda();
            }
        }

        #endregion

        #region Lógica de Pagamento e Finalização

        private void CalcularTotalVenda()
        {
            totalVenda = itensVenda.Sum(item => item.TotalItem);
            lblTotalValor.Text = totalVenda.ToString("C2");
            CalcularTroco();
        }

        private void rbPagamento_CheckedChanged(object sender, EventArgs e)
        {
            panelCliente.Visible = rbFiado.Checked;
            panelTroco.Visible = rbDinheiro.Checked;

            if (rbFiado.Checked)
            {
                comboBoxCliente.Focus();
            }
            else if (rbDinheiro.Checked)
            {
                txtValorRecebido.Focus();
                txtValorRecebido.SelectAll();
            }
        }

        private void txtValorRecebido_TextChanged(object sender, EventArgs e)
        {
            CalcularTroco();
        }

        private void CalcularTroco()
        {
            // CORREÇÃO: Adiciona verificação de nulo
            if (txtValorRecebido == null) return;
            string textoValor = txtValorRecebido.Text ?? ""; // Protege contra null

            if (decimal.TryParse(textoValor.Replace("R$", "").Trim(), out decimal recebido))
            {
                decimal troco = recebido - totalVenda;
                if (troco < 0)
                {
                    lblTrocoValor.ForeColor = Color.Red;
                    lblTrocoValor.Text = troco.ToString("C2");
                }
                else
                {
                    lblTrocoValor.ForeColor = Color.MediumBlue;
                    lblTrocoValor.Text = troco.ToString("C2");
                }
            }
            else
            {
                lblTrocoValor.Text = "R$ 0,00";
            }
        }

        private void btnFinalizarVenda_Click(object sender, EventArgs e)
        {
            FinalizarVenda();
        }

        private void FinalizarVenda()
        {
            if (itensVenda.Count == 0)
            {
                MessageBox.Show("Adicione pelo menos um produto ao carrinho!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (rbFiado.Checked)
            {
                if (comboBoxCliente.SelectedItem == null || string.IsNullOrEmpty(comboBoxCliente.Text))
                {
                    MessageBox.Show("Selecione um cliente para registrar a venda 'fiado'!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBoxCliente.Focus();
                    return;
                }
            }
            else if (rbDinheiro.Checked)
            {
                string textoValor = txtValorRecebido.Text ?? "";
                if (!decimal.TryParse(textoValor.Replace("R$", "").Trim(), out decimal recebido) || recebido < totalVenda)
                {
                    MessageBox.Show("Valor recebido é insuficiente para pagar o total da venda!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtValorRecebido.Focus();
                    txtValorRecebido.SelectAll();
                    return;
                }
            }

            var confirmResult = MessageBox.Show($"Valor total: {totalVenda:C2}\n\nDeseja finalizar a venda?",
                                                "Confirmar Venda",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.No) return;

            try
            {
                foreach (var item in itensVenda)
                {
                    DALProdutos.AtualizarEstoque(item.ProdutoId, item.Quantidade);
                }

                Venda novaVenda = new Venda();
                novaVenda.DataVenda = DateTime.Now;
                novaVenda.ValorTotal = totalVenda;
                novaVenda.IdCliente = null;

                string msgSucesso = "Venda finalizada com sucesso!";

                if (rbFiado.Checked)
                {
                    string nomeCliente = comboBoxCliente.Text;
                    DALClientes.AdicionarDebito(nomeCliente, totalVenda);
                    novaVenda.IdCliente = DALClientes.GetClienteIdPorNome(nomeCliente);
                    msgSucesso = "Venda finalizada e debitada para " + nomeCliente + "!";
                }
                else if (rbDinheiro.Checked)
                {
                    msgSucesso = $"Venda finalizada!\nTROCO: {lblTrocoValor.Text}";
                }

                DALVendas.RegistrarVenda(novaVenda, itensVenda.ToList());

                MessageBox.Show(msgSucesso, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparVenda();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao finalizar a venda:\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarVenda_Click(object sender, EventArgs e)
        {
            if (itensVenda.Count > 0)
            {
                var confirm = MessageBox.Show("Deseja realmente cancelar a venda atual?", "Cancelar Venda", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    LimparVenda();
                }
            }
            else
            {
                LimparVenda();
            }
        }

        private void LimparVenda()
        {
            itensVenda.Clear();
            CalcularTotalVenda();
            comboBoxCliente.Text = "";
            comboBoxProduto.Text = "";
            txtValorRecebido.Text = "0,00";
            lblTrocoValor.Text = "R$ 0,00";
            rbDinheiro.Checked = true;
            comboBoxProduto.Focus();
        }

        #endregion

        #region Atalhos de Teclado (F-Keys)

        private void Form_venda_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    rbDinheiro.Checked = true;
                    e.Handled = true;
                    break;
                case Keys.F2:
                    rbCartao.Checked = true;
                    e.Handled = true;
                    break;
                case Keys.F3:
                    rbPix.Checked = true;
                    e.Handled = true;
                    break;
                case Keys.F4:
                    rbFiado.Checked = true;
                    e.Handled = true;
                    break;
                case Keys.F5:
                    FinalizarVenda();
                    e.Handled = true;
                    break;
                case Keys.Escape:
                    btnCancelarVenda_Click(sender, e);
                    e.Handled = true;
                    break;
            }
        }

        #endregion

        #region Formatação de TextBox (Troco)

        private void txtValorRecebido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtValorRecebido_Enter(object sender, EventArgs e)
        {
            txtValorRecebido.SelectAll();
        }

        private void txtValorRecebido_Leave(object sender, EventArgs e)
        {
            string textoValor = txtValorRecebido.Text ?? "0";
            if (decimal.TryParse(textoValor.Replace("R$", "").Trim(), out decimal valor))
            {
                txtValorRecebido.Text = valor.ToString("N2");
            }
            else
            {
                txtValorRecebido.Text = "0,00";
            }
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

        #endregion

        #region Navegação e Sidebar (Seu código existente)

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

        #endregion

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonHistorico_Click(object sender, EventArgs e)
        {
            Form_historico historico = new Form_historico();
            historico.Show();
            this.Hide();
        }

        private void buttonHistorico_Click_1(object sender, EventArgs e)
        {
            Form_historico historico = new Form_historico();
            historico.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
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
    }
}