using Domain.CustomResponse;
using Domain.Helpers;
using Domain.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class InvestmentRepository : IInvestmentRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IMemoryCache _cache;

        public InvestmentRepository(IConfiguration configuration, IMemoryCache cache)
        {
            _configuration = configuration;
            _cache = cache;
        }

        public async Task<TdsResponse> GetTds()
        {
            var cacheEntry = await _cache.GetOrCreateAsync("ResultCacheGetTds", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1);
                entry.SetPriority(CacheItemPriority.High);
                return await HttpRequestHelper<TdsResponse>.GetResult(_configuration.GetSection("ApiUrlBase").Value, _configuration.GetSection("GetTdsEndpoint").Value);                
            });
            return cacheEntry;
        }

        public async Task<LciResponse> GetLcis()
        {
            var cacheEntry = await _cache.GetOrCreateAsync("ResultCacheGetTds", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1);
                entry.SetPriority(CacheItemPriority.High);
                return await HttpRequestHelper<LciResponse>.GetResult(_configuration.GetSection("ApiUrlBase").Value, _configuration.GetSection("GetLcisEndpoint").Value);
            });
            return cacheEntry;            
        }

        public async Task<FundsResponse> GetFunds()
        {
            var cacheEntry = await _cache.GetOrCreateAsync("ResultCacheGetTds", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1);
                entry.SetPriority(CacheItemPriority.High);
                return await HttpRequestHelper<FundsResponse>.GetResult(_configuration.GetSection("ApiUrlBase").Value, _configuration.GetSection("GetFundsEndpoint").Value);
            });
            return cacheEntry;            
        }
    }
}
