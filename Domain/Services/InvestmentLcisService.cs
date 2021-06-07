using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class InvestmentLcisService : InvestmentBase, IInvestmentService<InvestmentLcisService>
    {
        private readonly IInvestmentRepository _repository;
        public InvestmentLcisService(IInvestmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Investment>> CalculateInvestment(DateTime dtConsult)
        {
            List<Investment> lstInvestments = new List<Investment>();
            var lcisResponse = await _repository.GetLcis();

            foreach (var item in lcisResponse.lcis)
            {
                lstInvestments.Add(new Investment()
                {
                    Nome = item.Nome,
                    Ir = (item.CapitalAtual - item.CapitalInvestido) * 0.05,
                    ValorInvestido = item.CapitalInvestido,
                    ValorResgate = item.CapitalAtual - item.CapitalAtual * GetRedemptionTax(item.Vencimento, item.DataOperacao, dtConsult),
                    ValorTotal = item.CapitalAtual,
                    Vencimento = item.Vencimento
                });
            }

            return lstInvestments;
        }
    }
}
