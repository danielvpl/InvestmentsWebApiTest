using Domain.CustomResponse;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IInvestmentRepository
    {
        Task<TdsResponse> GetTds();
        Task<LciResponse> GetLcis();
        Task<FundsResponse> GetFunds();              
    }
}
