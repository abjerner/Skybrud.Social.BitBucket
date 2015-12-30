using Newtonsoft.Json.Linq;
using Skybrud.Social.BitBucket.Objects;
using Skybrud.Social.BitBucket.Objects.Changesets;
using Skybrud.Social.Http;

namespace Skybrud.Social.BitBucket.Responses {

    public class BitBucketChangesetsResponse : BitBucketResponse<BitBucketChangesetsCollection> {

        #region Properties

        public BitBucketChangeset[] Changesets { get; private set; }

        #endregion

        #region Constructors

        private BitBucketChangesetsResponse(SocialHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, BitBucketChangesetsCollection.Parse);
        }

        #endregion

        #region Methods

        #region Static methods

        public static BitBucketChangesetsResponse ParseResponse(SocialHttpResponse response) {
            return response == null ? null : new BitBucketChangesetsResponse(response);
        }

        #endregion

        #endregion

    }

}
