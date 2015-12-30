using System.IO;
using Newtonsoft.Json.Linq;
using Skybrud.Social.Json;
using Skybrud.Social.Json.Extensions.JObject;

namespace Skybrud.Social.BitBucket.Objects {

    /// <summary>
    /// Class describing a BitBucket user.
    /// </summary>
    public class BitBucketUser : BitBucketObject {

        #region Properties

        /// <summary>
        /// Gets the username of the user.
        /// </summary>
        public string Username { get; private set; }

        /// <summary>
        /// Gets the first name of the user.
        /// </summary>
        public string FirstName { get; private set; }

        /// <summary>
        /// Gets the last name of the user.
        /// </summary>
        public string LastName { get; private set; }

        /// <summary>
        /// Gets the display name of the user.
        /// </summary>
        public string DisplayName { get; private set; }

        /// <summary>
        /// Gets whether the user is team account.
        /// </summary>
        public bool IsTeam { get; private set; }

        /// <summary>
        /// Gets the secure Gravatar URL for the user's avatar.
        /// </summary>
        public string Avatar { get; private set; }

        /// <summary>
        /// Gets the relative API resource URL for the user.
        /// </summary>
        public string ResourceUri { get; private set; }

        #endregion

        #region Constructors

        private BitBucketUser(JObject obj) : base(obj) {
            Username = obj.GetString("username");
            FirstName = obj.GetString("first_name");
            LastName = obj.GetString("last_name");
            DisplayName = obj.GetString("display_name");
            IsTeam = obj.GetBoolean("is_team");
            Avatar = obj.GetString("avatar");
            ResourceUri = obj.GetString("resource_uri");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets a user from the specified <code>JObject</code>.
        /// </summary>
        /// <param name="obj">The object to parse.</param>
        public static BitBucketUser Parse(JObject obj) {
            return obj == null ? null : new BitBucketUser(obj);
        }

        #endregion

    }

}