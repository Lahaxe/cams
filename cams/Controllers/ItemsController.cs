using cams.model.Items;
using System.Collections.Generic;
using System.Web.Http;

namespace cams.Controllers
{
    /// <summary>
    /// Defines the Item controller.
    /// </summary>
    [Authorize]
    [RoutePrefix("api/items")]
    public class ItemsController : ApiController
    {
        /// <summary>
        /// The Item repository.
        /// </summary>
        private IItemRepository Repository { get; }

        /// <summary>
        /// Initialize a new instance of <see cref="ItemsController"/>.
        /// </summary>
        /// <param name="repository">The item repository.</param>
        public ItemsController(IItemRepository repository)
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