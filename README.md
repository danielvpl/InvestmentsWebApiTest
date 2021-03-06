# InvestmentsWebApiTest
Webapi Test to Consolide Investments Results

Criar uma api em .NET utilizando as melhores práticas de desenvolvimento, para resolver o 
problema a seguir.
Problema:
Nossos usuários têm custodia em vários tipos de investimentos, que vem de serviços distintos, para
isso devemos consolidar estes dados e devolver para canais diversos. A seguir temos 3 endpoints 
para consulta de valores:

Tesouro Direto
http://www.mocky.io/v2/5e3428203000006b00d9632a

Renda Fixa
http://www.mocky.io/v2/5e3429a33000008c00d96336

Fundos
http://www.mocky.io/v2/5e342ab33000008c00d96342

Esperado:
Criar um endpoint que retorne o valor total do investimento do cliente e lista dos seus 
investimentos. Cada item da lista deverá conter seu valor unitário, cálculo de IR conforme regra 
abaixo e valor calculado caso o cliente queira resgatar seu investimento na data. O contrato 
esperado para o retorno é o seguinte:

{
 "valorTotal": 829.68,
 //Aqui deverão ser listados todos os investimentos retornados pelos 3 serviços
 "investimentos": [{
 "nome": "Tesouro Selic 2025",
 "valorInvestido": 799.4720,
 "valorTotal": 829.68,
 "vencimento": "2025-03-01T00:00:00",
 "Ir": 3.0208,
 "valorResgate": 705.228
 }]
}

Regras para cálculos:

IR:
Taxa sobre a rentabilidade*
Tesouro Direto 10%
LCI 5%
Fundos 15%
*Rentabilidade = Valor Total – Valor Investido (Pode ser negativo)

Cálculo para resgate:
Investimento com mais da metade do tempo em custódia: Perde 15% do valor investido
Investimento com até 3 meses para vencer: Perde 6% do valor investido
Outros: Perde 30% do valor investido

Projeto da solução:

Desenvolvido em camadas, seguindo o padrão SOLID, Onion Architecture e TDD. Descrição:

1 Criação do repositório 'InvestmentRepository' responsável pelo leitura dos endpoints externos e mapeamento para os 'CustomResponse';

2 Criação dos serviços: InvestmentTdsService, InvestmentLcisService, InvestmentFundsService;

3 Criação do app service: InvestmentApp para consolidar o resultado da execução dos serviços e retornar para o mapeamento 'ClientInvestments';

4 Criação do controller 'Investimento', utilizando cache para otimizar o desempenho na exibição de resultados;

5 Criação da documentação da API via swagger;

6 Implementação de Testes Unitários por camadas;

7 Configuração de AutoMapper e injeção de dependências.
