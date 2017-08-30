using Skybrud.Social.BitBucket.Endpoints.Raw;
using Skybrud.Social.BitBucket.Options.Branches;
using Skybrud.Social.BitBucket.Responses.Branches;

namespace Skybrud.Social.BitBucket.Endpoints {
    
    /// <summary>
    /// Class representing the branches endpoint in the BitBucket API.
    /// </summary>
    public class BitBucketBranchesEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the BitBucket service.
        /// </summary>
        public BitBucketService Service { get; private set; }

        /// <summary>
        /// Gets a reference to the raw branches endpoint.
        /// </summary>
        public BitBucketBranchesRawEndpoint Raw {
            get { return Service.Client.Branches; }
        }

        #endregion
        
        #region Constructors

        internal BitBucketBranchesEndpoint(BitBucketService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about the branch matching the specified <paramref name="username"/>,
        /// <paramref name="repoSlug"/> and branch <paramref name="name"/>.
        /// </summary>
        /// <param name="username">The username of the user/organisation owning the repository.</param>
        /// <param name="repoSlug">The alias/slug of the repository.</param>
        /// <param name="name">The name of the branch.</param>
        /// <returns>An instance of <see cref="BitBucketGetBranchResponse"/> representing the response.</returns>
        public BitBucketGetBranchResponse GetBranch(string username, string repoSlug, string name) {
            return BitBucketGetBranchResponse.ParseResponse(Raw.GetBranch(username, repoSlug, name));
        }

        /// <summary>
        /// Gets a list of branches of the repository matching the specified <paramref name="username"/> and
        /// <paramref name="repoSlug"/>.
        /// </summary>
        /// <param name="username">The username of the user/organisation owning the repository.</param>
        /// <param name="repoSlug">The alias/slug of the repository.</param>
        /// <returns>An instance of <see cref="BitBucketGetBranchesResponse"/> representing the response.</returns>
        public BitBucketGetBranchesResponse GetBranches(string username, string repoSlug) {
            return BitBucketGetBranchesResponse.ParseResponse(Raw.GetBranches(username, repoSlug));
        }

        /// <summary>
        /// Gets a list of branches of the repository matching the <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="BitBucketGetBranchesResponse"/> representing the response.</returns>
        public BitBucketGetBranchesResponse GetBranches(BitBucketGetBranchesOptions options) {
            return BitBucketGetBranchesResponse.ParseResponse(Raw.GetBranches(options));
        }

        #endregion

    }

}