using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace ProjetoEnngie.Models
{
    public class UsinaVM
    {
        public Guid Id { get; set; }

        public IEnumerable<SelectListItem> Fornecedores { get; set; }

        public IEnumerable<SelectListItem> UsinasClientes { get; set; }

        public string Nome { get; set; }

        public string NomeFornecedor { get; set; }

        public bool Ativo { get; set; }

        public Guid FornecedorId { get; set; }
            
        public List<UsinaVM> Usinas { get; set; }
    }
}
