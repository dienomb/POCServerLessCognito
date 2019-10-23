using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POCServerLessCognito.Auth;

namespace POCServerLessCognito.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [Authorize(Policies.ViewPayments)]
        public string Get(int id)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;

            // alternatively
            // claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;

            // iterate all claims
            var claims= string.Empty;
            foreach (var claim in claimsIdentity.Claims)
            {
                claims += $"| {claim.Type} : { claim.Value} |\n";
            }
            return "Claims: \n" + claims;
        }

        // POST api/values
        [HttpPost]
        [Authorize(Policies.MakePayments)]
        public void Post([FromBody]string value)
        {
            Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
