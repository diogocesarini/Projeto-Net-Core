using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEnngie.Models
{
    public class UsinaVM
    {
        public Guid Id { get; set; }
        public List<FornecedorVM> Fornecedores { get; set; }
        public string Nome { get; set; }
        public  bool Ativo { get; set; }
    }
}
