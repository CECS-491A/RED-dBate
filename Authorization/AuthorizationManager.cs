namespace Authorization
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthorizationManager
    {
        /// <summary>
        /// 
        /// </summary>
        public Identity identity = new Identity();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="claim"></param>
        /// <returns></returns>
        public bool CheckAccess(string claim)
        {
            bool access;

            if (identity.CollectionClaims.Contains(claim))
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
