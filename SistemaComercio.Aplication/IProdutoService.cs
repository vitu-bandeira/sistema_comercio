using SistemaComercio.Dominio;
using SistemaComercio.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SistemaComercio.Aplication
{
    public interface IProdutoService
    {
        void AdicionarProduto(Produto produto);
        void AtualizarProduto(Produto produto);
        void ExcluirProduto(int id);
        IEnumerable<Produto> ObterTodosProdutos();
        IEnumerable<Produto> BuscarProdutosPorNome(string nome);
        decimal ObterValorTotalEstoque();
        int ObterContagemEstoqueBaixo(int limite);
        int ObterTotalProdutosCadastrados();
    }
}
