using System;
using System.Collections.Generic;
using System.Linq;

namespace TokenAuth.TokenAuthentication
{
    /// <summary>
    /// TokenManager Middleware Logic 
    /// </summary>
    public class TokenManager : ITokenManager
    {
        private List<Token> tokenList;
        public TokenManager()
        {
            tokenList = new List<Token>();
        }
        public bool AuthenticateUser(string userName, string password)
        {
           var users =  UserEntity.Instance.LoadUserData();
            //check user details in inmemory users list
            var user = (users.SingleOrDefault(a=> a.UserName.ToLower() == userName && a.Password == password));
            if(user != null)
                return true;
            else
                return false;
        }

        public Token NewToken()
        {
            var token = new Token
            {
                Value = Guid.NewGuid().ToString(),
                ExiryDate = DateTime.Now.AddHours(8.0)
            };
            tokenList.Add(token);
            return token;
        }

        public bool VerifyToken(string token)
        {
            if (tokenList.Any(x => x.Value == token && x.ExiryDate > DateTime.Now))
            {
                return true;
            }
            return false;
        }
    }
}
