using EthereumTxChecker.Models;
using EthereumTXChecker.BLL.Services.FileManagerService;
using EthereumTXChecker.BLL.Services.RequestManagerService;
using Microsoft.AspNetCore.Mvc;

namespace EthereumTxChecker.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsCheck: Controller
    {
        private readonly IFileManager _fileManager;
        private readonly IRequester _requester;
        public TransactionsCheck(IFileManager manager, IRequester requester)
        {
            _fileManager = manager;
            _requester = requester;
        }

        private List<string> GetWallets() => _fileManager.GetWallets();
        private List<string> GenerateEndpoints() => _requester.GenerateEndpoints(GetWallets());

        [HttpGet]
        public List<Result> GetTransactionData()
        {
            List<string> endpoints = GenerateEndpoints();
            List<Result> result = new List<Result>();

            foreach (var endpoint in endpoints)
            {
                result = _requester.GetTransactionsData(endpoint);
                Thread.Sleep(1000);
            }
            return result;
        }
    }
}
