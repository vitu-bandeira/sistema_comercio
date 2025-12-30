using System;
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
    public partial class Form_Login : Form
    {
        public Form_Login()
        {
            InitializeComponent();
        }


        private void btn_login_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string senha = txtSenha.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return;
            }
            if (DALUsuario.ValidarLogin(usuario, senha))
            {
                this.Hide();
               
                Form1 sistema = new Form1();

                sistema.Closed += (s, args) => this.Close();

                sistema.Show();
            }
            else
            {
                MessageBox.Show("Usuário ou senha incorretos!", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSenha.Clear();
                txtSenha.Focus();
            }
        }

        private void Form_Login_Load(object sender, EventArgs e)
        {
            try
            {
                DALUsuario.CriarTabelaUsuario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar no banco: " + ex.Message);
            }
        }
    }

}
