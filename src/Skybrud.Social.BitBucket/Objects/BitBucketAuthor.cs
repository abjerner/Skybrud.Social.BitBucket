using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.BitBucket.Objects {
    
    public class BitBucketAuthor : BitBucketObject {

        #region Properties

        public string Raw { get; private set; }

        public BitBucketAuthorUser User { get; private set; }

        #endregion

        #region Constructors

        private BitBucketAuthor(JObject obj) : base(obj) {
            Raw = obj.GetString("raw");
            User = obj.GetObject("user", BitBucketAuthorUser.Parse);
        }

        #endregion

        #region Static methods

        public static BitBucketAuthor Parse(JObject obj) {
            return obj == null ? null : new BitBucketAuthor(obj);
        }

        #endregion

    }

}