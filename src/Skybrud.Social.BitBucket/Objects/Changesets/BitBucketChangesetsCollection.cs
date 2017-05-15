using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.BitBucket.Objects.Changesets {
    
    public class BitBucketChangesetsCollection : BitBucketObject {
        
        #region Properties

        public int Count { get; private set; }

        public string Start { get; private set; }

        public int Limit { get; private set; }

        #endregion

        #region Constructors

        private BitBucketChangesetsCollection(JObject obj) : base(obj) {
            Count = obj.GetInt32("count");
            Start = obj.GetString("start");
            Limit = obj.GetInt32("limit");
        }

        #endregion

        #region Static methods

        public static BitBucketChangesetsCollection Parse(JObject obj) {
            return obj == null ? null : new BitBucketChangesetsCollection(obj);
        }

        #endregion

    }

}