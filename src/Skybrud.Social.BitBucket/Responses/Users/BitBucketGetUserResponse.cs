using System;
using Skybrud.Social.BitBucket.Models.Users;
using Skybrud.Social.Http;

namespace Skybrud.Social.BitBucket.Responses.Users {

    /// <summary>
    /// Class representing the response of a call to get information about a given user.
    /// </summary>
    public class BitBucketGetUserResponse : BitBucketResponse<BitBucketUser> {

        #region Constructor

        private BitBucketGetUserResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, BitBucketUser.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <see cref="BitBucketGetUserResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <see cref="BitBucketGetUserResponse"/>.</returns>
        public static BitBucketGetUserResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Initialize the response object
            return new BitBucketGetUserResponse(response);

        }

        #endregion

    }

}