using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IInvestmentService<T>
    {          
        Task<List<Investment>> CalculateInvestment(DateTime dtConsult);        
    }
}
