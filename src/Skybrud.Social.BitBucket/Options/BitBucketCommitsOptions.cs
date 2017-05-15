using Skybrud.Social.Http;
using Skybrud.Social.Interfaces.Http;

namespace Skybrud.Social.BitBucket.Options {

    public class BitBucketCommitsOptions : IHttpGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the page to be returned.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets the amount of commits to returned on each page.
        /// </summary>
        public int PageLength { get; set; }

        #endregion

        #region Member methods

        public IHttpQueryString GetQueryString() {
            SocialHttpQueryString qs = new SocialHttpQueryString();
            if (Page > 0) qs.Add("page", Page);
            if (PageLength > 0) qs.Add("pagelen", PageLength);
            return qs;
        }

        #endregion

    }

}