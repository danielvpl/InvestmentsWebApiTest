using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Services;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class InvestmentApp : IInvestmentApp
    {
        private readonly IInvestmentService<InvestmentTdsService> _serviceTds;
        private readonly IInvestmentService<InvestmentLcisService> _serviceLcis;
        private readonly IInvestmentService<InvestmentFundsService> _serviceFunds;
        private readonly IMapper _mapper;
        public InvestmentApp(IInvestmentService<InvestmentTdsService> serviceTds,
            IInvestmentService<InvestmentLcisService> serviceLcis,
            IInvestmentService<InvestmentFundsService> serviceFunds,
            IMapper mapper)
        {
            _serviceTds = serviceTds;
            _serviceLcis = serviceLcis;
            _serviceFunds = serviceFunds;
            _mapper = mapper;
        }

        public async Task<ClientInvestments> GetClientInvestments(DateTime dtConsult)
        {
            try
            {
                var resultTds = _serviceTds.CalculateInvestment(dtConsult);
                var resultLcis = _serviceLcis.CalculateInvestment(dtConsult);
                var resultFunds = _serviceFunds.CalculateInvestment(dtConsult);

                List<Investment> investimentos = new List<Investment>();
                investimentos.AddRange(await resultTds);
                investimentos.AddRange(await resultLcis);
                investimentos.AddRange(await resultFunds);

                //Resultado consolidado
                return _mapper.Map<ClientInvestments>(investimentos);
            }catch(Exception)
            {
                throw;                      
            }
        }
    }
}
