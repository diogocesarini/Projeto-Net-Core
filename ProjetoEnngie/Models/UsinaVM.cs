using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEnngie.Models
{
    public class UsinaVM
    {
        public Guid Id { get; set; }

        public IEnumerable<SelectListItem> Fornecedores { get; set; }

        public IEnumerable<SelectListItem> UsinasClientes { get; set; }

        [Required(ErrorMessage = "Nome é requerido!")]
        [MaxLength(500)]
        public string Nome { get; set; }

        public string NomeFornecedor { get; set; }

        public bool Ativo { get; set; }

        [Required(ErrorMessage = "Selecione o Fornecedor!")]
        public Guid FornecedorId { get; set; }
            
        public List<UsinaVM> Usinas { get; set; }
    }
}
