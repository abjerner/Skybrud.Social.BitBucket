using Newtonsoft.Json.Linq;

namespace Skybrud.Social.BitBucket.Models.Branches {

    /// <summary>
    /// Class representing the <code>links</code> object/collection of a BitBucket branch.
    /// </summary>
    public class BitBucketBranchLinkCollection : BitBucketLinkCollection {

        #region Properties
        
        public BitBucketLink Commits { get; private set; }

        public BitBucketLink Self { get; private set; }

        public BitBucketLink Html { get; private set; }

        #endregion

        #region Constructors

        private BitBucketBranchLinkCollection(JObject obj) : base(obj) {
            Commits = GetLink("commits");
            Self = GetLink("self");
            Html = GetLink("html");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="BitBucketBranchLinkCollection"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="BitBucketBranchLinkCollection"/>.</returns>
        public new static BitBucketBranchLinkCollection Parse(JObject obj) {
            return obj == null ? null : new BitBucketBranchLinkCollection(obj);
        }

        #endregion

    }

}