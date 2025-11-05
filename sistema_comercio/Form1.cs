using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema_comercio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonEstoque_Click(object sender, EventArgs e)
        {
            FormProduto formProduto = new FormProduto();
            formProduto.Show();
            this.Hide();

        }

        private void buttonVenda_Click(object sender, EventArgs e)
        {
            Form_venda formVenda = new Form_venda();
            formVenda.Show();
            this.Hide();

        }

       
        
        private void button_menu_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        bool sidebarExpanded = true;
        private void timer1_Tick(object sender, EventArgs e)
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
                    timer1.Stop();

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
                    timer1.Stop();
                }
            }
        }

      

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonHistorico_Click(object sender, EventArgs e)
        {
            Form_historico formhistorico = new Form_historico();
            formhistorico.Show();
            this.Hide();

        }

        private void buttonCliente_Click_1(object sender, EventArgs e)
        {
            FormCliente formCliente = new FormCliente();
            formCliente.Show();
            this.Hide();
        }
    }
}
