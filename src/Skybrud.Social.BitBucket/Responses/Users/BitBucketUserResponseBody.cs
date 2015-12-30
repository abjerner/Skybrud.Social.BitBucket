﻿using Newtonsoft.Json.Linq;
using Skybrud.Social.BitBucket.Objects;
using Skybrud.Social.Json;
using Skybrud.Social.Json.Extensions.JObject;

namespace Skybrud.Social.BitBucket.Responses.Users {

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

        private BitBucketUserResponseBody(JObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static BitBucketUserResponseBody Parse(JObject obj) {
            if (obj == null) return null;
            return new BitBucketUserResponseBody(obj) {
                User = obj.GetObject("user", BitBucketUser.Parse),
                Repositories = obj.GetArray("repositories", BitBucketUserRepository.Parse)
            };
        }

        #endregion

    }

}