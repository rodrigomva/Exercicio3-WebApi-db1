using AutoMapper;
using Exercicio3.Dominio.Entities;
using Exercicio3.Mvc.ViewModel;

namespace Exercicio3.Mvc.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<TecnologiaViewModel, Tecnologia>();
            CreateMap<VagaViewModel, Vaga>();
            CreateMap<VagaPesoViewModel, VagaPeso>();
            CreateMap<CandidatoViewModel, Candidato>();
            CreateMap<CandidatoTecnologiaViewModel, CandidatoTecnologia>();
        }
    }
}