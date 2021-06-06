using System;

namespace Domain.Entities
{
    public class Investment
    {
        public string Nome { get; set; }
        public double ValorInvestido { get; set; }
        public double ValorTotal { get; set; }
        public DateTime Vencimento { get; set; }
        public DateTime DataOperacao { get; set; }
        public double Ir { get; set; }
        public double ValorResgate { get; set; }        
    }
}
