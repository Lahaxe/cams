﻿using cams.model.Items.Stamps;
using System.Collections.Generic;
using System.Web.Http;

namespace cams.Controllers
{
    [Authorize]
    [RoutePrefix("api/stamps")]
    public class StampsController : ApiController
    {
        private IStampRepository Repository { get; }

        public StampsController(IStampRepository repository)
        {
            Repository = repository;
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}