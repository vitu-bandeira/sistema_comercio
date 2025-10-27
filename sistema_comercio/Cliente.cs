 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_comercio
{
    public class Cliente
    {
        public int id { get; set; }
        public string nome { get; set; }
        public int telefone { get; set; }
        public string endereco { get; set; }
   
        public decimal saldo { get; set; }
    }
}
