using System;

namespace Domain.Entities
{
    public class InvestmentFunds
    {
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
