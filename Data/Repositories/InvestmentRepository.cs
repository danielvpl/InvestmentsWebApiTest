using Domain.CustomResponse;
using Domain.Helpers;
using Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class InvestmentRepository : IInvestmentRepository
    {
        private readonly IConfiguration _configuration;

        public InvestmentRepository(IConfiguration configuration)
        {
            _configuration = configuration;            
        }

        public async Task<TdsResponse> GetTds()
        {
            return await HttpRequestHelper<TdsResponse>.GetResult(_configuration.GetSection("ApiUrlBase").Value, _configuration.GetSection("GetTdsEndpoint").Value);            
        }

        public async Task<LciResponse> GetLcis()
        {
            return await HttpRequestHelper<LciResponse>.GetResult(_configuration.GetSection("ApiUrlBase").Value, _configuration.GetSection("GetLcisEndpoint").Value);
        }

        public async Task<FundsResponse> GetFunds()
        {
            return await HttpRequestHelper<FundsResponse>.GetResult(_configuration.GetSection("ApiUrlBase").Value, _configuration.GetSection("GetFundsEndpoint").Value);
        }
    }
}
