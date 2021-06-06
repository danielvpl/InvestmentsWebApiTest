using AutoMapper;
using Domain.Entities;
using Domain.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Data.Config
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<List<Investment>, ClientInvestments>()
                .ForMember(x => x.valorTotal, opt => opt.MapFrom(s => s.Sum(s => s.ValorTotal)))
                .ForMember(x => x.investimentos, opt => opt.MapFrom(s => s));
            
            CreateMap<Investment, InvestmentViewModel>();                
        }
    }
}
