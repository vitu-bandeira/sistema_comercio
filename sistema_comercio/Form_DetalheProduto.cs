using System;
using System.Globalization;
using System.Windows.Forms;

namespace sistema_comercio
{
    public partial class Form_DetalheProduto : Form
    {
        // Propriedade que guarda os dados do produto (para enviar ao Banco depois)
        public Produto_dtb Produto { get; private set; }

        // --- CONSTRUTOR INTELIGENTE (Um só para tudo) ---
        public Form_DetalheProduto(Produto_dtb produtoParaEditar)
        {
            InitializeComponent();

            // 1. CORREÇÃO DO ERRO DE REFERÊNCIA NULA
            // Aqui verificamos: Veio vazio? Então é um cadastro NOVO.
            if (produtoParaEditar == null)
            {
                this.Text = "Adicionar Novo Produto";
                this.Produto = new Produto_dtb(); // <--- CRIA UM EM BRANCO (Salva o dia!)
            }
            else
            {
                // Veio com dados? Então é EDIÇÃO.
                this.Text = "Editar Produto";
                this.Produto = produtoParaEditar;
            }

            ConfigurarEventos();
            CarregarDadosNaTela(); // Pega o que está no Produto e joga nos TextBoxes
        }

        // Método separado para preencher os campos visuais
        private void CarregarDadosNaTela()
        {
            textBox_nome_p.Text = Produto.Nome;
            textBox_codigo_barra.Text = Produto.CodigoBarras;
            textBox_preço_venda.Text = Produto.Preco.ToString("N2");
            textBox_quantidade.Text = Produto.Estoque.ToString();

            // Só preenche a data se ela for válida
            if (Produto.Validade.HasValue && Produto.Validade.Value >= dateTimePicker1.MinDate)
                dateTimePicker1.Value = Produto.Validade.Value;
        }

        private void ConfigurarEventos()
        {
            // Liga a validação de números nos campos
            this.textBox_quantidade.KeyPress += ApenasValorNumerico;
            this.textBox_preço_venda.KeyPress += ApenasValorNumerico;

            // Se você tiver os campos de Custo e Porcentagem no Design, mantém isso.
            // Se não tiver, o "if" abaixo evita que o programa quebre.
            if (textBoxPrecoBase != null && textBoxPorcentagem != null)
            {
                this.textBoxPrecoBase.KeyPress += ApenasValorNumerico;
                this.textBoxPorcentagem.KeyPress += ApenasValorNumerico;
                this.textBoxPrecoBase.TextChanged += CamposDeCalculo_TextChanged;
                this.textBoxPorcentagem.TextChanged += CamposDeCalculo_TextChanged;
            }
        }

        // --- BOTÃO SALVAR (Corrigido) ---
        private void button1_Click(object sender, EventArgs e)
        {
            // 2. CORREÇÃO DA VALIDAÇÃO
            // Verifica os campos ANTES de fechar a janela

            if (string.IsNullOrWhiteSpace(textBox_nome_p.Text))
            {
                labelInsiraNome.Visible = true; // Mostra aviso
                return; // PARA AQUI! Não fecha a janela.
            }

            if (string.IsNullOrWhiteSpace(textBox_codigo_barra.Text))
            {
                labelInsiraCodigo.Visible = true;
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox_preço_venda.Text))
            {
                MessageBox.Show("Insira um Preço no Produto");
                return;
            }

            try
            {
                // Passa o que foi digitado na TELA para o OBJETO Produto
                Produto.Nome = textBox_nome_p.Text;
                Produto.CodigoBarras = textBox_codigo_barra.Text;

                // Converte o preço (aceita ponto ou vírgula)
                string precoTexto = textBox_preço_venda.Text.Replace("R$", "").Trim();
                // Tenta converter usando a cultura local (vírgula) ou internacional (ponto)
                if (decimal.TryParse(precoTexto, NumberStyles.Any, CultureInfo.CurrentCulture, out decimal precoFinal))
                {
                    Produto.Preco = precoFinal;
                }
                else
                {
                    // Tenta forçar ponto se falhar
                    decimal.TryParse(precoTexto.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out precoFinal);
                    Produto.Preco = precoFinal;
                }

                int.TryParse(textBox_quantidade.Text, out int estoque);
                Produto.Estoque = estoque;

                Produto.Validade = dateTimePicker1.Value;

                // TUDO CERTO! Agora sim dizemos que foi OK e fechamos.
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao processar dados: " + ex.Message);
            }
        }

        // --- BOTÃO CANCELAR ---
        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // --- EVENTOS AUXILIARES ---
        private void ApenasValorNumerico(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            // Aceita números, Backspace e Virgula
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != ',')
            {
                e.Handled = true;
            }
            // Só aceita uma vírgula
            if (e.KeyChar == ',' && txt.Text.Contains(","))
            {
                e.Handled = true;
            }
        }

        private void CamposDeCalculo_TextChanged(object sender, EventArgs e)
        {
            // Lógica de cálculo (Custo + Margem = Preço Venda)
            decimal.TryParse(textBoxPrecoBase.Text, out decimal custo);
            decimal.TryParse(textBoxPorcentagem.Text, out decimal margem);

            if (custo > 0)
            {
                decimal precoFinal = custo + (custo * margem / 100);
                textBox_preço_venda.Text = precoFinal.ToString("N2");
            }
        }

        private void Form_DetalheProduto_Load(object sender, EventArgs e)
        {
        }

        private void textBox_codigo_barra_TextChanged(object sender, EventArgs e)
        {

        }
    }
}