using SistemaComercio.Dominio; // <-- Puxando a nossa classe limpa!
using System;
using System.Globalization;
using System.Windows.Forms;

namespace sistema_comercio
{
    public partial class Form_DetalheProduto : Form
    {
        // Propriedade usando a nova classe Produto
        public Produto Produto { get; private set; }

        // --- CONSTRUTOR INTELIGENTE ---
        public Form_DetalheProduto(Produto produtoParaEditar)
        {
            InitializeComponent();

            if (produtoParaEditar == null)
            {
                this.Text = "Adicionar Novo Produto";
                this.Produto = new Produto(); // Cria uma caixa nova e em branco
            }
            else
            {
                this.Text = "Editar Produto";
                this.Produto = produtoParaEditar; // Usa a caixa que veio preenchida
            }

            ConfigurarEventos();
            CarregarDadosNaTela();
        }

        private void CarregarDadosNaTela()
        {
            // Se for um produto novo, essas propriedades estarão vazias/zeradas e a tela fica limpa.
            // Se for edição, a tela preenche com os dados.
            textBox_nome_p.Text = Produto.Nome;
            textBox_codigo_barra.Text = Produto.CodigoBarras;

            // Só formata o preço se ele for maior que zero (para não ficar "0,00" num cadastro novo logo de cara, se preferir)
            if (Produto.Preco > 0)
                textBox_preço_venda.Text = Produto.Preco.ToString("N2");

            if (Produto.Estoque > 0) // Se for edição de estoque zero, mostra o zero
                textBox_quantidade.Text = Produto.Estoque.ToString();

            if (Produto.Validade.HasValue && Produto.Validade.Value >= dateTimePicker1.MinDate)
                dateTimePicker1.Value = Produto.Validade.Value;
        }

        private void ConfigurarEventos()
        {
            this.textBox_quantidade.KeyPress += ApenasValorNumerico;
            this.textBox_preço_venda.KeyPress += ApenasValorNumerico;

            // Mantendo a sua lógica inteligente de cálculo de margem intacta
            if (textBoxPrecoBase != null && textBoxPorcentagem != null)
            {
                this.textBoxPrecoBase.KeyPress += ApenasValorNumerico;
                this.textBoxPorcentagem.KeyPress += ApenasValorNumerico;
                this.textBoxPrecoBase.TextChanged += CamposDeCalculo_TextChanged;
                this.textBoxPorcentagem.TextChanged += CamposDeCalculo_TextChanged;
            }
        }

        // --- BOTÃO SALVAR ---
        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Validações Visuais (UX)
            if (string.IsNullOrWhiteSpace(textBox_nome_p.Text))
            {
                labelInsiraNome.Visible = true;
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox_codigo_barra.Text))
            {
                labelInsiraCodigo.Visible = true;
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox_preço_venda.Text))
            {
                MessageBox.Show("Insira um Preço no Produto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2. Colocando as informações digitadas dentro da caixa (Objeto Produto)
                Produto.Nome = textBox_nome_p.Text;
                Produto.CodigoBarras = textBox_codigo_barra.Text;

                // Lógica de conversão de preço impecável que você já tinha feito
                string precoTexto = textBox_preço_venda.Text.Replace("R$", "").Trim();
                if (decimal.TryParse(precoTexto, NumberStyles.Any, CultureInfo.CurrentCulture, out decimal precoFinal))
                {
                    Produto.Preco = precoFinal;
                }
                else
                {
                    decimal.TryParse(precoTexto.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out precoFinal);
                    Produto.Preco = precoFinal;
                }

                int.TryParse(textBox_quantidade.Text, out int estoque);
                Produto.Estoque = estoque;

                Produto.Validade = dateTimePicker1.Value;

                // 3. Devolve para o FormProduto avisando que deu tudo certo!
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao processar dados da tela: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // --- EVENTOS AUXILIARES (Intactos) ---
        private void ApenasValorNumerico(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != ',')
            {
                e.Handled = true;
            }
            if (e.KeyChar == ',' && txt.Text.Contains(","))
            {
                e.Handled = true;
            }
        }

        private void CamposDeCalculo_TextChanged(object sender, EventArgs e)
        {
            decimal.TryParse(textBoxPrecoBase.Text, out decimal custo);
            decimal.TryParse(textBoxPorcentagem.Text, out decimal margem);

            if (custo > 0)
            {
                decimal precoFinal = custo + (custo * margem / 100);
                textBox_preço_venda.Text = precoFinal.ToString("N2");
            }
        }

        private void Form_DetalheProduto_Load(object sender, EventArgs e) { }
        private void textBox_codigo_barra_TextChanged(object sender, EventArgs e) { }
    }
}