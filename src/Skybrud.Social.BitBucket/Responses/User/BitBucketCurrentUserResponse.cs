using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.BitBucket.Responses.User {

    public class BitBucketCurrentUserResponse : BitBucketResponse<BitBucketCurrentUserResponseBody> {

        #region Constructors

        private BitBucketCurrentUserResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, BitBucketCurrentUserResponseBody.Parse);
        
        }

        #endregion

        #region Static methods

        public static BitBucketCurrentUserResponse ParseResponse(SocialHttpResponse response) {
            return response == null ? null : new BitBucketCurrentUserResponse(response);
        }

        #endregion

    }

}