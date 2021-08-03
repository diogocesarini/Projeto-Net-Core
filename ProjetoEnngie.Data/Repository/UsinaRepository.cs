using ProjetoEnngie.Business.Interfaces;
using ProjetoEnngie.Business.Models;
using ProjetoEnngie.Data.Context;

namespace ProjetoEnngie.Data.Repository
{
    public class UsinaRepository : Repository<Usina>, IUsinaRepository
    {
        public UsinaRepository(MeuDBContext context) : base(context)
        {
        }

    }
}
