﻿using Domain.CustomResponse;
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
            TdsResponse tdsResponse = new TdsResponse();
            try
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                var client = new HttpClient(clientHandler);
                client.BaseAddress = new Uri(_configuration.GetSection("ApiUrlBase").Value); 
                client.DefaultRequestHeaders.Accept.Clear();
                HttpResponseMessage response = await client.GetAsync(_configuration.GetSection("GetTdsEndpoint").Value);
                if (response.IsSuccessStatusCode)
                {
                    //GET
                    client.Dispose();
                    var result = await response.Content.ReadAsStringAsync();
                    
                    return JSONHelper.AsObjectList<TdsResponse>(result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return tdsResponse;
        }

        public async Task<LciResponse> GetLcis()
        {
            LciResponse lstInvestment = new LciResponse();
            try
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                var client = new HttpClient(clientHandler);
                client.BaseAddress = new Uri(_configuration.GetSection("ApiUrlBase").Value);
                client.DefaultRequestHeaders.Accept.Clear();
                HttpResponseMessage response = await client.GetAsync(_configuration.GetSection("GetLcisEndpoint").Value);
                if (response.IsSuccessStatusCode)
                {
                    //GET
                    client.Dispose();
                    var result = await response.Content.ReadAsStringAsync();
                    return JSONHelper.AsObjectList<LciResponse>(result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lstInvestment;
        }

        public async Task<FundsResponse> GetFunds()
        {
            FundsResponse lstInvestment = new FundsResponse();

            try
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                var client = new HttpClient(clientHandler);
                client.BaseAddress = new Uri(_configuration.GetSection("ApiUrlBase").Value);
                client.DefaultRequestHeaders.Accept.Clear(); 
                HttpResponseMessage response = await client.GetAsync(_configuration.GetSection("GetFundsEndpoint").Value);
                if (response.IsSuccessStatusCode)
                {
                    //GET
                    client.Dispose();
                    var result = await response.Content.ReadAsStringAsync();
                    return JSONHelper.AsObjectList<FundsResponse>(result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lstInvestment;
        }
    }
}
