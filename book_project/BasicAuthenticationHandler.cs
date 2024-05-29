using System;
using Microsoft.AspNetCore.Authentication;

namespace book_project {
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions> {
        public BasicAuthenticationHandler(Microsoft.Extensions.Options.IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, System.Text.Encodings.Web.UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock) {
            
        }

        protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            return AuthenticateResult.Fail("");
        }
    }
}