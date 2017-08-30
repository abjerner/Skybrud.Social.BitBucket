using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Skybrud.Social.BitBucket.Models {

    public class BitBucketLinkCollection : BitBucketObject, IEnumerable<BitBucketLink> {

        #region Private fields

        private readonly Dictionary<string, BitBucketLink> _links;

        #endregion

        #region Properties

        public BitBucketLink[] Links {
            get { return _links.Values.ToArray(); }
        }

        #endregion

        #region Constructors

        protected BitBucketLinkCollection(JObject obj) : base(obj) {
            _links = BitBucketLink.ParseMultiple(obj);
        }

        #endregion

        #region Member methods

        public bool HasLink(string name) {
            return _links.ContainsKey(name);
        }

        public BitBucketLink GetLink(string name) {
            BitBucketLink link;
            return _links.TryGetValue(name, out link) ? link : null;
        }

        public IEnumerator<BitBucketLink> GetEnumerator() {
            return _links.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion

        #region Static methods

        public static BitBucketLinkCollection Parse(JObject obj) {
            return obj == null ? null : new BitBucketLinkCollection(obj);
        }

        #endregion

    }

}