using cams.model.Items.Stamps;
using System.Collections.Generic;
using System.Web.Http;

namespace cams.Controllers
{
    /// <summary>
    /// Defines the Stamp controller.
    /// </summary>
    [Authorize]
    [RoutePrefix("api/stamps")]
    public class StampsController : ApiController
    {
        /// <summary>
        /// The stamp repository.
        /// </summary>
        private IStampRepository Repository { get; }

        /// <summary>
        /// Initialize a new instance of <see cref="StampsController"/>.
        /// </summary>
        /// <param name="repository">The stamp repository.</param>
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