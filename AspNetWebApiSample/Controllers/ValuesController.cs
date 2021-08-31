using BusinessLogicLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AspNetWebApiSample.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly ITransactionManager _transactionManager;

        public ValuesController(ITransactionManager transactionManager)
        {
            _transactionManager = transactionManager;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            _transactionManager.SendMoney(new TransferInfo());
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
