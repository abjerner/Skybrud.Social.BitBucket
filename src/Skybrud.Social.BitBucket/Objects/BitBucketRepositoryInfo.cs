using Newtonsoft.Json.Linq;
using Skybrud.Social.Json.Extensions.JObject;

namespace Skybrud.Social.BitBucket.Objects {

    public class BitBucketRepositoryInfo : BitBucketObject {

        #region Properties

        /// <summary>
        /// The full name of the repository. The full name can be described as "{accountName}/{repoSlug}".
        /// </summary>
        public string FullName { get; private set; }

        /// <summary>
        /// A collection of links related to the repository.
        /// </summary>
        public BitBucketLinkCollection Links { get; private set; }

        /// <summary>
        /// A link poiting to the user's profile in the API.
        /// </summary>
        public BitBucketLink LinkSelf {
            get { return Links.GetLink("self"); }
        }

        /// <summary>
        /// A link pointing to the user's profile at the BitBucket website.
        /// </summary>
        public BitBucketLink LinkHtml {
            get { return Links.GetLink("html"); }
        }

        #endregion

        #region Constructors

        private BitBucketRepositoryInfo(JObject obj) : base(obj) {
            FullName = obj.GetString("full_name");
            Links = obj.GetObject("links", BitBucketLinkCollection.Parse);
        }

        #endregion

        #region Static methods

        public static BitBucketRepositoryInfo Parse(JObject obj) {
            return obj == null ? null : new BitBucketRepositoryInfo(obj);
        }

        #endregion

    }

}