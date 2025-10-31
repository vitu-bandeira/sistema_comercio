using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema_comercio
{
    public partial class Form_AdicionarCliente : Form
    {
        public Cliente_dtb NovoCliente { get; private set; }
        public Form_AdicionarCliente()
        {
            InitializeComponent();

            textBoxTelefone.TextChanged += textBoxTelefone_TextChanged;
            textBoxSaldo.TextChanged += textBoxSaldo_TextChanged;
        }



        private void Form_AdicionarCliente_Load(object sender, EventArgs e)
        {

        }

        private void btn_adicionar_Click(object sender, EventArgs e)
        {
            bool camposValidos = true;
            camposValidos &= ValidacaoCampo(labelInsiraNome, "Nome", textBoxNome.Text);
            camposValidos &= ValidacaoCampo(labelInserirTelefone, "Telefone", textBoxTelefone.Text);
            camposValidos &= ValidacaoCampo(labelInserirValor, "Saldo", textBoxSaldo.Text);
            // ... (adicione as outras validações de telefone, etc.) ...

            if (!camposValidos)
            {
                MessageBox.Show("Corrija os erros para salvar.", "Formulário Incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. Se tudo estiver válido, crie o objeto Cliente
            this.NovoCliente = new Cliente_dtb();
            this.NovoCliente.nome = textBoxNome.Text;
            this.NovoCliente.telefone = textBoxTelefone.Text;
            this.NovoCliente.endereco = textBoxEndereco.Text;
            this.NovoCliente.saldo = Convert.ToDecimal(textBoxSaldo.Text.Replace("R$", "").Trim());

            // 5. Informe que foi OK e feche a janela
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // 7. COPIE TODOS OS MÉTODOS DE VALIDAÇÃO E FORMATAÇÃO DO Form_cliente.cs PARA CÁ:

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

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }

}
