using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected int GetUserIdFromToken()
        {
            var userIdString = User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
            if (int.TryParse(userIdString, out int userId))
            {
                return userId;
            }
            return 0;
        }
        protected int IsUser() 
        {
        
        }
    }
}
