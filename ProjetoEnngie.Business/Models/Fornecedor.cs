using System.Collections.Generic;

namespace ProjetoEnngie.Business.Models
{
    public class Fornecedor : Entity
    {
        public string Nome { get; set; }

        public ICollection<Usina> Fornecedores { get; set; }

    }
}
