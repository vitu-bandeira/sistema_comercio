using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaComercio.Dominio;  

namespace SistemaComercio.Infrastructure
{
    public interface IProdutosRepository
    {
        void Adicionar(Produto produto);
        void Atualizar(Produto produto);
        void Deletar(int id);
        Produto ObterPorID(int id);
        IEnumerable<Produto> ObterTodos();
        bool ProdutoExiste(string nome);
        IEnumerable<Produto> ObterPorNome(string nome);
        Produto ObterParaVenda(string termo);
        void AtualizarEstoque(int produtoId, int quantidadeVendida);
        int ObterContagemEstoqueBaixo(int limite);
        decimal ObterValorTotalEstoque();
        int ObterTotalProdutosCadastrados();


    }
}
