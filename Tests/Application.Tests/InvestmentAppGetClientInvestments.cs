using Application.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Services;
using Domain.ViewModels;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Application.Tests
{
    public class InvestmentAppGetClientInvestments
    {
        private InvestmentApp _app;
        private readonly Mock<IInvestmentService<InvestmentTdsService>> _serviceTds;
        private readonly Mock<IInvestmentService<InvestmentLcisService>> _serviceLcis;
        private readonly Mock<IInvestmentService<InvestmentFundsService>> _serviceFunds;
        private readonly Mock<IMapper> _mapper;
        private List<Investment> _lstInvestments;

        public InvestmentAppGetClientInvestments()
        {
            _serviceTds = new Mock<IInvestmentService<InvestmentTdsService>>();
            _serviceLcis = new Mock<IInvestmentService<InvestmentLcisService>>();
            _serviceFunds = new Mock<IInvestmentService<InvestmentFundsService>>();
            _mapper = new Mock<IMapper>();

            _app = new InvestmentApp(_serviceTds.Object, _serviceLcis.Object, _serviceFunds.Object, _mapper.Object);
            _lstInvestments = new List<Investment>()
            {
                new Investment()
                {
                    Nome = "Tesouro Selic 2025",
                    ValorInvestido = 799.4720,
                    ValorTotal = 829.68,
                    Vencimento = DateTime.Parse("2025-03-01T00:00:00"),
                    Ir = 3.0208,
                    ValorResgate = 705.228           
                }
            };
        }

        [Fact]
        public async void ShouldReturnAverage()
        {
            var dt = DateTime.Parse("06/06/2021");

            _serviceTds.Setup(x => x.CalculateInvestment(dt)).ReturnsAsync(_lstInvestments);
            _serviceLcis.Setup(x => x.CalculateInvestment(dt)).ReturnsAsync(new List<Investment>());
            _serviceFunds.Setup(x => x.CalculateInvestment(dt)).ReturnsAsync(new List<Investment>());

            _mapper.Setup(x => x.Map<ClientInvestments>(_lstInvestments)).Returns(new ClientInvestments());

            var result = await _app.GetClientInvestments(dt);

            Assert.NotNull(result);
            Assert.IsType<ClientInvestments>(result);            
        }
    }
}
