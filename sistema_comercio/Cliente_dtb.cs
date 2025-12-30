using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_comercio
{
    public class Cliente_dtb
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public decimal saldo { get; set; }
        public string telefone { get; set; }
        public string endereco { get; set; }
        public bool bloqueado { get; set; }
        public decimal limite { get; set; }
    }
}
