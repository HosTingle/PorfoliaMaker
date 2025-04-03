using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected int GetUserIdFromToken()
        {
            var token = Request.Cookies["AuthToken"];

            if (string.IsNullOrEmpty(token))
            {
                return 0;
            }

            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

                if (jsonToken == null)
                {
                    return 0;
                }

                
                var userIdClaim = jsonToken?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                if (int.TryParse(userIdClaim, out int userId))
                {
                    return userId;
                }

                return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        protected string GetUserUsername()
        {
            var token = Request.Cookies["AuthToken"];

            if (string.IsNullOrEmpty(token))
            {
                return null;
            }

            try
            {
          
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

                if (jsonToken == null)
                {
                    return null;
                }


                var userIdClaim = jsonToken?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

                if (userIdClaim!=null)
                {
                    return userIdClaim;
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
