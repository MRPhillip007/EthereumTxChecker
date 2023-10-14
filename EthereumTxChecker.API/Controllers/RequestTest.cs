
using EthereumTXChecker.BLL.Services.RequestManagerService;
using Microsoft.AspNetCore.Mvc;

namespace EthereumTxChecker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestTest: Controller
    {
        private readonly IRequester _requester;

        public RequestTest(IRequester requester)
        {
            _requester = requester;
        }

        [HttpGet]
        public string GetApiKey() => _requester.GetApiKey();
    }
}
