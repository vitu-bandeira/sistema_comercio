using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Forms;

namespace sistema_comercio
{
    public partial class Form_AjustarSaldo : Form
    {
        public decimal ValorAjuste { get; private set; }
        public Form_AjustarSaldo()
        {
            InitializeComponent();
            txtValorAjuste.TextChanged += txtValorAjuste_TextChanged;

            
            txtValorAjuste.Text = "0,00";
        }

        private bool _formatando = false;

        private void txtValorAjuste_TextChanged(object sender, EventArgs e)
        {
            if (_formatando) return;
            _formatando = true;

            try
            {
                // 1. Limpa tudo que não é número (exceto o sinal de menos)
                string textoLimpo = new string(txtValorAjuste.Text
                    .Where(c => char.IsDigit(c) || c == '-')
                    .ToArray());

                // Verifica se é negativo
                bool negativo = textoLimpo.Contains("-");

                // Remove o sinal para tratar apenas os números
                string apenasNumeros = new string(textoLimpo.Where(char.IsDigit).ToArray());

                // Se apagou tudo, volta para zero
                if (string.IsNullOrEmpty(apenasNumeros))
                    apenasNumeros = "0";

                // Converte para long para tirar zeros a esquerda (001 -> 1)
                long valorNumerico = long.Parse(apenasNumeros);

                // Formata como dinheiro (divide por 100 para colocar a vírgula)
                // Ex: 123 -> 1,23
                decimal valorFinal = valorNumerico / 100m;

                if (negativo)
                    valorFinal *= -1;

                // Atualiza o texto na tela formatado (N2 = 2 casas decimais)
                txtValorAjuste.Text = valorFinal.ToString("N2");

                // Coloca o cursor no final do texto para continuar digitando
                txtValorAjuste.SelectionStart = txtValorAjuste.Text.Length;
            }
            catch
            {
                // Se der algum erro bizarro, reseta
                txtValorAjuste.Text = "0,00";
            }
            finally
            {
                _formatando = false;
            }
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            string textoDoValor = txtValorAjuste.Text;

            // Tenta converter o texto para um número
            if (decimal.TryParse(textoDoValor, out decimal valor))
            {
                // Se deu certo (ex: "100" ou "-50" ou "100,50")
                this.ValorAjuste = valor;
                this.DialogResult = DialogResult.OK; // Informa que foi OK
                this.Close();
            }
            else
            {
                // Se falhou (ex: "abc" ou "100.50" - o ponto pode dar erro)
                MessageBox.Show("Valor inválido. Use apenas números (ex: 100,50 ou -50).");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Informa que foi cancelado
            this.Close();
        }

    }
}
