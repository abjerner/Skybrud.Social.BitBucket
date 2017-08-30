using Skybrud.Social.Http;
using Skybrud.Social.Interfaces.Http;

namespace Skybrud.Social.BitBucket.Options.Branches {

    /// <summary>
    /// Class representing the options for getting a list of branches.
    /// </summary>
    public class BitBucketGetBranchesOptions : IHttpGetOptions {

        #region Properties
        
        /// <summary>
        /// Gets or sets the username of the user/organisation owning the repository.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the alias/slug of the repository.
        /// </summary>
        public string RepoSlug { get; set; }
        
        /// <summary>
        /// Gets or sets the page to be returned.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets the maximum amount of branches to returned on each page. Although not documented, the maximum page
        /// length seems to be <code>100</code>.
        /// </summary>
        public int PageLength { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public BitBucketGetBranchesOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="username"/> and <paramref name="repoSlug"/>.
        /// </summary>
        /// <param name="username">The username of the user/organisation owning the repository.</param>
        /// <param name="repoSlug">The alias/slug of the repository.</param>
        public BitBucketGetBranchesOptions(string username, string repoSlug) {
            Username = username;
            RepoSlug = repoSlug;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="username"/>, <paramref name="repoSlug"/> and <paramref name="page"/>.
        /// </summary>
        /// <param name="username">The username of the user/organisation owning the repository.</param>
        /// <param name="repoSlug">The alias/slug of the repository.</param>
        /// <param name="page">The page to be returned.</param>
        public BitBucketGetBranchesOptions(string username, string repoSlug, int page) {
            Username = username;
            RepoSlug = repoSlug;
            Page = page;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="username"/>, <paramref name="repoSlug"/>, <paramref name="page"/> and <paramref name="pageLength"/>.
        /// </summary>
        /// <param name="username">The username of the user/organisation owning the repository.</param>
        /// <param name="repoSlug">The alias/slug of the repository.</param>
        /// <param name="page">The page to be returned.</param>
        /// <param name="pageLength">The maximum amount of branches to returned on each page. Although not documented,
        /// the maximum page length seems to be <code>100</code>.</param>
        public BitBucketGetBranchesOptions(string username, string repoSlug, int page, int pageLength) {
            Username = username;
            RepoSlug = repoSlug;
            Page = page;
            PageLength = pageLength;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Generates an instance of <see cref="IHttpQueryString"/> representing the options.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpQueryString"/>.</returns>
        public IHttpQueryString GetQueryString() {

            SocialHttpQueryString qs = new SocialHttpQueryString();

            if (Page > 0) qs.Add("page", Page);
            if (PageLength > 0) qs.Add("pagelen", PageLength);

            return qs;

        }

        #endregion

    }

}