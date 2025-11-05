using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema_comercio
{
    public partial class Form_DetalheProduto : Form
    {
        public Produto_dtb Produto { get; private set; }

        public Form_DetalheProduto()
        {
           ;
            InitializeComponent();
            this.Text = "Adicionar Novo Produto";
            this.Produto = new Produto_dtb(); // Cria um produto vazio
            ConfigurarEventos();
            
            
        }
        public Form_DetalheProduto(Produto_dtb produtoParaEditar)
        {
            InitializeComponent();
            this.Text = "Editar Produto";
            this.Produto = produtoParaEditar; // Recebe o produto clicado
            ConfigurarEventos();

        

        // Preenche os campos com os dados do produto
        textBox_nome_p.Text = Produto.Nome;
            textBox_codigo_barra.Text = Produto.CodigoBarras;
            textBox_preço_venda.Text = Produto.Preco.ToString("N2");
            textBox_quantidade.Text = Produto.Estoque.ToString();
            if (Produto.Validade.HasValue && Produto.Validade.Value > dateTimePicker1.MinDate)
                dateTimePicker1.Value = Produto.Validade.Value;
        }

        // --- MÉTODOS DE VALIDAÇÃO (Copiados do FormProduto.cs) ---

        private void ConfigurarEventos()
        {
            // Liga os botões

            this.textBoxPrecoBase.TextChanged += new System.EventHandler(this.CamposDeCalculo_TextChanged);
            this.textBoxPorcentagem.TextChanged += new System.EventHandler(this.CamposDeCalculo_TextChanged);


            // Liga os validadores de número
            this.textBox_preço_venda.KeyPress += ApenasValorNumerico;
            this.textBox_quantidade.KeyPress += ApenasValorNumerico;
            // Permitir que o código de barras tenha letras/hífen (opcional)
            // this.textBox_codigo_barra.KeyPress += ApenasValorNumerico; 

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

        private void button1_Click(object sender, EventArgs e)
        {
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
                MessageBox.Show("Insira um Preço no Produto");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox_quantidade.Text))
            {
                labelInsiraQuantidade.Visible = true;
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
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Formato inválido nos campos de Preço ou Quantidade!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar: " + ex.Message);
            }

        }

        

        private void CalcularPrecoFinal()
        {
            decimal.TryParse(textBoxPrecoBase.Text.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal custo);
            decimal.TryParse(textBoxPorcentagem.Text.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal porcentagem);
            decimal precoFinal = custo + (custo * porcentagem / 100);

            textBox_preço_venda.Text = precoFinal.ToString("N2");
        
        }
        private void CamposDeCalculo_TextChanged(object sender, EventArgs e)
        {
            // Chama o cálculo toda vez que um dos campos mudar
            CalcularPrecoFinal();
        }
        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

