using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class InvestmentFundsService : InvestmentBase, IInvestmentService<InvestmentFundsService>
    {
        private readonly IInvestmentRepository _repository;
        public InvestmentFundsService(IInvestmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Investment>> CalculateInvestment(DateTime dtConsult)
        {
            try
            {
                List<Investment> lstInvestments = new List<Investment>();
                var fundsResponse = await _repository.GetFunds();

                if (fundsResponse != null)
                {
                    foreach (var item in fundsResponse.fundos)
                    {
                        lstInvestments.Add(new Investment()
                        {
                            Nome = item.Nome,
                            Ir = (item.ValorAtual - item.CapitalInvestido) * 0.15,
                            ValorInvestido = item.CapitalInvestido,
                            ValorResgate = item.ValorAtual - item.ValorAtual * GetRedemptionTax(item.DataResgate, item.DataCompra, dtConsult),
                            ValorTotal = item.ValorAtual,
                            Vencimento = item.DataResgate
                        });
                    }
                }

                return lstInvestments;
            }
            catch (Exception)
            {
                throw;
            }                    
        }
    }
}
