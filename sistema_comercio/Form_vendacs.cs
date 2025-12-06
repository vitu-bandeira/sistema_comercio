using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using QRCoder;
using sistema_comercio.sistema_comercio;
using QRCoder;

namespace sistema_comercio
{
    public partial class Form_venda : Form
    {
        // Lista que mantém os dados do Grid em tempo real
        private BindingList<ItemVenda> itensVenda = new BindingList<ItemVenda>();
        private decimal totalVenda = 0;

        public Form_venda()
        {
            InitializeComponent();

            // 1. Configurações Visuais e de Dados
            ConfigurarGrid();
            CarregarComboBoxClientes();
            CarregarComboBoxProdutos();

            // 2. RECONEXÃO DE EVENTOS (A "Cola" para fazer tudo voltar a funcionar)
            // Isso garante que seus botões funcionem mesmo se o Designer tiver perdido a referência
            ConfigurarEventosPagamento();
            ConfigurarNavegacao();
        }

        private void Form_venda_Load(object sender, EventArgs e)
        {
            LimparVenda();
            comboBoxProduto.Select();
            this.KeyPreview = true; // Importante para os atalhos (F1, F5, ESC) funcionarem
        }

        // --- AQUI ESTÁ A CORREÇÃO PRINCIPAL ---
        // Este método força o código a "ouvir" os botões, corrigindo o problema do design
        private void ConfigurarEventosPagamento()
        {
            // Eventos de Pagamento
            this.rbDinheiro.CheckedChanged += new EventHandler(this.rbPagamento_CheckedChanged);
            this.rbCartao.CheckedChanged += new EventHandler(this.rbPagamento_CheckedChanged);
            this.rbFiado.CheckedChanged += new EventHandler(this.rbPagamento_CheckedChanged);

            // LÓGICA DO PIX
            this.rbPix.CheckedChanged += (s, e) =>
            {
                this.rbPagamento_CheckedChanged(s, e); // Chama a lógica de esconder/mostrar outros painéis

                if (rbPix.Checked)
                {
                    GerarEMostrarPix(); // Mostra o painel que desenhamos
                }
                else
                {
                    panelPix.Visible = false; // Esconde se mudar para Dinheiro/Cartão
                }
            };

            // Outros eventos normais...
            this.txtValorRecebido.TextChanged += new EventHandler(this.txtValorRecebido_TextChanged);
            this.txtValorRecebido.KeyPress += new KeyPressEventHandler(this.txtValorRecebido_KeyPress);
            this.txtValorRecebido.Leave += new EventHandler(this.txtValorRecebido_Leave);
            this.btnFinalizarVenda.Click += new EventHandler(this.btnFinalizarVenda_Click);
            this.btnCancelarVenda.Click += new EventHandler(this.btnCancelarVenda_Click);
            this.comboBoxProduto.KeyDown += new KeyEventHandler(this.ComboBoxProduto_KeyDown);
        }

        

        private void ConfigurarNavegacao()
        {
            // Reconecta os botões da barra lateral (Sidebar)
            this.buttonHome.Click += new EventHandler(this.buttonHome_Click_1);
            this.buttonEstoque.Click += new EventHandler(this.buttonEstoque_Click_1);
            this.buttonCliente.Click += new EventHandler(this.buttonCliente_Click_1);
            this.buttonHistorico.Click += new EventHandler(this.buttonHistorico_Click_1);
            this.button_menu.Click += new EventHandler(this.button_menu_Click_1);
            this.button1.Click += new EventHandler(this.button1_Click); // Botão Sair
        }

        #region Configuração e Carregamento de Dados

        private void CarregarComboBoxClientes()
        {
            try
            {
                comboBoxCliente.Items.Clear();
                DataTable clientes = DALClientes.GetClientes();
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
        private void GerarEMostrarPix()
        {
            if (totalVenda <= 0)
            {
                MessageBox.Show("Não há valor para gerar o Pix!");
                rbDinheiro.Checked = true; // Volta para dinheiro
                return;
            }

            try
            {
                // 1. Centraliza o painel na tela (caso a janela tenha mudado de tamanho)
                panelPix.Location = new Point(
                    (this.ClientSize.Width - panelPix.Width) / 2,
                    (this.ClientSize.Height - panelPix.Height) / 2
                );

                // 2. Gera o Texto Copia e Cola
                string codigoPix = GeradorPix.GerarCopiaCola(totalVenda);
                txtCopiaCola.Text = codigoPix;

                // 3. Gera a Imagem (OFFLINE)
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(codigoPix, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(10);

                pbQrCode.Image = qrCodeImage;

                // 4. Mostra o Painel
                panelPix.Visible = true;
                panelPix.BringToFront(); // Garante que fique na frente de tudo
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar Pix: " + ex.Message);
                panelPix.Visible = false;
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

            // Estilo Visual
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 12);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.EnableHeadersVisualStyles = false;

            // Limpa colunas anteriores para não duplicar
            dataGridView1.Columns.Clear();

            // --- Criação das Colunas ---

            // ID Oculto
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "ProdutoId", DataPropertyName = "ProdutoId", Visible = false });

            // Nome do Produto
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nome",
                DataPropertyName = "Nome",
                HeaderText = "Produto",
                FillWeight = 45,
                ReadOnly = true
            });

