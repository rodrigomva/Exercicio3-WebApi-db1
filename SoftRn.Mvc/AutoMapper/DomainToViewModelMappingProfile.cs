using AutoMapper;
using Exercicio3.Dominio.Entities;
using Exercicio3.Mvc.ViewModel;

namespace Exercicio3.Mvc.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Tecnologia,TecnologiaViewModel>();
            CreateMap<Vaga, VagaViewModel>();
            CreateMap<VagaPeso, VagaPesoViewModel>();
            CreateMap<Candidato, CandidatoViewModel>();
            CreateMap<CandidatoTecnologia, CandidatoTecnologiaViewModel>();
        }
    }
}