using System.Collections.Generic;

namespace Domain.ViewModels
{
    public class ClientInvestments
    {
        public double valorTotal { get; set; }
        public List<InvestmentViewModel> investimentos { get; set; }
    }
}
