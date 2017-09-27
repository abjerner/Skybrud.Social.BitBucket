using System;
using Skybrud.Social.BitBucket.Models.Repositories;
using Skybrud.Social.Http;

namespace Skybrud.Social.BitBucket.Responses.Repositories {

    /// <summary>
    /// Class representing a response of a list of repositories of a BitBucket user/organization.
    /// </summary>
    public class BitBucketGetRepositoriesResponse : BitBucketResponse<BitBucketRepositoriesCollection> {

        #region Constructors

        private BitBucketGetRepositoriesResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);
            
            // Parse the response body
            Body = ParseJsonObject(response.Body, BitBucketRepositoriesCollection.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="BitBucketGetRepositoriesResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="BitBucketGetRepositoriesResponse"/>.</returns>
        public static BitBucketGetRepositoriesResponse ParseResponse(SocialHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new BitBucketGetRepositoriesResponse(response);
        }

        #endregion

    }

}