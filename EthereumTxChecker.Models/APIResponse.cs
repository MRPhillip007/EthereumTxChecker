using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthereumTxChecker.Models
{

    public class Result
    {
        public string BlockNumber { get; set; }
        public string TimeStamp { get; set; }
        public string Hash { get; set; }
        public string Nonce {  get; set; }
        public string BlockHash { get; set; }
        public string transactionIndex { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Value { get; set; }
        public string Gas { get; set; }
        public string GasPrice { get; set; }
        public string IsError { get; set; }
        public string Txreceipt_status { get; set; }
        public string Input { get; set; }
        public string ContractAddress { get; set; }
        public string CumulativeGasUsed { get; set; }
        public string GasUsed { get; set; }
        public string Confirmations { get; set; }
        public string MethodId { get; set; }
        public string FunctionName { get; set; }
    }
    public class APIResponse
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public Result[] Result { get; set; }
    }
}
