using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.BitBucket.Models.Branches {
    
    /// <summary>
    /// Class representing a branch of a BitBucket repository.
    /// </summary>
    public class BitBucketBranch : BitBucketObject {

        #region Properties

        /// <summary>
        /// Gets the type of the branch/object. Proably always returns <code>branch</code>.
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// Gets the name of the branch.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets a collection of URLs related to the branch.
        /// </summary>
        public BitBucketBranchLinkCollection Links { get; private set; }

        // TODO: Add support for the "target" property

        #endregion

        #region Constructors

        private BitBucketBranch(JObject obj) : base(obj) {
            Type = obj.GetString("type");
            Name = obj.GetString("name");
            Links = obj.GetObject("links", BitBucketBranchLinkCollection.Parse);
            // TODO: Add support for the "target" property
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="BitBucketBranch"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="BitBucketBranch"/>.</returns>
        public static BitBucketBranch Parse(JObject obj) {
            return obj == null ? null : new BitBucketBranch(obj);
        }

        #endregion

    }

}