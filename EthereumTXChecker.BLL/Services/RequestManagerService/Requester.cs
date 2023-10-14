using EthereumTxChecker.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;

namespace EthereumTXChecker.BLL.Services.RequestManagerService
{
    public class Requester: IRequester
    {
        private readonly RequestManagerConfig _config;
        public Requester(IOptions<RequestManagerConfig> requestConfig)
        {
            _config = requestConfig.Value;
        }
        public string GetApiKey() => _config.EtherscanApiKey;


        public List<Result> GetTransactionsData(string requestUrl)
        {
            List<Result> transactions = new List<Result>();

            // Add status code check soon
            using (HttpClient httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(requestUrl).Result.Content.ReadAsStringAsync().Result;
                var jsonResponse = JsonConvert.DeserializeObject<APIResponse>(response);

                if (!String.IsNullOrEmpty(jsonResponse.Message))
                {
                    foreach (Result item in jsonResponse.Result)
                    {
                        if (item.MethodId != TransactionMethod.Recieve)
                        {
                            transactions.Add(item);
                        }
                    }
                }
                // Logger logic
            }
            return transactions;
        }

        public List<string> GenerateEndpoints(List<string> wallets)
        {
            // List of final endpoints for requests
            List<string> endpoints = new List<string>();

            foreach (var wallet in wallets)
            {
                string endpoint = $"https://api.etherscan.io/api?module=account&action=txlist&address={wallet}".Trim() 
                  + $"&startblock=0&endblock=99999999&page=1&offset=10&sort=asc&apikey={_config.EtherscanApiKey}".Trim();

                endpoints.Add(endpoint);
            }
            return endpoints;
        }
    }
}
