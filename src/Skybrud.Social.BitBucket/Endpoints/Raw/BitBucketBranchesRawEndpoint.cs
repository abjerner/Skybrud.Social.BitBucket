using System;
using Skybrud.Social.BitBucket.OAuth;
using Skybrud.Social.BitBucket.Options.Branches;
using Skybrud.Social.Http;

namespace Skybrud.Social.BitBucket.Endpoints.Raw {
    
    /// <summary>
    /// Class representing the raw branches endpoint.
    /// </summary>
    public class BitBucketBranchesRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the BitBucket OAuth client.
        /// </summary>
        public BitBucketOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal BitBucketBranchesRawEndpoint(BitBucketOAuthClient client) {
            Client = client;
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
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public SocialHttpResponse GetBranch(string username, string repoSlug, string name) {
            if (String.IsNullOrWhiteSpace(username)) throw new ArgumentNullException(nameof(username));
            if (String.IsNullOrWhiteSpace(repoSlug)) throw new ArgumentNullException(nameof(repoSlug));
            if (String.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            return Client.DoHttpGetRequest($"/2.0/repositories/{username}/{repoSlug}/refs/branches/" + name);
        }

        /// <summary>
        /// Gets a list of branches of the repository matching the specified <paramref name="username"/> and
        /// <paramref name="repoSlug"/>.
        /// </summary>
        /// <param name="username">The username of the user/organisation owning the repository.</param>
        /// <param name="repoSlug">The alias/slug of the repository.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public SocialHttpResponse GetBranches(string username, string repoSlug) {
            if (String.IsNullOrWhiteSpace(username)) throw new ArgumentNullException(nameof(username));
            if (String.IsNullOrWhiteSpace(repoSlug)) throw new ArgumentNullException(nameof(repoSlug));
            return Client.DoHttpGetRequest($"/2.0/repositories/{username}/{repoSlug}/refs/branches");
        }

        /// <summary>
        /// Gets a list of branches of the repository matching the <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public SocialHttpResponse GetBranches(BitBucketGetBranchesOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            if (String.IsNullOrWhiteSpace(options.Username)) throw new ArgumentNullException(nameof(options.Username));
            if (String.IsNullOrWhiteSpace(options.RepoSlug)) throw new ArgumentNullException(nameof(options.RepoSlug));
            return Client.DoHttpGetRequest($"/2.0/repositories/{options.Username}/{options.RepoSlug}/refs/branches", options);
        }

        #endregion

    }

}