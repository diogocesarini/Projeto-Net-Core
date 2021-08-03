using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoEnngie.Business.Models
{
    public class Usina : Entity
    {
        public string Nome { get; set; }
        public bool Ativo { get; set; }

        public Fornecedor Fornecedor { get; set; }
    }
}
