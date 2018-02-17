using cams.model.Core;
using cams.model.Users;
using System;
using System.Net;
using System.Security;
using System.Web.Http;
using System.Web.Http.Description;

namespace cams.Controllers
{
    [Authorize]
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private IUserRepository Repository { get; }

        public UsersController(IUserRepository repository)
        {
            Repository = repository;
        }

        // GET api/<controller>
        [ResponseType(typeof(PagedCollection<User>))]
        public IHttpActionResult GetUsersList()
        {
            try
            {
                return Ok(Repository.GetUsers());
            }
            catch (ArgumentException aex)
            {
                return BadRequest(aex.Message);
            }
            catch (SecurityException)
            {
                throw new HttpResponseException(HttpStatusCode.Forbidden);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET api/<controller>/{id}
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(string id)
        {
            try
            {
                return Ok(Repository.GetUser());
            }
            catch (ArgumentException aex)
            {
                return BadRequest(aex.Message);
            }
            catch (SecurityException)
            {
                throw new HttpResponseException(HttpStatusCode.Forbidden);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(string id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(string id)
        {
        }
    }
}