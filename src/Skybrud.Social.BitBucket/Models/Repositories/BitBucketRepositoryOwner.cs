using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.BitBucket.Models.Repositories {

    /// <summary>
    /// Class representing an owner of a BitBucket repository.
    /// </summary>
    public class BitBucketRepositoryOwner : BitBucketObject {

        #region Properties

        /// <summary>
        /// Gets the username of the owner.
        /// </summary>
        public string Username { get; }

        /// <summary>
        /// Gets the display name of the owner.
        /// </summary>
        public string DisplayName { get; }

        /// <summary>
        /// Gets the type of the owner. Can be either <code>user</code> or <code>type</code>.
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Gets the UUID of the owner.
        /// </summary>
        public string Uuid { get; }

        // TODO: Add support for the "links" property

        #endregion

        #region Constructors

        private BitBucketRepositoryOwner(JObject obj) : base(obj) {
            Username = obj.GetString("username");
            DisplayName = obj.GetString("display_name");
            Type = obj.GetString("type");
            Uuid = obj.GetString("uuid");
            // TODO: Add support for the "links" property
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="BitBucketRepositoryOwner"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="BitBucketRepositoryOwner"/>.</returns>
        public static BitBucketRepositoryOwner Parse(JObject obj) {
            return obj == null ? null : new BitBucketRepositoryOwner(obj);
        }

        #endregion

    }

}