using Skybrud.Social.BitBucket.Models.Branches;
using Skybrud.Social.Http;

namespace Skybrud.Social.BitBucket.Responses.Branches {

    /// <summary>
    /// Class representing a response with a collection of branches.
    /// </summary>
    public class BitBucketGetBranchesResponse : BitBucketResponse<BitBucketBranchesCollection> {

        #region Constructors

        private BitBucketGetBranchesResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);
            
            // Parse the response body
            Body = ParseJsonObject(response.Body, BitBucketBranchesCollection.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="BitBucketGetBranchesResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="SocialHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="BitBucketGetBranchesResponse"/> representing the response.</returns>
        public static BitBucketGetBranchesResponse ParseResponse(SocialHttpResponse response) {
            return response == null ? null : new BitBucketGetBranchesResponse(response);
        }

        #endregion

    }

}