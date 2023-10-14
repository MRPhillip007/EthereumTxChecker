using EthereumTxChecker.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.IO;


namespace EthereumTXChecker.BLL.Services.FileManagerService
{
    public class FileManager : IFileManager
    {
        private readonly FileManagerConfig _fileManagerConfig;

        public FileManager(IOptions<FileManagerConfig> _fileConfig)
        {
            _fileManagerConfig = _fileConfig.Value;
        }
        public List<string> GetWallets()
        {
            using (StreamReader reader = new StreamReader(GetFilePath()))
            {
                List<string> wallets = reader.ReadToEnd().Split('\n').ToList();
                return wallets;
            }
        }

        private string GetFilePath()
        {
            return Directory.GetParent(path: Directory.GetCurrentDirectory()).ToString() + _fileManagerConfig.Path + _fileManagerConfig.FileName;
        }
    }
}
