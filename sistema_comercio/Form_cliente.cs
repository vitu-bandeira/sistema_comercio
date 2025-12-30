using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace sistema_comercio
{
    public partial class FormCliente : Form
    {
        // Variáveis para saber quem foi clicado
        private int _idSelecionado = 0;
        private string _nomeSelecionado = "";

        public FormCliente()
        {
            InitializeComponent();
            ConfigurarGrid();

            // Garante que o evento de formatação esteja ligado
            dataGridView1.CellFormatting += DataGridView1_CellFormatting;
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void Form_cliente_Load(object sender, EventArgs e)
        {
            try
            {
                DALClientes.CriarBancoSQLite();
                DALClientes.CriarTabelaClientes();
                DALClientes.CriarTabelaHistorico();


                ExibirDados();
                CarregarCards();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar: " + ex.Message);
            }
        }

        // --- 1. CONFIGURAÇÃO DA GRADE (LIMPANDO OS BOTÕES ANTIGOS) ---
        private void ConfigurarGrid()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            dataGridView1.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

        // ID (Oculto)
        dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "id",
                DataPropertyName = "id",
                HeaderText = "ID",
                Visible = false
            });

            // CPF
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "cpf",
                DataPropertyName = "cpf",
                HeaderText = "CPF",
                Width = 140
            });

            // Nome
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "nome",
                DataPropertyName = "nome",
                HeaderText = "Nome",
                Width = 250
            });

            // Endereço
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "endereco",
                DataPropertyName = "endereco",
                HeaderText = "Endereço",
                Width = 300
            });

            // Telefone
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "telefone",
                DataPropertyName = "telefone",
                HeaderText = "Telefone",
                Width = 150
            });

            // Saldo
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Saldo",
                DataPropertyName = "saldo",
                HeaderText = "Saldo",
                Width = 120,
                DefaultCellStyle = { Format = "C2" }
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Limite",
                DataPropertyName = "limite",
                HeaderText = "Limite",
                Width = 120,
                DefaultCellStyle = { Format = "C2" }
            });


            DataGridViewButtonColumn colMenu = new DataGridViewButtonColumn();
            colMenu.Name = "Menu";
            colMenu.HeaderText = "Ações";
            colMenu.Text = "⋮"; // 3 pontinhos
            colMenu.UseColumnTextForButtonValue = true;
            colMenu.Width = 60;
            colMenu.FlatStyle = FlatStyle.System; // Visual mais limpo

            dataGridView1.Columns.Add(colMenu);

            // Estilos Gerais
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 11);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dataGridView1.RowTemplate.Height = 35;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        // --- 2. EVENTOS DA GRADE (CLIQUE E COR) ---

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Se clicou na coluna de Menu (Três pontinhos)
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Menu")
            {
                // Guarda os dados da linha clicada
                _idSelecionado = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
                _nomeSelecionado = dataGridView1.Rows[e.RowIndex].Cells["nome"].Value.ToString();

                // Mostra o menu onde o mouse está
                if (menuOpcoes != null)
                {
                    menuOpcoes.Show(Cursor.Position);
                }
                else
                {
                    MessageBox.Show("Você precisa adicionar um ContextMenuStrip no Designer e chamar de 'menuOpcoes'");
                }
            }
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Saldo" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal valor))
                {
                    if (valor < 0)
                    {
                        e.CellStyle.ForeColor = Color.Red;
                        e.CellStyle.SelectionForeColor = Color.Red;
                        e.Value = "R$ -" + Math.Abs(valor).ToString("N2");
                    }
                    else
                    {
                        e.CellStyle.ForeColor = Color.Green;
                        e.Value = "R$ " + valor.ToString("N2");
                    }
                    e.FormattingApplied = true;
                }
            }
        }

        // --- 3. AÇÕES DO MENU (EDITAR, EXCLUIR, AJUSTAR) ---
        // IMPORTANTE: Dê dois cliques em cada item do seu MenuStrip no Designer para vincular a estes métodos

        private void itemAjustarSaldo_Click(object sender, EventArgs e)
        {
            if (_idSelecionado > 0)
                AbrirAjusteSaldo(_idSelecionado, _nomeSelecionado);
        }

        private void itemExcluir_Click(object sender, EventArgs e)
        {
            if (_idSelecionado > 0)
                ExcluirCliente(_idSelecionado, _nomeSelecionado);
        }

        private void itemHistorico_Click(object sender, EventArgs e)
        {
            if (_idSelecionado == 0) return;


            using (Form_Extrato extrato = new Form_Extrato(_idSelecionado, _nomeSelecionado))
            {
                extrato.ShowDialog(); // Abre ele
            }
        }

        private void itemEditar_Click(object sender, EventArgs e)
        {
            // Aqui você implementará a lógica de editar chamando o Form_AdicionarCliente com o ID
            if (_idSelecionado == 0) return;

            try
            {
                // 1. Busca os dados ATUAIS e COMPLETOS do banco (inclusive Limite e Bloqueio)
                Cliente_dtb clienteParaEditar = DALClientes.GetClientePorId(_idSelecionado);

                if (clienteParaEditar == null)
                {
                    MessageBox.Show("Erro ao buscar dados do cliente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 2. Abre o formulário passando o cliente
                using (Form_AdicionarCliente formEdit = new Form_AdicionarCliente(clienteParaEditar))
                {
                    // Trava a tela e espera o usuário clicar em Salvar ou Cancelar
                    if (formEdit.ShowDialog() == DialogResult.OK)
                    {
                        // 3. Se clicou em Salvar, manda as alterações para o Banco
                        DALClientes.UpdateCliente(formEdit.NovoCliente);

                        MessageBox.Show("Dados do cliente atualizados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // 4. Atualiza a tabela na tela
                        ExibirDados();
                        CarregarCards(); // Se você tiver os cards de totais lá em cima
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar editar: " + ex.Message);
            }
        }

        private void ExcluirCliente(int id, string nome)
        {
            try
            {
                var resultado = MessageBox.Show($"Deseja realmente excluir {nome}?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultado == DialogResult.Yes)
                {
                    DALClientes.DeleteCliente(id);
                    MessageBox.Show("Cliente excluído!");
                    ExibirDados();
                    CarregarCards();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir: " + ex.Message);
            }
        }

        private void AbrirAjusteSaldo(int clienteId, string nomeCliente)
        {
            using (Form_AjustarSaldo formAjuste = new Form_AjustarSaldo())
            {
                formAjuste.Text = "Ajustar Saldo: " + nomeCliente;

                if (formAjuste.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        decimal valor = formAjuste.ValorAjuste;
                        DALClientes.AjustarSaldoCliente(clienteId, valor);

                        string descricao = valor > 0 ? "Pagamento/Crédito" : "Cobrança/Débito";
                        DALClientes.RegistrarMovimentacao(clienteId, valor, descricao);

                        MessageBox.Show("Saldo atualizado!");
                        ExibirDados();
                        CarregarCards();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro: " + ex.Message);
                    }
                }
            }
        }

        private void ExibirDados()
        {
            try
            {
                string busca = textBoxBuscar.Text.Trim();
                DataTable dt = string.IsNullOrEmpty(busca) ? DALClientes.GetClientes() : DALClientes.GetCliente(busca);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message);
            }
        }

        private void CarregarCards()
        {
            try
            {
                lblTotal.Text = Math.Abs(DALClientes.GetTotalSaldosDevedores()).ToString("C2");
                lblTotal.ForeColor = Color.Red;

                int devedores = DALClientes.GetTotalClientesDevedores();
                lblQtdDevedores.Text = devedores.ToString();
                lblQtdDevedores.ForeColor = devedores > 0 ? Color.OrangeRed : Color.Gray;

                lblTotalClientes.Text = DALClientes.GetTotalClientesCadastrados().ToString();
            }
            catch { }
        }

        private void btn_adicionar_Click(object sender, EventArgs e)
        {
            using (Form_AdicionarCliente formAdd = new Form_AdicionarCliente())
            {
                if (formAdd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (DALClientes.ClienteExiste(formAdd.NovoCliente.nome))
                        {
                            MessageBox.Show("Cliente já cadastrado!");
                            return;
                        }
                        DALClientes.AddCliente(formAdd.NovoCliente);
                        MessageBox.Show("Cliente adicionado!");
                        ExibirDados();
                        CarregarCards();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro: " + ex.Message);
                    }
                }
            }
        }

        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            ExibirDados();
        }

        // --- 5. NAVEGAÇÃO E SIDEBAR ---

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

        private void button_menu_Click(object sender, EventArgs e) => sidebar_timer.Start();

        private void buttonHome_Click_1(object sender, EventArgs e) { new Form1().Show(); this.Close(); }
        private void buttonEstoque_Click(object sender, EventArgs e) { new FormProduto().Show(); this.Close(); }
        private void buttonVenda_Click(object sender, EventArgs e) { new Form_venda().Show(); this.Close(); }
        private void buttonHistorico_Click_1(object sender, EventArgs e) { new Form_historico().Show(); this.Close(); }

        private void buttonSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sair do sistema?", "Sair", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Application.Exit();
        }

        private void dataGridView1_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];

                // Tenta pegar os dados
                if (row.DataBoundItem is System.Data.DataRowView drv)
                {
                    if (drv.Row.Table.Columns.Contains("saldo") && drv.Row.Table.Columns.Contains("limite"))
                    {
                        decimal saldo = drv["saldo"] != DBNull.Value ? Convert.ToDecimal(drv["saldo"]) : 0;
                        decimal limite = drv["limite"] != DBNull.Value ? Convert.ToDecimal(drv["limite"]) : 0;

                        bool bloqueado = drv.Row.Table.Columns.Contains("bloqueado") &&
                                         drv["bloqueado"] != DBNull.Value &&
                                         Convert.ToBoolean(drv["bloqueado"]);

                        // Definição das Cores
                        Color corFundo;
                        Color corTexto;

                        // CASO 1: Bloqueado Manualmente
                        if (bloqueado)
                        {
                            corFundo = Color.FromArgb(255, 200, 200); // Vermelho Claro
                            corTexto = Color.DarkRed;      // Texto Vermelho Escuro
                        }
                        // CASO 2: Estourou o Limite
                        else if (saldo < 0 && Math.Abs(saldo) > limite && limite > 0)
                        {
                            corFundo = Color.MistyRose;    // Rosa Alerta
                            corTexto = Color.Red;          // Texto Vermelho
                        }
                        // CASO 3: Normal
                        else
                        {
                            corFundo = Color.White;
                            corTexto = Color.Black;
                        }

                        // --- APLICAÇÃO DO TRUQUE "SEM SELEÇÃO" ---

                        // 1. Aplica a cor normal
                        e.CellStyle.BackColor = corFundo;
                        e.CellStyle.ForeColor = corTexto;

                        // 2. FORÇA a seleção a ser IGUAL à normal (Invisível)
                        e.CellStyle.SelectionBackColor = corFundo; // O segredo está aqui!
                        e.CellStyle.SelectionForeColor = corTexto; // E aqui!

                        // Aplica na linha toda também por garantia
                        row.DefaultCellStyle.BackColor = corFundo;
                        row.DefaultCellStyle.SelectionBackColor = corFundo;
                        row.DefaultCellStyle.SelectionForeColor = corTexto;
                    }
                }
            }
        }
    }
}