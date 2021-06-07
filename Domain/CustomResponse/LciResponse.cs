using Domain.Entities;
using System.Collections.Generic;

namespace Domain.CustomResponse
{
    public class LciResponse
    {
        public List<InvestmentLcis> lcis { get; set; }        
    }
}
