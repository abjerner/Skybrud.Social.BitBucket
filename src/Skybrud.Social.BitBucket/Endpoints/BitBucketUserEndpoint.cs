using Skybrud.Social.BitBucket.Endpoints.Raw;
using Skybrud.Social.BitBucket.Responses.Users;

namespace Skybrud.Social.BitBucket.Endpoints {
    
    public class BitBucketUserEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the BitBucket service.
        /// </summary>
        public BitBucketService Service { get; private set; }

        /// <summary>
        /// Gets a reference to the raw user endpoint.
        /// </summary>
        public BitBucketUserRawEndpoint Raw {
            get { return Service.Client.User; }
        }

        #endregion

        #region Constructors

        internal BitBucketUserEndpoint(BitBucketService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about the authenticated user.
        /// </summary>
        /// <returns>Returns an instance of <see cref="BitBucketGetUserResponse"/> representing the response.</returns>
        public BitBucketGetUserResponse GetInfo() {
            return BitBucketGetUserResponse.ParseResponse(Raw.GetInfo());
        }

        /// <summary>
        /// Gets a list of emails of the authenticated user.
        /// </summary>
        /// <returns>Returns an instance of <see cref="BitBucketGetUserEmailsResponse"/> representing the response.</returns>
        public BitBucketGetUserEmailsResponse GetEmails() {
            return BitBucketGetUserEmailsResponse.ParseResponse(Raw.GetEmails());
        }

        /// <summary>
        /// Gets a list of email addresses of the authenticated user.
        /// </summary>
        /// <returns>Returns an instance of <see cref="BitBucketGetUserEmailsResponse"/> representing the raw response.</returns>
        public BitBucketGetUserEmailsResponse GetEmails(int page, int pageLength) {
            return BitBucketGetUserEmailsResponse.ParseResponse(Raw.GetEmails(page, pageLength));
        }


        ///// <summary>
        ///// Gets a list of repositories of the authenticated user.
        ///// </summary>
        //public BitBucketCurrentUserRepositoriesResponse GetRepositories() {
        //    return BitBucketCurrentUserRepositoriesResponse.ParseResponse(Raw.GetRepositories());
        //}

        #endregion

    }

}