            // Quantidade
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Quantidade",
                DataPropertyName = "Quantidade",
                HeaderText = "Qtd.",
                FillWeight = 10,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter },
                ReadOnly = true
            });

            // Preço Unitário
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PrecoUnitario",
                DataPropertyName = "PrecoUnitario",
                HeaderText = "Preço Unit.",
                FillWeight = 15,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight },
                ReadOnly = true
            });

            // Total
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TotalItem",
                DataPropertyName = "TotalItem",
                HeaderText = "Total",
                FillWeight = 15,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight },
                ReadOnly = true
            });

            // --- Botões de Ação ---

            // Botão Diminuir (-)
            DataGridViewButtonColumn colDiminuir = new DataGridViewButtonColumn();
            colDiminuir.Name = "Diminuir";
            colDiminuir.HeaderText = "";
            colDiminuir.Text = "-";
            colDiminuir.UseColumnTextForButtonValue = true;
            colDiminuir.FillWeight = 5;
            colDiminuir.FlatStyle = FlatStyle.Flat;
            dataGridView1.Columns.Add(colDiminuir);

            // Botão Aumentar (+)
            DataGridViewButtonColumn colAumentar = new DataGridViewButtonColumn();
            colAumentar.Name = "Aumentar";
            colAumentar.HeaderText = "";
            colAumentar.Text = "+";
            colAumentar.UseColumnTextForButtonValue = true;
            colAumentar.FillWeight = 5;
            colAumentar.FlatStyle = FlatStyle.Flat;
            dataGridView1.Columns.Add(colAumentar);

            // Botão Remover (Lixeira)
            DataGridViewButtonColumn colRemover = new DataGridViewButtonColumn();
            colRemover.Name = "Remover";
            colRemover.HeaderText = "";
            colRemover.Text = "🗑";
            colRemover.UseColumnTextForButtonValue = true;
            colRemover.FillWeight = 5;
            colRemover.FlatStyle = FlatStyle.Flat;
            colRemover.DefaultCellStyle.ForeColor = Color.Red;
            dataGridView1.Columns.Add(colRemover);

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Reconecta o evento de clique na célula do grid
            dataGridView1.CellClick -= dataGridView1_CellClick; // Remove para evitar duplicidade
            dataGridView1.CellClick += dataGridView1_CellClick;
        }
        #endregion

        #region Lógica do Carrinho (Adicionar / Remover / Buscar)

        private void ComboBoxProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarProduto();
                e.Handled = true;
                e.SuppressKeyPress = true; // Remove o "bip" do Windows
            }
        }

        private void BuscarProduto()
        {
            string termo = comboBoxProduto.Text.Trim();
            if (string.IsNullOrEmpty(termo)) return;

            try
            {
                // Busca no Banco de Dados
                DataTable dt = DALProdutos.GetProdutoParaVenda(termo);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    // Cria um objeto anônimo ou DTO simples para passar os dados
                    var produto = new
                    {
                        Id = Convert.ToInt32(row["id"]),
                        Nome = row["nome"].ToString(),
                        Preco = Convert.ToDecimal(row["preco"]),
                        Estoque = Convert.ToInt32(row["estoque"]),
                        CodigoBarras = row["codigoBarras"].ToString()
                    };

                    // Se tiver estoque, mostra o pop-up de quantidade
                    if (produto.Estoque > 0)
                    {
                        MostrarDetalhesProduto(produto);
                    }
                    else
                    {
                        MessageBox.Show($"O produto '{produto.Nome}' está sem estoque!", "Estoque Zerado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
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
            // Cria um formulário temporário (Pop-up) para pedir a quantidade
            using (var frmQuantidade = new Form())
            {
                frmQuantidade.Text = "Qtd";
                frmQuantidade.Size = new Size(250, 140);
                frmQuantidade.StartPosition = FormStartPosition.CenterScreen;
                frmQuantidade.FormBorderStyle = FormBorderStyle.FixedDialog;
                frmQuantidade.MaximizeBox = false;
                frmQuantidade.MinimizeBox = false;

                Label lblQtd = new Label() { Text = "Quantidade:", Location = new Point(15, 15), AutoSize = true };

                NumericUpDown nudQuantidade = new NumericUpDown()
                {
                    Minimum = 1,
                    Maximum = produto.Estoque, // Limita ao estoque máximo
                    Value = 1,
                    Location = new Point(15, 40),
                    Width = 200,
                    Font = new Font("Segoe UI", 12)
                };

                Button btnConfirmar = new Button()
                {
                    Text = "Adicionar (Enter)",
                    Location = new Point(15, 80),
                    Width = 200,
                    DialogResult = DialogResult.OK,
                    BackColor = Color.LimeGreen,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat
                };

                // Atalho: Enter confirma
                frmQuantidade.AcceptButton = btnConfirmar;

                frmQuantidade.Controls.Add(lblQtd);
                frmQuantidade.Controls.Add(nudQuantidade);
                frmQuantidade.Controls.Add(btnConfirmar);

                if (frmQuantidade.ShowDialog() == DialogResult.OK)
                {
                    AdicionarItemVenda(produto, (int)nudQuantidade.Value);
                }
            }
        }

        private void AdicionarItemVenda(dynamic produto, int quantidade)
        {
            // Verifica se o item já está no carrinho
            var itemExistente = itensVenda.FirstOrDefault(i => i.ProdutoId == produto.Id);

            if (itemExistente != null)
            {
                // Verifica se a soma (atual + novo) ultrapassa o estoque
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
                itensVenda.ResetBindings(); // Atualiza a tela
            }
            else
            {
                // Novo item no carrinho
                itensVenda.Add(new ItemVenda()
                {
                    ProdutoId = produto.Id,
                    CodigoBarras = produto.CodigoBarras,
                    Nome = produto.Nome,
                    Quantidade = quantidade,
                    PrecoUnitario = produto.Preco,
                    EstoqueDisponivel = produto.Estoque // Guarda o estoque para validações futuras
                });
            }

            CalcularTotalVenda();

            // Limpa e foca para o próximo produto
            comboBoxProduto.Text = "";
            comboBoxProduto.Focus();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Ignora cliques no cabeçalho

            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            ItemVenda itemSelecionado = (ItemVenda)dataGridView1.Rows[e.RowIndex].DataBoundItem;
            bool dadosAlterados = false;

            if (colName == "Aumentar")
            {
                // Verifica estoque antes de aumentar
                if (itemSelecionado.Quantidade < itemSelecionado.EstoqueDisponivel)
                {
                    itemSelecionado.Quantidade++;
                    dadosAlterados = true;
                }
                else
                {
                    MessageBox.Show("Estoque máximo atingido!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (colName == "Diminuir")
            {
                if (itemSelecionado.Quantidade > 1)
                {
                    itemSelecionado.Quantidade--;
                    dadosAlterados = true;
                }
                else
                {
                    // Se diminuir de 1, pergunta se quer remover
                    if (MessageBox.Show("Remover item do carrinho?", "Remover", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        itensVenda.Remove(itemSelecionado);
                        dadosAlterados = true;
                    }
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
            CalcularTroco(); // Recalcula o troco caso o total mude
        }

        private void rbPagamento_CheckedChanged(object sender, EventArgs e)
        {
            // Controla visibilidade e foco baseados no tipo de pagamento
            panelCliente.Visible = rbFiado.Checked;

            // Se é dinheiro, habilita campo de troco. Se não, desabilita ou limpa.
            if (rbDinheiro.Checked)
            {
                txtValorRecebido.Enabled = true;
                txtValorRecebido.Text = "0,00";
                txtValorRecebido.Focus();
                txtValorRecebido.SelectAll();
            }
            else
            {
                txtValorRecebido.Enabled = false; // Não precisa de troco para Pix/Cartão/Fiado
                txtValorRecebido.Text = totalVenda.ToString("N2"); // Preenche automático
                lblTrocoValor.Text = "R$ 0,00";

                if (rbFiado.Checked) comboBoxCliente.Focus();
            }
        }

        private void txtValorRecebido_TextChanged(object sender, EventArgs e)
        {
            CalcularTroco();
        }

        private void CalcularTroco()
        {
            if (!rbDinheiro.Checked) return; // Só calcula troco para dinheiro

            string textoValor = txtValorRecebido.Text.Replace("R$", "").Trim();
            if (decimal.TryParse(textoValor, out decimal recebido))
            {
                decimal troco = recebido - totalVenda;
                if (troco < 0)
                {
                    lblTrocoValor.ForeColor = Color.Red; // Falta dinheiro
                    lblTrocoValor.Text = "Faltam " + Math.Abs(troco).ToString("C2");
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
            // 1. Validações Básicas
            if (itensVenda.Count == 0)
            {
                MessageBox.Show("Carrinho vazio!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validações Específicas de Pagamento
            if (rbFiado.Checked)
            {
                if (string.IsNullOrEmpty(comboBoxCliente.Text))
                {
                    MessageBox.Show("Selecione um cliente para vender fiado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBoxCliente.Focus();
                    return;
                }
            }
            else if (rbDinheiro.Checked)
            {
                decimal recebido = 0;
                decimal.TryParse(txtValorRecebido.Text.Replace("R$", "").Trim(), out recebido);
                if (recebido < totalVenda)
                {
                    MessageBox.Show("Valor recebido insuficiente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtValorRecebido.Focus();
                    return;
                }
            }

            // 3. Confirmação
            if (MessageBox.Show($"Confirmar venda de {totalVenda:C2}?", "Finalizar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                // 4. Atualiza Estoque (DB)
                foreach (var item in itensVenda)
                {
                    DALProdutos.AtualizarEstoque(item.ProdutoId, item.Quantidade);
                }

                // 5. Prepara Objeto Venda
                Venda novaVenda = new Venda();
                novaVenda.DataVenda = DateTime.Now;
                novaVenda.ValorTotal = totalVenda;
                novaVenda.IdCliente = null;
                string mensagemExtra = "";

                // 6. Lógica de Cliente/Débito
                if (rbFiado.Checked)
                {
                    string nomeCliente = comboBoxCliente.Text;
                    DALClientes.AdicionarDebito(nomeCliente, totalVenda);
                    novaVenda.IdCliente = DALClientes.GetClienteIdPorNome(nomeCliente);
                    mensagemExtra = $"\nDebitado na conta de: {nomeCliente}";
                }

                // 7. Salva Venda e Itens (DB)
                DALVendas.RegistrarVenda(novaVenda, itensVenda.ToList());

                // 8. Sucesso e Limpeza
                MessageBox.Show("Venda realizada com sucesso!" + mensagemExtra, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparVenda();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao finalizar venda: " + ex.Message, "Erro Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarVenda_Click(object sender, EventArgs e)
        {
            if (itensVenda.Count > 0)
            {
                if (MessageBox.Show("Cancelar a venda atual e limpar o carrinho?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    LimparVenda();
                }
            }
        }

        private void LimparVenda()
        {
            itensVenda.Clear();
            CalcularTotalVenda();
            comboBoxCliente.Text = "";
            comboBoxCliente.SelectedIndex = -1;
            comboBoxProduto.Text = "";
            txtValorRecebido.Text = "0,00";
            lblTrocoValor.Text = "R$ 0,00";

            // Reseta para Dinheiro por padrão
            rbDinheiro.Checked = true;

            comboBoxProduto.Focus();
        }

        #endregion

        #region Atalhos de Teclado (F1-F5, ESC)

        private void Form_venda_KeyDown(object sender, KeyEventArgs e)
        {
            // Atalhos Globais da Tela de Vendas
            switch (e.KeyCode)
            {
                case Keys.F1: rbDinheiro.Checked = true; e.Handled = true; break;
                case Keys.F2: rbCartao.Checked = true; e.Handled = true; break;
                case Keys.F3: rbPix.Checked = true; e.Handled = true; break;
                case Keys.F4: rbFiado.Checked = true; e.Handled = true; break;
                case Keys.F5: FinalizarVenda(); e.Handled = true; break;
                case Keys.Escape: btnCancelarVenda.PerformClick(); e.Handled = true; break;
            }
        }

        #endregion

        #region Formatação de TextBox (Apenas Números)

        private void txtValorRecebido_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite números, backspace e uma única vírgula
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
            // Bloqueia segunda vírgula
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtValorRecebido_Leave(object sender, EventArgs e)
        {
            // Formata como moeda ao sair do campo (ex: 10 -> 10,00)
            if (decimal.TryParse(txtValorRecebido.Text, out decimal valor))
            {
                txtValorRecebido.Text = valor.ToString("N2");
            }
        }
        // Método limpo, apenas ligando os eventos
        

        #endregion

        #region Navegação Lateral (Sidebar)

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

        private void button_menu_Click_1(object sender, EventArgs e) { sidebar_timer.Start(); }

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

        private void buttonHistorico_Click_1(object sender, EventArgs e)
        {
            Form_historico historico = new Form_historico();
            historico.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente fechar o sistema?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // Eventos vazios gerados pelo designer (podem ser mantidos ou removidos)
        private void panelCarrinho_Paint(object sender, PaintEventArgs e) { }
        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e) { }

        #endregion
    }
}