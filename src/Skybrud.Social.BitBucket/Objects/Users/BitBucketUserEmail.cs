using Newtonsoft.Json.Linq;
using Skybrud.Social.Json.Extensions.JObject;

namespace Skybrud.Social.BitBucket.Objects.Users {

    /// <summary>
    /// Class describing an email as added by a BitBucket user.
    /// </summary>
    public class BitBucketUserEmail : BitBucketObject {

        #region Properties

        /// <summary>
        /// Gets whether the email address has been selected as the primary of the user.
        /// </summary>
        public bool IsPrimary { get; private set; }

        /// <summary>
        /// Gets whether the email address has been confirmed by the user.
        /// </summary>
        public bool IsConfirmed { get; private set; }

        /// <summary>
        /// Gets the type of the email address. The BitBucket documentation doesn't explain the value of this property,
        /// but it will probably always just <code>email</code>.
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// Gets the email address.
        /// </summary>
        public string Email { get; private set; }

        #endregion

        #region Constructors

        private BitBucketUserEmail(JObject obj) : base(obj) {
            IsPrimary = obj.GetBoolean("is_primary");
            IsConfirmed = obj.GetBoolean("is_confirmed");
            Type = obj.GetString("type");
            Email = obj.GetString("email");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="BitBucketUserEmail"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="BitBucketUserEmail"/>.</returns>
        public static BitBucketUserEmail Parse(JObject obj) {
            return obj == null ? null : new BitBucketUserEmail(obj);
        }

        #endregion

    }

}