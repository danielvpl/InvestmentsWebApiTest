using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class InvestmentTdsService : InvestmentBase, IInvestmentService<InvestmentTdsService>
    {
        private readonly IInvestmentRepository _repository;        
        public InvestmentTdsService(IInvestmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Investment>> CalculateInvestment(DateTime dtConsult)
        {            
            List<Investment> lstInvestments = new List<Investment>();
            var tdsReponse = await _repository.GetTds();           

            foreach (var item in tdsReponse.tds)
            {
                lstInvestments.Add(new Investment()
                {
                    Nome = item.Nome,
                    Ir = (item.ValorTotal - item.ValorInvestido) * 0.10,
                    ValorInvestido = item.ValorInvestido,
                    ValorResgate = item.ValorTotal - item.ValorTotal * GetRedemptionTax(item.Vencimento, item.DataDeCompra, dtConsult),
                    ValorTotal = item.ValorTotal,
                    Vencimento = item.Vencimento
                });
            }

            return lstInvestments;
        }        
    }
}
