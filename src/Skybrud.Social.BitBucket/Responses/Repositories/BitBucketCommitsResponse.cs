using Skybrud.Social.BitBucket.Objects.Repositories;
using Skybrud.Social.Http;
using BitBucketCommitsCollection = Skybrud.Social.BitBucket.Objects.Repositories.BitBucketCommitsCollection;

namespace Skybrud.Social.BitBucket.Responses.Repositories {
    
    public class BitBucketCommitsResponse : BitBucketResponse<BitBucketCommitsCollection> {

        #region Constructors

        private BitBucketCommitsResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, BitBucketCommitsCollection.Parse);

        }

        #endregion

        #region Static methods

        public static BitBucketCommitsResponse ParseResponse(SocialHttpResponse response) {
            return response == null ? null : new BitBucketCommitsResponse(response);
        }

        #endregion

    }

}