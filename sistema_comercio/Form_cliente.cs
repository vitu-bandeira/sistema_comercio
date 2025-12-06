using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema_comercio
{
    public partial class FormCliente : Form
    {
        public FormCliente()
        {
            InitializeComponent();
        }

        private void Form_cliente_Load(object sender, EventArgs e)
        {
            DALClientes.CriarBancoSQLite();
            DALClientes.CriarTabelaClientes();
            DALClientes.CriarTabelaHistorico();
            ConfigurarGrid();
            ExibirDados();
            CarregarCards();

        }
        private void CarregarCards()
        {
            try
            {
                // Math.Abs tira o sinal de negativo para ficar bonito no card (ex: R$ 100,00 a receber)
                lblTotal.Text = Math.Abs(DALClientes.GetTotalSaldosDevedores()).ToString("C2");
                lblTotal.ForeColor = Color.Red;

                int devedores = DALClientes.GetTotalClientesDevedores();
                lblQtdDevedores.Text = devedores.ToString();
                lblQtdDevedores.ForeColor = devedores > 0 ? Color.OrangeRed : Color.Gray;

                lblTotalClientes.Text = DALClientes.GetTotalClientesCadastrados().ToString();
            }
            catch { }
        }
        private void ExibirDados()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DALClientes.GetClientes();
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao exibir os dados: " + ex.Message);
            }
        }

        private void ConfigurarGrid()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = false;

            // Coluna ID (oculta)
            DataGridViewTextBoxColumn colID = new DataGridViewTextBoxColumn();
            colID.Name = "IdProduto"; // Nome explícito
            colID.DataPropertyName = "id";
            colID.HeaderText = "ID";
            colID.Visible = false;
            dataGridView1.Columns.Add(colID);

            // Coluna Nome
            DataGridViewTextBoxColumn colNome = new DataGridViewTextBoxColumn();
            colNome.Name = "Nome"; // Nome explícito
            colNome.DataPropertyName = "nome";
            colNome.HeaderText = "Nome";
            colNome.Width = 250;
            dataGridView1.Columns.Add(colNome);

            DataGridViewTextBoxColumn colEndereco = new DataGridViewTextBoxColumn();
            colEndereco.Name = "Endereco"; // Nome explícito
            colEndereco.DataPropertyName = "endereco";
            colEndereco.HeaderText = "Endereço";
            colEndereco.Width = 310;
            
            dataGridView1.Columns.Add(colEndereco);

            // Coluna Código de Barras
            DataGridViewTextBoxColumn colCodigo = new DataGridViewTextBoxColumn();
            colCodigo.Name = "Telefone"; // Nome explícito
            colCodigo.DataPropertyName = "telefone";
            colCodigo.HeaderText = "Telefone";
            colCodigo.Width = 200;
            dataGridView1.Columns.Add(colCodigo);

            // Coluna Preço
            DataGridViewTextBoxColumn colPreco = new DataGridViewTextBoxColumn();
            colPreco.Name = "Saldo"; // Nome explícito
            colPreco.DataPropertyName = "saldo";
            colPreco.HeaderText = "Saldo";
            colPreco.DefaultCellStyle.Format = "C2";
            colPreco.Width = 150;
            dataGridView1.Columns.Add(colPreco);

            DataGridViewButtonColumn colAjustar = new DataGridViewButtonColumn();
            colAjustar.Name = "Ajustar";
            colAjustar.HeaderText = "Ajustar";
            colAjustar.Text = "R$"; // Texto que vai aparecer no botão (curto e claro)
            colAjustar.UseColumnTextForButtonValue = true;
            colAjustar.Width = 85;
            dataGridView1.Columns.Add(colAjustar);

            DataGridViewButtonColumn colExtrato = new DataGridViewButtonColumn();
            colExtrato.Name = "Extrato";
            colExtrato.HeaderText = "Ver";
            colExtrato.Text = "📄"; // Emoji de papel/documento
            colExtrato.UseColumnTextForButtonValue = true;
            colExtrato.Width = 50;
            dataGridView1.Columns.Add(colExtrato);

            // Coluna Excluir (Botão)
            DataGridViewButtonColumn colExcluir = new DataGridViewButtonColumn();
            colExcluir.Name = "Excluir";
            colExcluir.HeaderText = "Excluir";
            colExcluir.Text = "🗑";
            colExcluir.UseColumnTextForButtonValue = true;
            colExcluir.Width = 85;
            dataGridView1.Columns.Add(colExcluir);


            // Estilo do Grid
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 12);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            dataGridView1.RowTemplate.Height = 35;

        }
        
        bool sidebarExpanded = true;

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
      

        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();

                string busca = textBoxBuscar.Text;
                dt = DALClientes.GetCliente(busca);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar os dados: " + ex.Message);
            }
        }
        private int idSelecionado;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            idSelecionado = Convert.ToInt32(row.Cells["IdProduto"].Value);
            string nome = row.Cells["Nome"].Value.ToString();
            string nomeColuna = dataGridView1.Columns[e.ColumnIndex].Name;

            if (nomeColuna == "Excluir")
            {
                ExcluirCliente(e.RowIndex);
            }
            else if (nomeColuna == "Ajustar")
            {
                AbrirAjusteSaldo(idSelecionado, nome);
            }
            else if (nomeColuna == "Extrato")
            {
                // Abre o extrato (Certifique-se de ter criado o Form_Extrato)
                try
                {
                    Form_Extrato formExtrato = new Form_Extrato(idSelecionado, nome);
                    formExtrato.ShowDialog();
                }
                catch { MessageBox.Show("Formulário de Extrato não encontrado."); }
            }
        }
    


        private void ExcluirCliente(int rowIndex)
        {
            try
            {
                int id = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["IdProduto"].Value);
                string nome = dataGridView1.Rows[rowIndex].Cells["Nome"].Value.ToString();
                DialogResult resultado = MessageBox.Show($"Deseja realmente excluir o cliente {nome}?", "Excluir Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultado == DialogResult.Yes)
                {
                    DALClientes.DeleteCliente(id);
                    MessageBox.Show("Cliente excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ExibirDados();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Excluir os dados: " + ex.Message);
            }
        }

        private void AbrirAjusteSaldo(int clienteId, string nomeCliente)
        {
            using (Form_AjustarSaldo formAjuste = new Form_AjustarSaldo())
            {
                formAjuste.Text = "Ajustar Saldo de: " + nomeCliente;

                if (formAjuste.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        decimal valorDoAjuste = formAjuste.ValorAjuste;

                        // 1. Atualiza o Saldo (Como já fazia)
                        DALClientes.AjustarSaldoCliente(clienteId, valorDoAjuste);

                        // 2. NOVO: Grava no Histórico!
                        string descricao = valorDoAjuste > 0 ? "Pagamento / Depósito" : "Cobrança / Ajuste";
                        DALClientes.RegistrarMovimentacao(clienteId, valorDoAjuste, descricao);

                        MessageBox.Show($"Saldo ajustado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void btn_adicionar_Click(object sender, EventArgs e)
        {
            using (Form_AdicionarCliente formAdd = new Form_AdicionarCliente())
            {
                // 2. Mostra o formulário como um "Diálogo" (trava a tela principal)
                if (formAdd.ShowDialog() == DialogResult.OK)
                {
                    // 3. Se o usuário clicou em "Salvar" (DialogResult.OK)...
                    //    Pegamos o cliente que ele preencheu:
                    Cliente_dtb clienteParaSalvar = formAdd.NovoCliente;

                    // 4. Agora sim, salvamos no banco (lógica do seu btn_adicionar_Click antigo)
                    try
                    {
                        if (DALClientes.ClienteExiste(clienteParaSalvar.nome))
                        {
                            MessageBox.Show("Cliente já cadastrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        DALClientes.AddCliente(clienteParaSalvar);
                        MessageBox.Show("Cliente adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ExibirDados(); // Atualiza o grid
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Algo de errado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                // Se o usuário clicou em "Cancelar", nada acontece.
            }
        }
        private void button_menu_Click(object sender, EventArgs e)
        {
            sidebar_timer.Start();
        }

        private void buttonHome_Click_1(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
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
            Form_venda formVenda = new Form_venda();
            formVenda.Show();
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
