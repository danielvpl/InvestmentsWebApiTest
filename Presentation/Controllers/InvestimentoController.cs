using Application.Interfaces;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestimentoController : ControllerBase
    {
        private readonly IMemoryCache _cache;
        private readonly IInvestmentApp _app;
      
        public InvestimentoController(IInvestmentApp app, IMemoryCache cache)
        {
            _cache = cache;
            _app = app;         
        }

        // GET api/<InvestmentController>        
        [HttpGet]
        public async Task<ActionResult<ClientInvestments>> GetClientInvestments([FromQuery] DateTime dtConsult)
        {
            try
            {
                dtConsult = dtConsult.Year == 1 ? DateTime.Now : dtConsult;

                var cacheEntry = _cache.GetOrCreate("ResultCache" + dtConsult.ToShortDateString(), async entry =>
                  {
                      entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(24 - DateTime.Now.Hour);
                      entry.SetPriority(CacheItemPriority.High);
                      var result = await _app.GetClientInvestments(dtConsult);

                      return Ok(result);                      
                  });

                return await cacheEntry;
            }catch(Exception ex) {
                return BadRequest("Erro ao acessar serviço. Detalhes: " + ex.Message);
            };
        }                                      
    }
}