using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.BitBucket.Models.Repositories {

    /// <summary>
    /// Class representing a BitBucket repository.
    /// </summary>
    public class BitBucketRepository : BitBucketObject {

        #region Properties

        /// <summary>
        /// Gets the type of the source control used by the repository.
        /// </summary>
        public string Scm { get; }

        /// <summary>
        /// Gets the website URL (project site or similar) associated with the repository.
        /// </summary>
        public string Website { get; }

        /// <summary>
        /// Gets whether a website URL has been specified for the repository.
        /// </summary>
        public bool HasWebsite => !String.IsNullOrWhiteSpace(Website);

        /// <summary>
        /// Gets whether a wiki has been enabled for the repository.
        /// </summary>
        public bool HasWiki { get; }

        /// <summary>
        /// Gets the name of the repository.
        /// </summary>
        public string Name { get; }

        // TODO: Add support for the "links" property

        // TODO: Add support for the "fork_policy" property

        /// <summary>
        /// Gets the UUID of the repository.
        /// </summary>
        public string Uuid { get; }

        // TODO: Add support for the "project" property

        /// <summary>
        /// Gets the primary language of the repository - eg. <code>c#</code>.
        /// </summary>
        public string Language { get; }

        /// <summary>
        /// Gets a timestamp for when the repository was created.
        /// </summary>
        public DateTime CreatedOn { get; }

        // TODO: Add support for the "mainbranch" property

        /// <summary>
        /// Gets the full name of the repository, which is a combination of the username of the parent user/organization and <see cref="Slug"/>.
        /// </summary>
        public string FullName { get; }

        /// <summary>
        /// Gets whether issues have been enabled for the repository.
        /// </summary>
        public bool HasIssues { get; }

        /// <summary>
        /// Gets a reference to the user/organization owning the repository.
        /// </summary>
        public BitBucketRepositoryOwner Owner { get; }

        /// <summary>
        /// Gets a timestamp for when the repository was last updated.
        /// </summary>
        public DateTime UpdatedOn { get; }

        /// <summary>
        /// Gets the size of the repository.
        /// </summary>
        public long Size { get; }

        /// <summary>
        /// Gets the type of the repository. Most likely always <code>repository</code>.
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Gets the slug of the repository.
        /// </summary>
        public string Slug { get; }

        /// <summary>
        /// Gets whether the repository is private.
        /// </summary>
        public bool IsPrivate { get; }

        /// <summary>
        /// Gets the description of the repository.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Gets whether a description has been specified for the repository.
        /// </summary>
        public bool HasDescription => !String.IsNullOrWhiteSpace(Description);

        #endregion

        #region Constructors

        private BitBucketRepository(JObject obj) : base(obj) {
            Scm = obj.GetString("scm");
            Website = obj.GetString("website");
            HasWiki = obj.GetBoolean("has_wiki");
            Name = obj.GetString("name");
            // TODO: Add support for the "links" property
            // TODO: Add support for the "fork_policy" property
            Uuid = obj.GetString("uuid");
            // TODO: Add support for the "project" property
            Language = obj.GetString("language");
            CreatedOn = obj.GetDateTime("created_on");
            // TODO: Add support for the "mainbranch" property
            FullName = obj.GetString("full_name");
            HasIssues = obj.GetBoolean("has_issues");
            Owner = obj.GetObject("owner", BitBucketRepositoryOwner.Parse);
            UpdatedOn = obj.GetDateTime("updated_on");
            Size = obj.GetInt64("size");
            Type = obj.GetString("type");
            Slug = obj.GetString("slug");
            IsPrivate = obj.GetBoolean("is_private");
            Description = obj.GetString("description");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="BitBucketRepository"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="BitBucketRepository"/>.</returns>
        public static BitBucketRepository Parse(JObject obj) {
            return obj == null ? null : new BitBucketRepository(obj);
        }

        #endregion

    }

}