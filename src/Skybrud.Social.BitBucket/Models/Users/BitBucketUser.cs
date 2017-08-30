using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;

namespace Skybrud.Social.BitBucket.Models.Users {

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
        /// Gets the website of the user.
        /// </summary>
        public string Website { get; private set; }

        /// <summary>
        /// Gets the display name of the user.
        /// </summary>
        public string DisplayName { get; private set; }

        public BitBucketUserLinkCollection Links { get; private set; }

        /// <summary>
        /// Gets the timestamp for when the user was created.
        /// </summary>
        public EssentialsDateTime CreatedOn { get; private set; }

        /// <summary>
        /// Gets the location of the user.
        /// </summary>
        public string Location { get; private set; }

        /// <summary>
        /// Gets the type of the user. According to the BitBucket documentation, this will always be <code>user</code>.
        /// </summary>
        public string Type { get; private set; }

        #endregion

        #region Constructors

        private BitBucketUser(JObject obj) : base(obj) {
            Username = obj.GetString("username");
            Website = obj.GetString("website");
            DisplayName = obj.GetString("display_name");
            Links = obj.GetObject("links", BitBucketUserLinkCollection.Parse);
            CreatedOn = obj.GetString("created_on", EssentialsDateTime.Parse);
            Location = obj.GetString("location");
            Type = obj.GetString("type");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="BitBucketUser"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="BitBucketUser"/>.</returns>
        public static BitBucketUser Parse(JObject obj) {
            return obj == null ? null : new BitBucketUser(obj);
        }

        #endregion

    }

}