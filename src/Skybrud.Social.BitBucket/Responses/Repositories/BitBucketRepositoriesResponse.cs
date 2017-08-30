using Skybrud.Social.BitBucket.Models.Repositories;
using Skybrud.Social.Http;

namespace Skybrud.Social.BitBucket.Responses.Repositories {

    public class BitBucketRepositoriesResponse : BitBucketResponse<BitBucketRepositoriesCollection> {

        #region Constructors

        private BitBucketRepositoriesResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);
            
            // Parse the response body
            Body = ParseJsonObject(response.Body, BitBucketRepositoriesCollection.Parse);

        }

        #endregion

        #region Static methods

        public static BitBucketRepositoriesResponse ParseResponse(SocialHttpResponse response) {
            return response == null ? null : new BitBucketRepositoriesResponse(response);
        }

        #endregion

    }

}