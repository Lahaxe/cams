﻿using cams.model.Core;
using cams.model.QueryParameters.Fields;
using cams.model.QueryParameters.Filters;
using cams.model.QueryParameters.Pages;
using cams.model.QueryParameters.Sorts;
using cams.model.Users;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace cams.Controllers
{
    /// <summary>
    /// Defines the user controller.
    /// </summary>
    [Authorize]
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        /// <summary>
        /// The user repository.
        /// </summary>
        private IUserRepository Repository { get; }

        /// <summary>
        /// Initialize a new instance of <see cref="UsersController"/>.
        /// </summary>
        /// <param name="repository">The user repository.</param>
        public UsersController(IUserRepository repository)
        {
            Repository = repository;
        }

        /// <summary>
        /// Get a list of <see cref="User"/>.
        /// </summary>
        /// <param name="lang">The language.</param>
        /// <param name="paging">The paging parameters.</param>
        /// <param name="sorting">The sorting parameters.</param>
        /// <param name="filtering">The filtering parameters.</param>
        /// <param name="fielding">The fielding parameters.</param>
        /// <returns>List of <see cref="User"/></returns>
        /// <response code="200">Return the pagined list of <see cref="User"/>.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="401">Authentication required.</response>
        /// <response code="403">Action not Allowed.</response>
        /// <response code="500">Internal Server Error.</response>
        [Route("")]
        [ResponseType(typeof(PagedCollection<User>))]
        public IHttpActionResult GetUsersList(string lang = null,
                                              PagingParameters paging = null,
                                              SortingParameters sorting = null,
                                              FilteringParameters filtering = null,
                                              FieldingParameters fielding = null)
        {
            try
            {
                if (paging == null)
                {
                    paging = new PagingParameters();
                }

                if (paging != null && !paging.IsValid)
                {
                    throw new ArgumentException(nameof(paging));
                }

                if (sorting != null && !sorting.IsValid)
                {
                    throw new ArgumentException(nameof(sorting));
                }

                if (filtering != null && !filtering.IsValid)
                {
                    throw new ArgumentException(nameof(filtering));
                }

                if (fielding != null && !fielding.IsValid)
                {
                    throw new ArgumentException(nameof(fielding));
                }

                return Ok(Repository.GetUsers(lang, paging, sorting, filtering, fielding));
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

        /// <summary>
        /// Gets an user by Id.
        /// </summary>
        /// <param name="id">The user identifier.</param>
        /// <returns>The requested user.</returns>
        /// <response code="200">Return the <see cref="User"/>.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="401">Authentication required.</response>
        /// <response code="403">Action not Allowed.</response>
        /// <response code="404">The resource code given in the URI does not correspond to any existing user.</response>
        /// <response code="500">Internal Server Error.</response>
        [Route("{id}")]
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(string id)
        {
            try
            {
                return Ok(Repository.GetUser(id));
            }
            catch (ArgumentException aex)
            {
                return BadRequest(aex.Message);
            }
            catch (SecurityException)
            {
                throw new HttpResponseException(HttpStatusCode.Forbidden);
            }
            catch (UserNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="user">The <see cref="User"/> to create</param>
        /// <returns>The created <see cref="User"/>.</returns>
        /// <response code="200">Return <see cref="User"/> created.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="401">Authentication required.</response>
        /// <response code="403">Action not Allowed.</response>
        /// <response code="500">Internal Server Error.</response>
        [Route("")]
        [HttpPost]
        [ResponseType(typeof(User))]
#pragma warning disable CS1998 // Cette méthode async n'a pas d'opérateur 'await' et elle s'exécutera de façon synchrone
        public async Task<IHttpActionResult> Post([FromBody]User user)
#pragma warning restore CS1998 // Cette méthode async n'a pas d'opérateur 'await' et elle s'exécutera de façon synchrone
        {
            try
            {
                return Ok(Repository.CreateUser(user));
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

        // PUT api/<controller>/5
        public void Put(string id, [FromBody]string value)
        {
        }

        /// <summary>
        /// Partially updates an <see cref="User"/>.
        /// </summary>
        /// <param name="user">The user to update.</param>
        /// <returns>Status.</returns>
        /// <response code="200">Return request ok.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="401">Authentication required.</response>
        /// <response code="403">Action not Allowed.</response>
        /// <response code="404">The resource code given does not correspond to any existing user.</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpPatch]
        [Route("")]
        public IHttpActionResult Patch([FromBody]User user)
        {
            try
            {
                Repository.PatchUser(user);
                return Ok();
            }
            catch (ArgumentException aex)
            {
                return BadRequest(aex.Message);
            }
            catch (SecurityException)
            {
                throw new HttpResponseException(HttpStatusCode.Forbidden);
            }
            catch (UserNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Deletes an user.
        /// </summary>
        /// <param name="id">The user identifier.</param>
        /// <response code="200">The user has been deleted.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="401">Authentication required.</response>
        /// <response code="403">Action not Allowed.</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(string id)
        {
            try
            {
                Repository.DeleteUser(id);
                return Ok();
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

        /// <summary>
        /// Deletes users.
        /// </summary>
        /// <param name="ids">List of user identifiers to delete.</param>
        /// <response code="200">The users has been deleted.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="401">Authentication required.</response>
        /// <response code="403">Action not Allowed.</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpDelete]
        [Route("")]
        public IHttpActionResult Delete(IList<string> ids)
        {
            try
            {
                Repository.DeleteUsers(ids);
                return Ok();
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
    }
}