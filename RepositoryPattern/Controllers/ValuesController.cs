using System;
using System.Collections.Generic;
using Data.EntityFramework;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Data.UnitOfWork;

namespace RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public ValuesController(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Data.EntityFramework.UserLogin>> Get()
        {
            IEnumerable<Data.EntityFramework.UserLogin> data;
            using (var uow = _unitOfWork)
            {
                data = uow.Repository<UserLogin>().GetAll();
            }
                return data.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
