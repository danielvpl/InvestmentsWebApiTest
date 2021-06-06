using Domain.CustomResponse;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IInvestmentRepository
    {
        Task<List<TdsResponse>> GetTds();
        Task<List<LciResponse>> GetLcis();
        Task<List<FundsResponse>> GetFunds();              
    }
}
