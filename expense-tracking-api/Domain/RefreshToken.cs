using System;
using expense_tracking_api.Infrastructure;

namespace expense_tracking_api.Domain
{
    public class RefreshToken : Entity
    {
        protected RefreshToken()
        {
            
        }

        public RefreshToken(
            string token,
            DateTime expires,
            User user)
        {
            Token = token;
            Expires = expires;
            User = user;
        }

        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public User User { get; set; }
        public bool Active => DateTime.UtcNow <= Expires;
    }
}