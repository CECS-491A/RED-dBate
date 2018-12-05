using ModelLayer;

namespace Authorization
{
    /// <summary>
    /// Authorization management class
    /// </summary>
    public class AuthorizationManager
    {
        /// <summary>
        /// 
        /// </summary>
        public User user = new User();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="claim"></param>
        /// <returns></returns>
        public bool CheckAccess(string claim)
        {
            bool access;

            if (user.CollectionClaims.Contains(claim))
            {
                access = true;
            }
            else
            {
                access = false;
            }

            return access;
        }
    }
}
