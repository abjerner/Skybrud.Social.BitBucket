using Skybrud.Social.BitBucket.OAuth;
using Skybrud.Social.Http;

namespace Skybrud.Social.BitBucket.Endpoints.Raw {
    
    public class BitBucketUsersRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the BitBucket OAuth client.
        /// </summary>
        public BitBucketOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        public BitBucketUsersRawEndpoint(BitBucketOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about the user with the specified <code>username</code>.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response from the BitBucket API.</returns>
        /// <see>
        ///     <cref>https://confluence.atlassian.com/bitbucket/users-endpoint-423626336.html#usersEndpoint-GETtheuserprofile</cref>
        /// </see>
        public SocialHttpResponse GetInfo(string username) {
            return Client.DoHttpGetRequest("https://api.bitbucket.org/2.0/users/" + username);
        }

        #endregion

    }

}