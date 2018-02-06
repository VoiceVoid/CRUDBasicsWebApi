using CRUDBasicsWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRUDBasicsWebApi.Controllers
{
    public class AspNetUsersController : ApiController
    {
		private ApplicationDbContext Context = new ApplicationDbContext();
		public IHttpActionResult Get() {
			var retval = Context.Users.Select(x => new { Id = x.Id, Email = x.Email });
			return Ok(retval);
		}
    }
}
