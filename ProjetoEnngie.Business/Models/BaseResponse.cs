using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoEnngie.Business.Models
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            this.Sucesso = true;
        }

        public bool Sucesso { get; set; }

        public object Valor { get; set; }

        public string Erro { get; set; }

        public string Alerta { get; set; }
    }
}
