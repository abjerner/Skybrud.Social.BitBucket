using System;
using Skybrud.Social.BitBucket.Objects.Users;
using Skybrud.Social.Http;

namespace Skybrud.Social.BitBucket.Responses.Users {

    public class BitBucketGetUserResponse : BitBucketResponse<BitBucketUserResponseBody> {

        #region Constructor

        private BitBucketGetUserResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, BitBucketUserResponseBody.Parse);

        }

        #endregion

        #region Static methods

        public static BitBucketGetUserResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Initialize the response object
            return new BitBucketGetUserResponse(response);

        }

        #endregion

    }

}