using cams.model.Collections;
using System.Collections.Generic;
using System.Web.Http;

namespace cams.Controllers
{
    /// <summary>
    /// Defines the Collection controller.
    /// </summary>
    [Authorize]
    [RoutePrefix("api/collections")]
    public class CollectionsController : ApiController
    {
        /// <summary>
        /// The collection repository.
        /// </summary>
        private ICollectionRepository Repository { get; }

        /// <summary>
        /// Initialize a new instance of <see cref="CollectionsController"/>.
        /// </summary>
        /// <param name="repository">The collection repository.</param>
        public CollectionsController(ICollectionRepository repository)
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