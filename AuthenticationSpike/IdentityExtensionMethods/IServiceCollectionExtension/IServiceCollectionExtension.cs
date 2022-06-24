using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AuthenticationSpike.JwtToken;

namespace AuthenticationSpike.IdentityExtensionMethods.IServiceCollectionExtension

{
    public static class IserviceCollectionExtension

    {
        public static void AddJwtTokenConfiguration(this IServiceCollection services, string jwtConfig)
        {
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }
        )
        .AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtConfig,
                    ValidAudience = jwtConfig,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig))
                };
            });
        }
        public static void AddAuthorizationPolicy(this IServiceCollection services)
        {
            services.AddAuthorization();
        }
    }

 
}
         