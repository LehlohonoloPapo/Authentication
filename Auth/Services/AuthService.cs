using Auth.Models;

namespace Auth.Services
{
    public  class AuthService
    {
        private readonly string _dbConfig;//= config;


        public  AuthResponse GetUser(AuthRequest authRequest)
        {
            if(authRequest == null)
            {
                throw new ArgumentNullException(nameof(authRequest));
            }
            var n = new AuthResponse();
            n.FirstName = authRequest.UserName;
            n.Username = "Admin";

            return  n;

        }
    }
}
