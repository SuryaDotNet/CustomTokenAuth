using System;
namespace TokenAuth.TokenAuthentication
{
    /// <summary>
    /// Token Entity
    /// </summary>
    public class Token
    {
        public string Value { get; set; }
        
        public DateTime ExiryDate { get; set; }
    }
}
