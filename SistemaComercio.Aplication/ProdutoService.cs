using SistemaComercio.Dominio;
using SistemaComercio.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SistemaComercio.Aplication
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutosRepository _produtoRepository;

        public ProdutoService(IProdutosRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public void AdicionarProduto(Produto produto)
        {
            if (produto.Preco < 0)
            {
                throw new Exception("O preço do produto não pode ser negativo");
            }

            if(string.IsNullOrWhiteSpace(produto.Nome))
            {
                throw new Exception("Nome do Produto não pode estar vazio");
            }

            if (_produtoRepository.ProdutoExiste(produto.Nome))
            {
                throw new Exception("Produto ja Existe");
            }
            _produtoRepository.Adicionar(produto);
        }

        public void AtualizarProduto(Produto produto)
        {
            if (produto.Id <= 0)
                throw new Exception("ID do produto inválido.");

            if (string.IsNullOrWhiteSpace(produto.Nome))
                throw new Exception("O nome do produto não pode ficar vazio!");

            if (produto.Preco < 0)
                throw new Exception("O preço do produto não pode ser negativo!");

            _produtoRepository.Atualizar(produto);
        }

        public IEnumerable<Produto> BuscarProdutosPorNome(string nome)
        {
           return _produtoRepository.ObterPorNome(nome);
        }

        public void ExcluirProduto(int id)
        {
            if (id <= 0)
                throw new Exception("ID do produto inválido para exclusão.");

            _produtoRepository.Deletar(id);
        }

        public int ObterContagemEstoqueBaixo(int limite)
        {

            return _produtoRepository.ObterContagemEstoqueBaixo(limite);
        }

        public IEnumerable<Produto> ObterTodosProdutos()
        {
            return _produtoRepository.ObterTodos();
        }

        public int ObterTotalProdutosCadastrados()
        {
            return _produtoRepository.ObterTotalProdutosCadastrados();
        }

        public decimal ObterValorTotalEstoque()
        {
            return _produtoRepository.ObterValorTotalEstoque();
        }
    }
}
