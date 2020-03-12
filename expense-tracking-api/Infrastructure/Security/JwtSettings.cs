using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace expense_tracking_api.Infrastructure.Security
{
    public class JwtSettings
    {
        public string SecurityKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }

        public SigningCredentials SigningCredentials =>
            new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.ASCII.GetBytes(SecurityKey)),
                SecurityAlgorithms.HmacSha256Signature);
    }
}