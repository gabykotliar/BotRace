using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TestController
    {
        public string Get() {
            return "anda";
        }
    }
}
