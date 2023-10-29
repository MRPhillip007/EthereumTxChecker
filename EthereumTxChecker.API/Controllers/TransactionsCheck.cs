using EthereumTxChecker.Models;
using EthereumTXChecker.BLL.Services.FileManagerService;
using EthereumTXChecker.BLL.Services.OutputFormatterService;
using EthereumTXChecker.BLL.Services.RequestManagerService;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace EthereumTxChecker.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsCheck: Controller
    {
        private const string TABLENAME = "result";
        private readonly IFileManager _fileManager;
        private readonly IRequester _requester;
        private readonly IOutputFormatter _outputFormatter;
        public TransactionsCheck(IFileManager manager, IRequester requester, IOutputFormatter formatter)
        {
            _fileManager = manager;
            _requester = requester;
            _outputFormatter = formatter;
        }

        private List<string> GetWallets() => _fileManager.GetWallets();
        private List<string> GenerateEndpoints() => _requester.GenerateEndpoints(GetWallets());
        private DataTable GetDataTable() => _outputFormatter.GenerateDataTable(GetTransactionData());

        [HttpGet]
        public List<Result> GetTransactionData() => _requester.GetTransactionsData(GenerateEndpoints());

        [HttpGet("CreateTable")]
        public string CreateTable() => _outputFormatter.ExportXML(GetDataTable(), TABLENAME);

    }
}
