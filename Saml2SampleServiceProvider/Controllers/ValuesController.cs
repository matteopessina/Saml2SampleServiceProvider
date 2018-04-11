using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace Saml2SampleServiceProvider.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        [Authorize]
        public IHttpActionResult Get()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            return Ok(claimsIdentity.Claims);
        }

        // GET api/values/5
        [Authorize(Roles = "Administrator")]
        public string Get(int id)
        {
            return "You are an administrator";
        }
    }
}
