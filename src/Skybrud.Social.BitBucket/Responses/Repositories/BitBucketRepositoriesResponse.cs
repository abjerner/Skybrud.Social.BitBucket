using Skybrud.Social.BitBucket.Objects.Repositories;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.BitBucket.Responses.Repositories {

    public class BitBucketRepositoriesResponse : BitBucketResponse<BitBucketRepositoriesCollection> {

        #region Constructors

        private BitBucketRepositoriesResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static BitBucketRepositoriesResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new BitBucketRepositoriesResponse(response) {
                Body = JsonObject.ParseJson(response.Body, BitBucketRepositoriesCollection.Parse)
            };

        }

        #endregion

    }

}