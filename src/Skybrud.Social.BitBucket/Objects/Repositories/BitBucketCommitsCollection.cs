using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.BitBucket.Objects.Repositories {

    public class BitBucketCommitsCollection : BitBucketObject {

        #region Properties

        /// <summary>
        /// Gets the amount of commits in the current page.
        /// </summary>
        public int PageLength { get; private set; }

        /// <summary>
        /// Gets the commits on the current page.
        /// </summary>
        public BitBucketCommit[] Values { get; private set; }

        /// <summary>
        /// Gets the current page.
        /// </summary>
        public int Page { get; private set; }

        /// <summary>
        /// A link for the next page (might not be specified).
        /// </summary>
        public string Next { get; private set; }

        /// <summary>
        /// Whether there is a more pages.
        /// </summary>
        public bool HasNext {
            get { return !string.IsNullOrWhiteSpace(Next); }
        }

        #endregion

        #region Constructors

        private BitBucketCommitsCollection(JObject obj)
            : base(obj) {
            PageLength = obj.GetInt32("pagelen");
            Values = obj.GetArray("values", BitBucketCommit.Parse);
            Page = obj.GetInt32("page");
            Next = obj.GetString("next");
        }

        #endregion

        #region Static methods

        public static BitBucketCommitsCollection Parse(JObject obj) {
            return obj == null ? null : new BitBucketCommitsCollection(obj);
        }

        #endregion

    }

}