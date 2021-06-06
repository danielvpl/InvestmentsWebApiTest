using System;
using System.Collections.Generic;

namespace Domain.CustomResponse
{
    public class FundsResponse
    {
        public List<FundsResponse> fundos { get; set; }
        public double CapitalInvestido { get; set; }
        public double ValorAtual { get; set; }
        public DateTime DataResgate { get; set; }
        public DateTime DataCompra { get; set; }
        public double Iof { get; set; }
        public string Nome { get; set; }
        public double TotalTaxas { get; set; }
        public int Quantity { get; set; }
    }
}
