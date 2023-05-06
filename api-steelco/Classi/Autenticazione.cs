using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using api_steelco.Controllers;
using Microsoft.AspNetCore.Authentication;
using System.Net.Http.Headers;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;
using System.Security.Claims;

namespace api_steelco
{
    public class BasicAuthenticationHandler: AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private IConfiguration _configuration;
        public BasicAuthenticationHandler(IConfiguration configuration, IOptionsMonitor<AuthenticationSchemeOptions> option, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock):base(option, logger, encoder,clock)
        {
            _configuration = configuration;
                      
        }

        protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("No auth Header");
            }
            var _headervalue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            var bytes = Convert.FromBase64String(_headervalue.Parameter);
            string credential = Encoding.UTF8.GetString(bytes);
            if(string.IsNullOrEmpty(credential))
            {
                return AuthenticateResult.Fail("");
            }
            string[] array = credential.Split(':');
            string username = array[0];
            string password = array[1];
            if (!IsValidUser(username, password))
            {
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }
            var claim = new[] { new Claim(ClaimTypes.Name, username)};
            var identity = new ClaimsIdentity(claim, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            return AuthenticateResult.Success(ticket);
        }

        private bool IsValidUser(string username, string password)
        {
            if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password)) return false;
            UtenteLogic d = new UtenteLogic(_configuration);
            return d.AdminLogin(username, password);
        }
    }
}
