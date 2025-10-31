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
