using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaComercio.Dominio
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CodigoBarras { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public DateTime? Validade { get; set; }
    }
}
