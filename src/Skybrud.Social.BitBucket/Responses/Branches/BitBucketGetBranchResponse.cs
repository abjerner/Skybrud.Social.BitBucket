using Skybrud.Social.BitBucket.Models.Branches;
using Skybrud.Social.Http;

namespace Skybrud.Social.BitBucket.Responses.Branches {

    /// <summary>
    /// Class representing a response with a information about a single branch.
    /// </summary>
    public class BitBucketGetBranchResponse : BitBucketResponse<BitBucketBranch> {

        #region Constructors

        private BitBucketGetBranchResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);
            
            // Parse the response body
            Body = ParseJsonObject(response.Body, BitBucketBranch.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="BitBucketGetBranchResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="SocialHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="BitBucketGetBranchResponse"/> representing the response.</returns>
        public static BitBucketGetBranchResponse ParseResponse(SocialHttpResponse response) {
            return response == null ? null : new BitBucketGetBranchResponse(response);
        }

        #endregion

    }

}