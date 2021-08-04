using System.ComponentModel.DataAnnotations;

namespace ProjetoEnngie.Business.Models
{
    public class Usina : Entity
    {
        [Required(ErrorMessage = "Selecione o Fornecedor!")]
        public string Nome { get; set; }

        public bool Ativo { get; set; }

        public Fornecedor Fornecedor { get; set; }
    }
}
