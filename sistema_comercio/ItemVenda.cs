// Arquivo: ItemVenda.cs
using System;

namespace sistema_comercio
{
    public class ItemVenda
    {
        public int IdVenda { get; set; } // ID da Venda (recibo)
        public int ProdutoId { get; set; } // ID do Produto
        public string CodigoBarras { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }

        // Propriedade calculada (não vai ao banco, mas é útil)
        public int EstoqueDisponivel { get; set; } // Guarda o estoque máximo
        public decimal TotalItem => Quantidade * PrecoUnitario;
    }
}