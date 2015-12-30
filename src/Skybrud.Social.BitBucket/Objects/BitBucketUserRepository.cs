using System;
using Newtonsoft.Json.Linq;
using Skybrud.Social.Json.Extensions.JObject;

namespace Skybrud.Social.BitBucket.Objects {

    public class BitBucketUserRepository : BitBucketObject {

        #region Properties

        /// <summary>
        /// Gets the type of the repository as specified by the <code>scm</code> property.
        /// </summary>
        public string Type { get; private set; }

        public bool HasWiki { get; private set; }
        public bool NoForks { get; private set; }
        public string Owner { get; private set; }
        public string Logo { get; private set; }
        public long Size { get; private set; }
        public bool IsReadOnly { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public string Website { get; private set; }
        public string Description { get; private set; }
        public bool HasIssues { get; private set; }
        public bool IsFork { get; private set; }
        public string Slug { get; private set; }
        public bool IsPrivate { get; private set; }
        public string Name { get; private set; }
        public string Language { get; private set; }
        public DateTime LastUpdated { get; private set; }
        public string Creator { get; private set; }

        public string WebUrl {
            get { return "https://bitbucket.org/" + Owner + "/" + Slug; }
        }

        #endregion

        #region Constructors

        private BitBucketUserRepository(JObject obj) : base(obj) {
            Type = obj.GetString("scm");
            HasWiki = obj.GetBoolean("has_wiki");
            NoForks = obj.GetBoolean("no_forks");
            Owner = obj.GetString("owner");
            Logo = obj.GetString("logo");
            Size = obj.GetInt64("size");
            IsReadOnly = obj.GetBoolean("read_only");
            CreatedOn = obj.GetDateTime("utc_created_on");
            Website = obj.GetString("website");
            Description = obj.GetString("description");
            HasIssues = obj.GetBoolean("has_issues");
            IsFork = obj.GetBoolean("is_fork");
            Slug = obj.GetString("slug");
            IsPrivate = obj.GetBoolean("is_private");
            Name = obj.GetString("name");
            Language = obj.GetString("language");
            LastUpdated = obj.GetDateTime("utc_last_updated");
            Creator = obj.GetString("creator");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>BitBucketUserRepository</code> from the specified <code>JObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JObject</code> to parse.</param>
        public static BitBucketUserRepository Parse(JObject obj) {
            return obj == null ? null : new BitBucketUserRepository(obj);
        }

        #endregion

    }

}