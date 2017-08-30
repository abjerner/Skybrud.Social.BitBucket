﻿using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.BitBucket.Models {

    public class BitBucketRepository : BitBucketObject {

        #region Properties

        public string Scm { get; private set; }

        public bool HasWiki { get; private set; }

        public string Description { get; private set; }

        public string Name { get; private set; }

        public string Language { get; private set; }

        public DateTime CreatedOn { get; private set; }

        public string FullName { get; private set; }

        public bool HasIssues { get; private set; }

        public DateTime UpdatedOn { get; private set; }

        public long Size { get; private set; }

        public bool IsPrivate { get; private set; }

        public string Uuid { get; private set; }

        #endregion

        #region Constructors

        private BitBucketRepository(JObject obj) : base(obj) {
            Scm = obj.GetString("scm");
            HasWiki = obj.GetBoolean("has_wiki");
            Description = obj.GetString("description");
            Name = obj.GetString("name");
            Language = obj.GetString("language");
            CreatedOn = obj.GetDateTime("created_on");
            FullName = obj.GetString("full_name");
            HasIssues = obj.GetBoolean("has_issues");
            UpdatedOn = obj.GetDateTime("updated_on");
            Size = obj.GetInt64("size");
            IsPrivate = obj.GetBoolean("is_private");
            Uuid = obj.GetString("uuid");
        }

        #endregion

        #region Static methods

        public static BitBucketRepository Parse(JObject obj) {
            return obj == null ? null : new BitBucketRepository(obj);
        }

        #endregion

    }

}