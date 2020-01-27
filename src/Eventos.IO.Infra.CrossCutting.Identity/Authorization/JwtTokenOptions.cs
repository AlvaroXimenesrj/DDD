
using Microsoft.IdentityModel.Tokens;
using System;
using System.Threading.Tasks;

namespace Eventos.IO.Infra.CrossCutting.Identity.Authorization
{
    public class JwtTokenOptions
    {
        public string Issuer { get; set; }

        public string Subject { get; set; }
        // para qual site é válido
        public string Audience { get; set; }

        public DateTime NotBefore { get; set; } = DateTime.UtcNow;
        // quando foi emitido
        public DateTime IssuedAt { get; set; } = DateTime.UtcNow;
        // até quando é válido
        public TimeSpan ValidFor { get; set; } = TimeSpan.FromHours(5);

        public DateTime Expiration => IssuedAt.Add(ValidFor);
        // 
        public Func<Task<string>> JtiGenerator => () => Task.FromResult(Guid.NewGuid().ToString());
        //
        public SigningCredentials SigningCredentials { get; set; }
    }
}