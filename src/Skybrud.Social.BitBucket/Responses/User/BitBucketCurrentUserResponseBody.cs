using Newtonsoft.Json.Linq;
using Skybrud.Social.BitBucket.Objects;
using Skybrud.Social.BitBucket.Objects.Users;
using Skybrud.Social.Json.Extensions.JObject;

namespace Skybrud.Social.BitBucket.Responses.User {

    public class BitBucketCurrentUserResponseBody : BitBucketObject {

        #region Properties

        /// <summary>
        /// Gets information about the current user.
        /// </summary>
        public BitBucketUser User { get; private set; }

        /// <summary>
        /// Gets an array of repositories owned by the current user.
        /// </summary>
        public BitBucketUserRepository[] Repositories { get; private set; }

        #endregion

        #region Constructors

        private BitBucketCurrentUserResponseBody(JObject obj) : base(obj) {
            User = obj.GetObject("user", BitBucketUser.Parse);
            Repositories = obj.GetArray("repositories", BitBucketUserRepository.Parse);
        }

        #endregion

        #region Static methods

        public static BitBucketCurrentUserResponseBody Parse(JObject obj) {
            return obj == null ? null : new BitBucketCurrentUserResponseBody(obj);
        }

        #endregion

    }

}