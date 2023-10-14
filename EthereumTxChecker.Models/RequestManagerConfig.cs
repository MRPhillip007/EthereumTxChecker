using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthereumTxChecker.Models
{
    public class RequestManagerConfig
    {
        public string EtherscanApiKey { get; set; }

        // private string GetApiKey() => Environment.GetEnvironmentVariable("ETHERSCANAPIKEY");
    }

}
