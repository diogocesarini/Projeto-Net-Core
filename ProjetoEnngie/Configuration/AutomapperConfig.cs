using AutoMapper;
using ProjetoEnngie.Business.Models;
using ProjetoEnngie.Models;

namespace ProjetoEnngie.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Fornecedor, FornecedorVM>().ReverseMap();
            CreateMap<FornecedorVM, Fornecedor>().ReverseMap();
            CreateMap<UsinaVM, Usina>().ReverseMap();
            CreateMap<Usina, UsinaVM>().ReverseMap();
        }
    }
}