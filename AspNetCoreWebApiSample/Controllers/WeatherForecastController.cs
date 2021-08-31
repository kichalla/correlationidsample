using BusinessLogicLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebApiSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<ValuesController> _logger;
        private readonly ITransactionManager _transactionManager;

        public ValuesController(
            ILogger<ValuesController> logger,
            ITransactionManager transactionManager)
        {
            _logger = logger;
            _transactionManager = transactionManager;
        }

        [HttpGet]
        public string Get()
        {
            _transactionManager.SendMoney(new TransferInfo());
            return "Done";
        }
    }
}
