using ProjetoEnngie.Business.Interfaces;
using ProjetoEnngie.Business.Models;
using ProjetoEnngie.Data.Context;

namespace ProjetoEnngie.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(MeuDBContext context) : base(context)
        {
        }

    }
}
