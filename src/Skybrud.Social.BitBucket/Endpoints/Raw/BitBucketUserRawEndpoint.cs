using Skybrud.Social.BitBucket.OAuth;
using Skybrud.Social.Http;

namespace Skybrud.Social.BitBucket.Endpoints.Raw {
    
    public class BitBucketUserRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the BitBucket OAuth client.
        /// </summary>
        public BitBucketOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        public BitBucketUserRawEndpoint(BitBucketOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about the authenticated user.
        /// </summary>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://confluence.atlassian.com/bitbucket/user-endpoint-2-0-744527199.html#userendpoint2.0-GETauserprofile</cref>
        /// </see>
        public SocialHttpResponse GetInfo() {
            return Client.DoHttpGetRequest("https://api.bitbucket.org/2.0/user");
        }

        /// <summary>
        /// Gets a list of up to the first <code>10</code> email addresses of the authenticated user.
        /// </summary>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://confluence.atlassian.com/bitbucket/user-endpoint-2-0-744527199.html#userendpoint2.0-GETemailforauser</cref>
        /// </see>
        public SocialHttpResponse GetEmails() {
            return GetEmails(0, 0);
        }

        /// <summary>
        /// Gets a list of email addresses of the authenticated user.
        /// </summary>
        /// <param name="page">The page to be returned.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://confluence.atlassian.com/bitbucket/user-endpoint-2-0-744527199.html#userendpoint2.0-GETemailforauser</cref>
        /// </see>
        public SocialHttpResponse GetEmails(int page) {
            return GetEmails(page, 0);
        }

        /// <summary>
        /// Gets a list of email addresses of the authenticated user.
        /// </summary>
        /// <param name="page">The page to be returned.</param>
        /// <param name="pageLength">The maximum amount of email addresses to be returned by each page.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://confluence.atlassian.com/bitbucket/user-endpoint-2-0-744527199.html#userendpoint2.0-GETemailforauser</cref>
        /// </see>
        public SocialHttpResponse GetEmails(int page, int pageLength) {
            SocialQueryString query = new SocialQueryString();
            if (page > 0) query.Add("page", page);
            if (pageLength > 0) query.Add("pagelen", pageLength);
            return Client.DoHttpGetRequest("https://api.bitbucket.org/2.0/user/emails", query);
        }

        /// <summary>
        /// Gets a list of repositories of the authenticated user.
        /// </summary>
        public SocialHttpResponse GetRepositories() {
            return Client.DoHttpGetRequest("https://bitbucket.org/api/1.0/user/repositories/");
        }

        #endregion

    }

}