using Skybrud.Social.BitBucket.Objects;
using Skybrud.Social.Http;

namespace Skybrud.Social.BitBucket.Responses.User {

    public class BitBucketCurrentUserRepositoriesResponse : BitBucketResponse<BitBucketUserRepository[]> {

        #region Constructors

        private BitBucketCurrentUserRepositoriesResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonArray(response.Body, BitBucketUserRepository.Parse);

        }

        #endregion

        #region Static methods

        public static BitBucketCurrentUserRepositoriesResponse ParseResponse(SocialHttpResponse response) {
            return response == null ? null : new BitBucketCurrentUserRepositoriesResponse(response);
        }

        #endregion

    }

}