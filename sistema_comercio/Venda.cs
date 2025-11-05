// Arquivo: Venda.cs
using System;

namespace sistema_comercio
{
    public class Venda
    {
        public int IdVenda { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal ValorTotal { get; set; }
        public int? IdCliente { get; set; }
    }
}