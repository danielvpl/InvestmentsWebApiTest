using Domain.ViewModels;
using System;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IInvestmentApp
    {          
        Task<ClientInvestments> GetClientInvestments(DateTime dtConsult);
    }
}
