using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.BitBucket.Objects.Repositories {
    
    public class BitBucketRepositoriesCollection : BitBucketObject {

        #region Properties

        /// <summary>
        /// Gets the amount of repositories in the current page.
        /// </summary>
        public int PageLength { get; private set; }

        /// <summary>
        /// Gets the repositories on the current page.
        /// </summary>
        public BitBucketRepository[] Values { get; private set; }

        /// <summary>
        /// Gets the current page.
        /// </summary>
        public int Page { get; private set; }

        /// <summary>
        /// Gets the total amount of repositories.
        /// </summary>
        public int Size { get; private set; }

        #endregion

        #region Constructors

        private BitBucketRepositoriesCollection(JObject obj) : base(obj) {
            PageLength = obj.GetInt32("pagelen");
            Values = obj.GetArray("values", BitBucketRepository.Parse);
            Page = obj.GetInt32("page");
            Size = obj.GetInt32("size");
        }

        #endregion

        #region Static methods

        public static BitBucketRepositoriesCollection Parse(JObject obj) {
            return obj == null ? null : new BitBucketRepositoriesCollection(obj);
        }

        #endregion

    }

}