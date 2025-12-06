using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace sistema_comercio
{
    public partial class Form_Extrato : Form
    {
        private int _idCliente;
        private DataGridView dgvExtrato; 
        public Form_Extrato(int idCliente, string nomeCliente)
        {
            InitializeComponent();
            this._idCliente = idCliente;
            this.Text = "Extrato: " + nomeCliente;
            this.Size = new Size(500, 600);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;

            ConfigurarGrid();
            CarregarDados();
        }

        private void ConfigurarGrid()
        {
            dgvExtrato = new DataGridView();
            dgvExtrato.Dock = DockStyle.Fill;
            dgvExtrato.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvExtrato.ReadOnly = true;
            dgvExtrato.AllowUserToAddRows = false;
            dgvExtrato.RowHeadersVisible = false;
            dgvExtrato.BackgroundColor = Color.White;
            dgvExtrato.DefaultCellStyle.Font = new Font("Segoe UI", 11);
            dgvExtrato.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            this.Controls.Add(dgvExtrato);
        }

        private void CarregarDados()
        {
            try
            {
                DataTable dt = DALClientes.GetHistoricoPorCliente(_idCliente);
                dgvExtrato.DataSource = dt;

                // Formatação das colunas
                if (dgvExtrato.Columns["data"] != null)
                    dgvExtrato.Columns["data"].DefaultCellStyle.Format = "g"; // Data e Hora

                if (dgvExtrato.Columns["valor"] != null)
                    dgvExtrato.Columns["valor"].DefaultCellStyle.Format = "C2"; // Dinheiro
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar extrato: " + ex.Message);
            }
        }

      
    }
}