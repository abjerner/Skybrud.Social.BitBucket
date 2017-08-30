using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.BitBucket.Models.Branches {
    
    /// <summary>
    /// Class representing a collection of BitBucket branches.
    /// </summary>
    public class BitBucketBranchesCollection : BitBucketObject {

        #region Properties

        /// <summary>
        /// Gets the maximum amount of branches per page.
        /// </summary>
        public int PageLength { get; private set; }

        /// <summary>
        /// Gets the current page.
        /// </summary>
        public int Page { get; private set; }

        /// <summary>
        /// Gets the total amount of branches.
        /// </summary>
        public int Size { get; private set; }

        /// <summary>
        /// Gets the branches on the current page.
        /// </summary>
        public BitBucketBranch[] Values { get; private set; }

        #endregion

        #region Constructors

        private BitBucketBranchesCollection(JObject obj) : base(obj) {
            PageLength = obj.GetInt32("pagelen");
            Page = obj.GetInt32("page");
            Size = obj.GetInt32("size");
            Values = obj.GetArray("values", BitBucketBranch.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="BitBucketBranchesCollection"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="BitBucketBranchesCollection"/>.</returns>
        public static BitBucketBranchesCollection Parse(JObject obj) {
            return obj == null ? null : new BitBucketBranchesCollection(obj);
        }

        #endregion

    }

}