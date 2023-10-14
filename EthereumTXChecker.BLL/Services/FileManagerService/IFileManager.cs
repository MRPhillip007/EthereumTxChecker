using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthereumTXChecker.BLL.Services.FileManagerService
{
    public interface IFileManager
    {
        public List<string> GetWallets();
    }
}
