namespace TokenAuth.TokenAuthentication
{
    /// <summary>
    /// Interface for Token Generaterion to Verification Process
    /// </summary>
    public interface ITokenManager
    {
        //Authenticate User
        bool AuthenticateUser(string userName, string password);
        //Generate new token if user is authenticated 
        Token NewToken();
        //Verify Token Validity
        bool VerifyToken(string token);
    }
}