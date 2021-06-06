using Domain.CustomResponse;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Services;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Domain.Tests
{
    public class InvestmentTdsServiceCalculateInvestment
    {
        private InvestmentTdsService _service;
        private Mock<IInvestmentRepository> _repo;
        private List<TdsResponse> _lstTds;

        public InvestmentTdsServiceCalculateInvestment()
        {
            _repo = new Mock<IInvestmentRepository>();
            _service = new InvestmentTdsService(_repo.Object);
            _lstTds = new List<TdsResponse>()
            {
                new TdsResponse(){
                    ValorInvestido = 799.4720,
                    ValorTotal = 829.69,
                    Vencimento = DateTime.Parse("2025-03-01T00:00:00"),
                    DataDeCompra = DateTime.Parse("2015-03-01T00:00:00"),
                    Iof = 0,
                    Indice = "SELIC",
                    Tipo = "TD",
                    Nome = "Tesouro Selic 2025"
                }
            };
        }

        [Fact]
        public async void ShouldReturnAverage()
        {
            var dt = DateTime.Parse("06/06/2021");

            _repo.Setup(x => x.GetTds()).ReturnsAsync(_lstTds);           

            var result = await _service.CalculateInvestment(dt);

            Assert.NotNull(result);
            Assert.IsType<List<Investment>>(result);            
        }
    }
}
