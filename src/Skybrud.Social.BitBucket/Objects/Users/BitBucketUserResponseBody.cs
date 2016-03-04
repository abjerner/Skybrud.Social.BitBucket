using Newtonsoft.Json.Linq;
using Skybrud.Social.Json.Extensions.JObject;

namespace Skybrud.Social.BitBucket.Objects.Users {

    /// <summary>
    /// Class representing the response body of a call to get information about a given user.
    /// </summary>
    public class BitBucketUserResponseBody : BitBucketObject {

        #region Properties

        /// <summary>
        /// Gets information about the current user.
        /// </summary>
        public BitBucketUser User { get; private set; }

        /// <summary>
        /// Gets an array of repositories owned by the user.
        /// </summary>
        public BitBucketUserRepository[] Repositories { get; private set; }

        #endregion

        #region Constructor

        private BitBucketUserResponseBody(JObject obj) : base(obj) {
            User = obj.GetObject("user", BitBucketUser.Parse);
            Repositories = obj.GetArray("repositories", BitBucketUserRepository.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="BitBucketUserResponseBody"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="BitBucketUserResponseBody"/>.</returns>
        public static BitBucketUserResponseBody Parse(JObject obj) {
            return obj == null ? null : new BitBucketUserResponseBody(obj);
        }

        #endregion

    }

}