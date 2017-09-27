using Skybrud.Essentials.Strings;
using Skybrud.Social.BitBucket.Models.Common;
using Skybrud.Social.BitBucket.Models.Repositories;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces.Http;

namespace Skybrud.Social.BitBucket.Options.Repositories {
    
    /// <summary>
    /// Class representing the options for getting a list of repositories of a BitBucket user.
    /// </summary>
    public class BitBucketGetRepositoriesOptions : IHttpGetOptions {

        #region Properties
        
        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the page to be returned.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets the amount of repositories to returned on each page. Although not documented, the maximum page
        /// length seems to be <code>100</code>.
        /// </summary>
        public int PageLength { get; set; }

        /// <summary>
        /// Gets or sets the field that the repositories should be sorted by. The API documentation doesn't specify a
        /// default sort order, so this is represented by <see cref="BitBucketRepositoryField.Unspecified"/>.
        /// </summary>
        public BitBucketRepositoryField SortField { get; set; }

        /// <summary>
        /// Gets or sets the order by which the repositories should be sorted. Default is <see cref="BitBucketSortOrder.Ascending"/>.
        /// </summary>
        public BitBucketSortOrder SortOrder { get; set; }

        // TODO: Add support for the "role" option

        // TODO: Add support for the "q" option (query/filter)

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public BitBucketGetRepositoriesOptions() { }

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public BitBucketGetRepositoriesOptions(string username) {
            Username = username;
        }

        public BitBucketGetRepositoriesOptions(string username, int pageLength) {
            Username = username;
            PageLength = pageLength;
        }

        public BitBucketGetRepositoriesOptions(string username, int pageLength, int page) {
            Username = username;
            PageLength = pageLength;
            Page = page;
        }

        #endregion

        #region Member methods

        public IHttpQueryString GetQueryString() {

            SocialHttpQueryString qs = new SocialHttpQueryString();

            if (Page > 0) qs.Add("page", Page);
            if (PageLength > 0) qs.Add("pagelen", PageLength);

            if (SortField != BitBucketRepositoryField.Unspecified) {
                string name = StringUtils.ToUnderscore(SortField);
                qs.Add("sort", (SortOrder == BitBucketSortOrder.Descending ? "-" : "") + name);
            }

            return qs;

        }

        #endregion

    }

}