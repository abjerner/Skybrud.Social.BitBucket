using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.BitBucket.Models.Repositories {
    
    /// <summary>
    /// Class representing a collection of BitBucket repositories.
    /// </summary>
    public class BitBucketRepositoriesCollection : BitBucketObject, IEnumerable<BitBucketRepository> {

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

        #region Member methods

        /// <summary>
        /// Gets a reference to a enumerator for the repositories in the collection.
        /// </summary>
        /// <returns>An instance of <see cref="IEnumerator{BitBucketRepository}"/>.</returns>
        public IEnumerator<BitBucketRepository> GetEnumerator() {
            return ((IEnumerable<BitBucketRepository>) Values).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="BitBucketRepositoriesCollection"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="BitBucketRepositoriesCollection"/>.</returns>
        public static BitBucketRepositoriesCollection Parse(JObject obj) {
            return obj == null ? null : new BitBucketRepositoriesCollection(obj);
        }
        
        #endregion

    }

}