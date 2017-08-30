using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.BitBucket.Models.Users {

    /// <summary>
    /// Class describing a BitBucket user.
    /// </summary>
    public class BitBucketUserEmailsCollection : BitBucketObject {

        #region Properties

        /// <summary>
        /// Gets the maximum amount of email addresses listed on each page.
        /// </summary>
        public int PageLength { get; private set; }

        /// <summary>
        /// Gets an array of email addresses on the returned page.
        /// </summary>
        public BitBucketUserEmail[] Values { get; private set; }

        /// <summary>
        /// Gets the page number.
        /// </summary>
        public int Page { get; private set; }

        /// <summary>
        /// Gets the total amount of email addresses added by the user.
        /// </summary>
        public int Size { get; private set; }

        /// <summary>
        /// Gets the URL for the previous page if not the first page, otherwiser <code>null</code>.
        /// </summary>
        public string Previous { get; private set; }

        /// <summary>
        /// Gets whether there is a previous page.
        /// </summary>
        public bool HasPrevious {
            get { return !String.IsNullOrWhiteSpace(Previous); }
        }

        /// <summary>
        /// Gets the URL for the next page if there are more pages.
        /// </summary>
        public string Next { get; private set; }

        /// <summary>
        /// Gets whether there is a next page, otherwise <code>null</code>.
        /// </summary>
        public bool HasNext {
            get { return !String.IsNullOrWhiteSpace(Next); }
        }

        #endregion

        #region Constructors

        private BitBucketUserEmailsCollection(JObject obj) : base(obj) {
            PageLength = obj.GetInt32("pagelen");
            Values = obj.GetArray("values", BitBucketUserEmail.Parse);
            Page = obj.GetInt32("page");
            Size = obj.GetInt32("size");
            Previous = obj.GetString("previous");
            Next = obj.GetString("next");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="BitBucketUserEmailsCollection"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="BitBucketUserEmailsCollection"/>.</returns>
        public static BitBucketUserEmailsCollection Parse(JObject obj) {
            return obj == null ? null : new BitBucketUserEmailsCollection(obj);
        }

        #endregion

    }

}