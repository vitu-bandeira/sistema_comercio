using System;
using System.Globalization; // Precisamos disso para o CultureInfo
using System.Linq;
using System.Windows.Forms;

namespace sistema_comercio
{
    public partial class Form_DetalheProduto : Form
    {
        public Produto_dtb Produto { get; private set; }

        // Construtor 1: Para ADICIONAR
        public Form_DetalheProduto()
        {
            InitializeComponent();
            this.Text = "Adicionar Novo Produto";
            this.Produto = new Produto_dtb();
            ConfigurarEventos();
            // A linha de cálculo errada foi removida daqui
        }

        // Construtor 2: Para EDITAR
        public Form_DetalheProduto(Produto_dtb produtoParaEditar)
        {
            InitializeComponent();
            this.Text = "Editar Produto";
            this.Produto = produtoParaEditar;
            ConfigurarEventos();

            // As linhas de "TextChanged" foram movidas para ConfigurarEventos

            // Preenche os campos com os dados do produto
            textBox_nome_p.Text = Produto.Nome;
            textBox_codigo_barra.Text = Produto.CodigoBarras;
            textBox_preço_venda.Text = Produto.Preco.ToString("N2");
            textBox_quantidade.Text = Produto.Estoque.ToString();

            // (Você precisará preencher o Custo (textBoxPrecoBase) e a % (textBoxPorcentagem) aqui
            // se você estiver salvando eles no banco de dados.)

            if (Produto.Validade.HasValue && Produto.Validade.Value > dateTimePicker1.MinDate)
                dateTimePicker1.Value = Produto.Validade.Value;
        }

        // --- CORREÇÃO 2: Eventos ligados no lugar certo ---
        private void ConfigurarEventos()
        {
            // Liga os validadores de número
            this.textBox_quantidade.KeyPress += ApenasValorNumerico;
            // Adiciona validação aos novos campos
            this.textBoxPrecoBase.KeyPress += ApenasValorNumerico;
            this.textBoxPorcentagem.KeyPress += ApenasValorNumerico;

            // Liga os eventos de cálculo (AGORA FUNCIONA PARA ADICIONAR E EDITAR)
            this.textBoxPrecoBase.TextChanged += new System.EventHandler(this.CamposDeCalculo_TextChanged);
            this.textBoxPorcentagem.TextChanged += new System.EventHandler(this.CamposDeCalculo_TextChanged);

            // As linhas de clique dos botões foram removidas
            // para corrigir o bug do "clique duplo"
        }

        // Copiado do seu FormProduto.cs
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

        // --- CORREÇÃO 3 e 4: Lógica do "Clique Duplo" e Validação ---
        // Siga estas 2 etapas para corrigir o bug:

        // ETAPA A: No CÓDIGO, modifique os botões Salvar e Cancelar

        private void button1_Click(object sender, EventArgs e) // Botão SALVAR
        {
            // Validação
            if (string.IsNullOrWhiteSpace(textBox_nome_p.Text))
            {
                labelInsiraNome.Visible = true;
                this.DialogResult = DialogResult.None; // IMPEDE O FECHAMENTO
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox_codigo_barra.Text))
            {
                labelInsiraCodigo.Visible = true;
                this.DialogResult = DialogResult.None; // IMPEDE O FECHAMENTO
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox_preço_venda.Text))
            {
                MessageBox.Show("Insira um Preço no Produto");
                this.DialogResult = DialogResult.None; // IMPEDE O FECHAMENTO
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox_quantidade.Text))
            {
                labelInsiraQuantidade.Visible = true;
                this.DialogResult = DialogResult.None; // IMPEDE O FECHAMENTO
                return;
            }

            try
            {
                // Preenche o objeto Produto com os dados da tela
                Produto.Nome = textBox_nome_p.Text;
                Produto.CodigoBarras = textBox_codigo_barra.Text;
                Produto.Preco = decimal.Parse(textBox_preço_venda.Text.Replace(",", "."), CultureInfo.InvariantCulture);
                Produto.Estoque = int.Parse(textBox_quantidade.Text);
                Produto.Validade = dateTimePicker1.Value;

                this.DialogResult = DialogResult.OK; // Informa que foi OK
                // (Não chame this.Close() aqui! O Designer vai fazer isso.)
            }
            catch (FormatException)
            {
                MessageBox.Show("Formato inválido nos campos de Preço ou Quantidade!");
                this.DialogResult = DialogResult.None; // IMPEDE O FECHAMENTO
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar: " + ex.Message);
                this.DialogResult = DialogResult.None; // IMPEDE O FECHAMENTO
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Informa que foi Cancelado
            // (Não chame this.Close() aqui!)
        }

        // ETAPA B: No DESIGNER, faça isso (MUITO IMPORTANTE):
        // 1. Abra o Form_DetalheProduto.cs no modo [Designer]
        // 2. Clique no seu botão "Salvar" (button1)
        // 3. Na janela de Propriedades, mude a propriedade "DialogResult" para -> OK
        // 4. Clique no seu botão "Cancelar" (buttonCancelar)
        // 5. Na janela de Propriedades, mude a "DialogResult" para -> Cancel


        // --- CORREÇÃO 1: Cálculo de Preço Corrigido ---
        private void CalcularPrecoFinal()
        {
            // Usando o TryParse simples, que funciona melhor
            decimal.TryParse(textBoxPrecoBase.Text, out decimal custo);
            decimal.TryParse(textBoxPorcentagem.Text, out decimal porcentagem);

            decimal precoFinal = custo + (custo * porcentagem / 100);

            // "N2" formata o número para duas casas decimais (ex: "130,00")
            textBox_preço_venda.Text = precoFinal.ToString("N2");
        }

        private void CamposDeCalculo_TextChanged(object sender, EventArgs e)
        {
            // Chama o cálculo toda vez que um dos campos mudar
            CalcularPrecoFinal();
        }

        // (O método panel8_Paint foi removido por estar vazio)
    }
}