using Business.Constants;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Core.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
namespace Business.BusinessAspects.Autofac
{
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
#pragma warning disable CS8601 // Possible null reference assignment.
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
#pragma warning restore CS8601 // Possible null reference assignment.

        }

        protected override void OnBefore(IInvocation invocation)
        {
            var token = _httpContextAccessor.HttpContext.Request.Cookies["AuthToken"];
            if (string.IsNullOrEmpty(token))
            {
                throw new AuthorizationException(Messages.AuthorizationDenied);
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);

            var roleClaims = jwtToken.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();

            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new AuthorizationException(Messages.AuthorizationDenied);
        }
    }
}
