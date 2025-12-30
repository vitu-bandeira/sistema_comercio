using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace sistema_comercio
{
    public partial class Form_AdicionarCliente : Form
    {
        // Propriedade que guarda o cliente (Novo ou Editado)
        public Cliente_dtb NovoCliente { get; private set; }

        // Guarda o saldo original para saber se estamos aumentando ou diminuindo a dívida
        private decimal _saldoOriginal = 0;

        // Variáveis de controle de formatação
        private bool _formatandoSaldo = false;
        private bool _formatandoLimite = false;

        // CONSTRUTOR INTELIGENTE (Aceita cliente para edição)
        public Form_AdicionarCliente(Cliente_dtb clienteParaEditar = null)
        {
            InitializeComponent();

            // Configurações Iniciais
            ConfigurarEventos();
            ConfigurarNavegacao();

            if (clienteParaEditar == null)
            {
                // MODO: NOVO CLIENTE
                this.Text = "Adicionar Novo Cliente";
                this.NovoCliente = new Cliente_dtb();
                _saldoOriginal = 0; // Começa zerado
            }
            else
            {
                // MODO: EDITAR CLIENTE
                this.Text = "Editar Cliente - " + clienteParaEditar.nome;
                this.NovoCliente = clienteParaEditar;
                PreencherCampos(clienteParaEditar);

                // Guarda o saldo atual do banco
                _saldoOriginal = clienteParaEditar.saldo;
            }
        }

        private void ConfigurarEventos()
        {
            // Liga os eventos de formatação
            textBoxcpf.TextChanged += textBoxcpf_TextChanged;
            textBoxTelefone.TextChanged += textBoxTelefone_TextChanged;
            textBoxcpf.Leave += textBoxcpf_Leave;


            textBoxSaldo.KeyPress += ManipularNumero_KeyPress;
            textBoxSaldo.Leave += Formatacao_Leave;

            // Para o LIMITE
            txtLimite.KeyPress += ManipularNumero_KeyPress;
            txtLimite.Leave += Formatacao_Leave;
        }

        private void ConfigurarNavegacao()
        {
            textBoxNome.TabIndex = 0;
            textBoxcpf.TabIndex = 1;
            textBoxTelefone.TabIndex = 2;
            txtLimite.TabIndex = 4;
            textBoxEndereco.TabIndex = 5;
            textBoxSaldo.TabIndex = 3;
            btn_adicionar.TabIndex = 6;
            buttonCancelar.TabIndex = 7;

            this.AcceptButton = btn_adicionar;
            this.CancelButton = buttonCancelar;
        }
        private void PreencherCampos(Cliente_dtb cliente)
        {
            textBoxNome.Text = cliente.nome;
            textBoxcpf.Text = cliente.cpf;
            textBoxTelefone.Text = cliente.telefone;
            textBoxEndereco.Text = cliente.endereco;
            textBoxSaldo.Text = cliente.saldo.ToString("N2");

            // Novos Campos
            chkBloqueado.Checked = cliente.bloqueado;
            txtLimite.Text = cliente.limite.ToString("N2");
        }

        private void textBoxcpf_Leave(object sender, EventArgs e)
        {
            string cpfLimpo = textBoxcpf.Text.Replace(".", "").Replace("-", "").Replace(" ", "");

            // Se estiver vazio, deixa preto normal
            if (string.IsNullOrEmpty(cpfLimpo))
            {
                textBoxcpf.ForeColor = Color.Black;
                return;
            }

            if (IsCpf(cpfLimpo))
            {
                textBoxcpf.ForeColor = Color.DarkGreen; 
            }
            else
            {
                textBoxcpf.ForeColor = Color.Red; 
                                                  
            }
        }
      
        private void btn_adicionar_Click(object sender, EventArgs e)
        {
            
            if (!ValidarCamposObrigatorios()) return;

            string cpfDigitado = textBoxcpf.Text;

            if (!string.IsNullOrWhiteSpace(cpfDigitado.Replace(".", "").Replace("-", "")))
            {
                if (IsCpf(cpfDigitado) == false)
                {
                    MessageBox.Show("O CPF informado é inválido!\nPor favor, verifique os números digitados.",
                                    "CPF Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxcpf.Focus(); 
                    return; 
                }
            }

            decimal novoSaldo = ConverterMoeda(textBoxSaldo.Text);
            decimal limite = ConverterMoeda(txtLimite.Text);
            bool estaBloqueado = chkBloqueado.Checked;

            if (novoSaldo < _saldoOriginal)
            {
  
                if (estaBloqueado)
                {
                    MessageBox.Show("Cliente BLOQUEADO! Não é possível aumentar a dívida.",
                                    "Ação Negada", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (novoSaldo < 0 && limite > 0 && Math.Abs(novoSaldo) > limite)
                {
                    MessageBox.Show($"LIMITE EXCEDIDO!\n\n" +
                                    $"Limite permitido: {limite:C2}\n" +
                                    $"Saldo tentado: {novoSaldo:C2}\n\n" +
                                    $"Não é permitido deixar o saldo negativo acima do limite.",
                                    "Limite Atingido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            NovoCliente.nome = textBoxNome.Text.Trim();
            NovoCliente.cpf = textBoxcpf.Text.Trim();
            NovoCliente.telefone = textBoxTelefone.Text.Trim();
            NovoCliente.endereco = textBoxEndereco.Text.Trim();
            NovoCliente.saldo = novoSaldo;
            NovoCliente.limite = limite;       
            NovoCliente.bloqueado = estaBloqueado;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool ValidarCamposObrigatorios()
        {
            bool valido = true;

            // Valida Nome
            valido &= ValidacaoCampo(labelInsiraNome, "Nome", textBoxNome.Text);

            // Valida CPF 
            string cpfLimpo = Regex.Replace(textBoxcpf.Text, @"[^\d]", "");
            if (string.IsNullOrWhiteSpace(cpfLimpo) || cpfLimpo.Length < 11)
            {
                MessageBox.Show("CPF inválido ou incompleto!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valido = false;
            }

            return valido;
        }
        private bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            // Remove pontos, traços e espaços
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "").Replace(" ", "");

            // Verifica se tem 11 dígitos ou se todos são iguais (ex: 111.111.111-11 é inválido)
            if (cpf.Length != 11 ||
                cpf == "00000000000" || cpf == "11111111111" || cpf == "22222222222" ||
                cpf == "33333333333" || cpf == "44444444444" || cpf == "55555555555" ||
                cpf == "66666666666" || cpf == "77777777777" || cpf == "88888888888" ||
                cpf == "99999999999")
                return false;

            // Cálculo do 1º Dígito Verificador
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            // Cálculo do 2º Dígito Verificador
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            // Verifica se os dígitos calculados batem com os digitados
            return cpf.EndsWith(digito);
        }

        private bool ValidacaoCampo(Label label, string campoNome, string campoValor)
        {
            if (string.IsNullOrWhiteSpace(campoValor))
            {
                label.Text = campoNome + " é obrigatório!";
                label.Visible = true;
                return false;
            }
            else
            {
                label.Visible = false;
                return true;
            }
        }

        private decimal ConverterMoeda(string texto)
        {
            string limpo = texto.Replace("R$", "").Trim();
            if (decimal.TryParse(limpo, out decimal valor))
                return valor;
            return 0;
        }

        private void ManipularNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
           
            if (e.KeyChar == '-')
            {
                e.Handled = true; 
                if (decimal.TryParse(txt.Text.Replace("R$", "").Trim(), out decimal valor))
                {
                    valor = valor * -1; 
                    txt.Text = valor.ToString("N2"); 
                    txt.SelectionStart = txt.Text.Length; 
                }
                return;
            }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void Formatacao_Leave(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (decimal.TryParse(txt.Text.Replace("R$", "").Trim(), out decimal valor))
            {
                txt.Text = valor.ToString("N2");
            }
            else
            {
                txt.Text = "0,00";
            }
        }

        private void textBoxcpf_TextChanged(object sender, EventArgs e)
        {
            string digits = Regex.Replace(textBoxcpf.Text, @"[^\d]", "");

            if (digits.Length > 11) digits = digits.Substring(0, 11);

            string formatted = digits;
            if (digits.Length > 9)
                formatted = $"{digits.Substring(0, 3)}.{digits.Substring(3, 3)}.{digits.Substring(6, 3)}-{digits.Substring(9)}";
            else if (digits.Length > 6)
                formatted = $"{digits.Substring(0, 3)}.{digits.Substring(3, 3)}.{digits.Substring(6)}";
            else if (digits.Length > 3)
                formatted = $"{digits.Substring(0, 3)}.{digits.Substring(3)}";

            textBoxcpf.TextChanged -= textBoxcpf_TextChanged;
            textBoxcpf.Text = formatted;
            textBoxcpf.SelectionStart = formatted.Length;
            textBoxcpf.TextChanged += textBoxcpf_TextChanged;
        }

        private void textBoxTelefone_TextChanged(object sender, EventArgs e)
        {
            string digits = Regex.Replace(textBoxTelefone.Text, @"[^\d]", "");
            if (digits.Length > 11) digits = digits.Substring(0, 11);

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

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Form_AdicionarCliente_Load(object sender, EventArgs e) { }
    }
}