using EthereumTxChecker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthereumTXChecker.BLL.Services.RequestManagerService
{
    public interface IRequester
    {
        public string GetApiKey();
        public List<Result> GetTransactionsData(string requestUrl);
        public List<string> GenerateEndpoints(List<string> wallets);
    }
}
