using System;

namespace Domain.Entities
{
    public class InvestmentLcis
    {
        public double CapitalInvestido { get; set; }
        public double CapitalAtual { get; set; }
        public double Quantidade { get; set; }
        public DateTime Vencimento { get; set; }
        public double Iof { get; set; }
        public double OutrasTaxas { get; set; }
        public string Indice { get; set; }
        public string Tipo { get; set; }
        public string Nome { get; set; }
        public bool GuarantidoFGC { get; set; }
        public DateTime DataOperacao { get; set; }
        public double PrecoUnitario { get; set; }
        public bool Primario { get; set; }
    }
}
