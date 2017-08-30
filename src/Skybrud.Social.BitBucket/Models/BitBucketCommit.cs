using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.BitBucket.Models {

    public class BitBucketCommit : BitBucketObject {

        #region Properties

        /// <summary>
        /// The SHA hash identifying the commit.
        /// </summary>
        public string Hash { get; private set; }

        /// <summary>
        /// The date of the commit.
        /// </summary>
        public DateTime Date { get; private set; }

        /// <summary>
        /// The commit message specified by the author.
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Brief information of the repository.
        /// </summary>
        public BitBucketRepositoryInfo Repository { get; private set; }
        
        /// <summary>
        /// Brief information about the author of the commit.
        /// </summary>
        public BitBucketAuthor Author { get; private set; }

        /// <summary>
        /// A collection of links related to the commit.
        /// </summary>
        public BitBucketLinkCollection Links { get; private set; }

        #endregion

        #region Constructors

        private BitBucketCommit(JObject obj) : base(obj) {
            Hash = obj.GetString("hash");
            Date = obj.GetDateTime("date");
            Message = obj.GetString("message");
            Repository = obj.GetObject("repository", BitBucketRepositoryInfo.Parse);
            Author = obj.GetObject("author", BitBucketAuthor.Parse);
            Links = obj.GetObject("links", BitBucketLinkCollection.Parse);
        } 

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>JObject</code> and returns an instance of <code>BitBucketCommit</code> if
        /// successful.
        /// </summary>
        /// <param name="obj">The <code>JObject</code> representing the user.</param>
        public static BitBucketCommit Parse(JObject obj) {
            return obj == null ? null : new BitBucketCommit(obj);
        }

        #endregion

    }

}