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
            ConfigurarGrid();
            ExibirDados();

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

        private bool ValidacaoCampo(Label label, string campoNome, string campoValor)
        {
            bool valido = true;
            if (string.IsNullOrWhiteSpace(campoValor))
            {
                label.Text = campoNome + " é obrigatório!";
                label.Visible = true;
                valido = false;

            }
            else
            {
                label.Visible = false;
            }
            return valido;
        }

        
        private void btn_adicionar_Click(object sender, EventArgs e)
        {
            try
            {
                bool camposValidos = true;
                camposValidos &= ValidacaoCampo(labelInsiraNome, "Nome", textBoxNome.Text);
                camposValidos &= ValidacaoCampo(labelInserirTelefone, "Telefone", textBoxTelefone.Text);
                camposValidos &= ValidacaoCampo(labelInserirValor, "Saldo", textBoxSaldo.Text);
                string telefoneLimpo = Regex.Replace(textBoxTelefone.Text, @"[^\d]", "");
                if (telefoneLimpo.Length < 10)
                {
                    labelInserirTelefone.Text = "Telefone deve ter 10/11 dígitos!";
                    labelInserirTelefone.Visible = true;
                    camposValidos = false;
                }
                if (!camposValidos)
                {
                    MessageBox.Show($"Corrija os seguintes erros:",
                                  "Formulário Incompleto",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);
                    return;
                }
                // No evento btn_adicionar_Click
                if (DALClientes.ClienteExiste(textBoxNome.Text))
                {
                    MessageBox.Show("Cliente já cadastrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Cliente_dtb cliente = new Cliente_dtb();
                DataGridViewColumn colNome = dataGridView1.Columns["Nome"];
                cliente.nome = textBoxNome.Text;
                cliente.telefone = textBoxTelefone.Text;
                cliente.endereco = textBoxEndereco.Text;
                cliente.saldo = Convert.ToDecimal(textBoxSaldo.Text);
                if (!decimal.TryParse(textBoxSaldo.Text, out decimal saldo))
                {
                    MessageBox.Show("Saldo inválido!");
                    return;
                }
                cliente.saldo = saldo;

                DALClientes.AddCliente(cliente);
                MessageBox.Show("Cliente adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ExibirDados();
                textBoxNome.Clear();
                textBoxTelefone.Clear();
                textBoxEndereco.Clear();
                textBoxSaldo.Clear();
                labelInserirValor.Visible = false;
                labelInserirTelefone.Visible = false;
                labelInsiraNome.Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo de errado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            // Coluna Excluir (Botão)
            DataGridViewButtonColumn colExcluir = new DataGridViewButtonColumn();
            colExcluir.Name = "Excluir";
            colExcluir.HeaderText = "Excluir";
            colExcluir.Text = "🗑";
            colExcluir.UseColumnTextForButtonValue = true;
            colExcluir.Width = 85;
            dataGridView1.Columns.Add(colExcluir);

            // Estilo do Grid
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 15);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 17, FontStyle.Bold);
            dataGridView1.RowTemplate.Height = 35;

        }
        private void buttonHome_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void buttonEstoque_Click_1(object sender, EventArgs e)
        {
            FormProduto formProduto = new FormProduto();
            formProduto.Show();
            this.Close();
        }

        private void buttonVenda_Click_1(object sender, EventArgs e)
        {
            Form_venda formVenda = new Form_venda();
            formVenda.Show();
            this.Close();
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
        private void button_menu_Click_1(object sender, EventArgs e)
        {
            sidebar_timer.Start();
        }

        private void textBoxTelefone_TextChanged(object sender, EventArgs e)
        {
            string digits = Regex.Replace(textBoxTelefone.Text, @"[^\d]", "");


            if (digits.Length > 11)
                digits = digits.Substring(0, 11);


            string formatted = digits;
            if (digits.Length >= 2)
            {
                formatted = $"({digits.Substring(0, 2)}) {digits.Substring(2)}";
                if (digits.Length > 7)
                {
                    formatted = $"({digits.Substring(0, 2)}) {digits.Substring(2, 5)}-{digits.Substring(7)}";
                }
            }
            textBoxTelefone.TextChanged -= textBoxTelefone_TextChanged;
            textBoxTelefone.Text = formatted;
            textBoxTelefone.SelectionStart = formatted.Length;
            textBoxTelefone.TextChanged += textBoxTelefone_TextChanged;
        }

        private bool _formatando = false;
        private int _ultimoLength = 0;
        private void textBoxSaldo_TextChanged(object sender, EventArgs e)
        {
            if (_formatando) return;
            _formatando = true;

            try
            {
                string texto = new string(textBoxSaldo.Text
                    .Where(c => char.IsDigit(c) || c == '-')
                    .ToArray());

                bool negativo = texto.StartsWith("-");
                texto = negativo ? texto.Substring(1) : texto;

                // Mantém máximo de 2 dígitos decimais + 10 inteiros
                texto = texto.Length > 12 ? texto.Substring(0, 12) : texto;

                // Lógica de deslocamento decimal
                if (texto.Length > _ultimoLength) // Digitando para frente
                {
                    if (texto.Length <= 2) // Caso 0,XX
                    {
                        texto = texto.PadLeft(2, '0');
                    }
                    else // Desloca dígitos existentes
                    {
                        texto = texto.Substring(0, texto.Length - 2) + "," + texto.Substring(texto.Length - 2);
                    }
                }

                // Formatação final
                string formatado = negativo ? "-" : "";
                if (texto.Length == 0)
                {
                    formatado = "0,00";
                }
                else if (texto.Length <= 2)
                {
                    formatado += "0," + texto.PadLeft(2, '0');
                }
                else
                {
                    formatado += texto.Insert(texto.Length - 2, ",")
                                  .TrimStart('0')
                                  .Replace(",,", ",");
                }

                // Atualiza controles
                textBoxSaldo.Text = formatado;
                textBoxSaldo.SelectionStart = formatado.Length;
                _ultimoLength = texto.Length;
            }
            finally
            {
                _formatando = false;
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
            
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Excluir")
            {
                ExcluirCliente(e.RowIndex);
            }
            else if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                textBoxNome.Text = row.Cells["Nome"].Value.ToString();
                textBoxTelefone.Text = row.Cells["Telefone"].Value.ToString();
                textBoxEndereco.Text = row.Cells["Endereco"].Value.ToString();
                textBoxSaldo.Text = row.Cells["Saldo"].Value.ToString();
                idSelecionado = Convert.ToInt32(row.Cells["IdProduto"].Value);  // Armazena o ID do cliente no Tag

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

        private void buttonAtualizar_Click(object sender, EventArgs e)
        {

            try
            {
                bool camposValidos = true;
                camposValidos &= ValidacaoCampo(labelInsiraNome, "Nome", textBoxNome.Text);
                camposValidos &= ValidacaoCampo(labelInserirTelefone, "Telefone", textBoxTelefone.Text);
                camposValidos &= ValidacaoCampo(labelInserirValor, "Saldo", textBoxSaldo.Text);
                string telefoneLimpo = Regex.Replace(textBoxTelefone.Text, @"[^\d]", "");
                if (telefoneLimpo.Length < 10)
                {
                    labelInserirTelefone.Text = "Telefone deve ter 10/11 dígitos!";
                    labelInserirTelefone.Visible = true;
                    camposValidos = false;


                }
                if (!camposValidos)
                {
                    MessageBox.Show($"Corrija os seguintes erros:",
                                  "Formulário Incompleto",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);
                    return;
                }
                Cliente_dtb cliente = new Cliente_dtb();
                cliente.nome = textBoxNome.Text;
                cliente.telefone = textBoxTelefone.Text;
                cliente.endereco = textBoxEndereco.Text;
                cliente.id = idSelecionado;
                cliente.saldo = Convert.ToDecimal(textBoxSaldo.Text);
                if (!decimal.TryParse(textBoxSaldo.Text, out decimal saldo))
                {
                    MessageBox.Show("Saldo inválido!");
                    return;
                }
                cliente.saldo = saldo;

                DALClientes.UpdateCliente(cliente);
                MessageBox.Show("Cliente Atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ExibirDados();
                textBoxNome.Clear();
                textBoxTelefone.Clear();
                textBoxEndereco.Clear();
                textBoxSaldo.Clear();
                labelInserirValor.Visible = false;
                labelInserirTelefone.Visible = false;
                labelInsiraNome.Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo de errado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
