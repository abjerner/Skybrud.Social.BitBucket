using Newtonsoft.Json.Linq;

namespace Skybrud.Social.BitBucket.Objects.Users {

    /// <summary>
    /// Class representing the <code>links</code> object/collection of a BitBucket user.
    /// </summary>
    public class BitBucketUserLinkCollection : BitBucketLinkCollection {

        #region Properties
        
        public BitBucketLink Hooks { get; private set; }
        public BitBucketLink Self { get; private set; }
        public BitBucketLink Repositories { get; private set; }
        public BitBucketLink Html { get; private set; }
        public BitBucketLink Followers { get; private set; }
        public BitBucketLink Avatar { get; private set; }
        public BitBucketLink Following { get; private set; }
        public BitBucketLink Snippets { get; private set; }

        #endregion

        #region Constructors

        private BitBucketUserLinkCollection(JObject obj) : base(obj) {
            Hooks = GetLink("hooks");
            Self = GetLink("self");
            Repositories = GetLink("repositories");
            Html = GetLink("html");
            Followers = GetLink("followers");
            Avatar = GetLink("avatar");
            Following = GetLink("following");
            Snippets = GetLink("snippets");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="BitBucketUserLinkCollection"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="BitBucketUserLinkCollection"/>.</returns>
        public new static BitBucketUserLinkCollection Parse(JObject obj) {
            return obj == null ? null : new BitBucketUserLinkCollection(obj);
        }

        #endregion

    }

}