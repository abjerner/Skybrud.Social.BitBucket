using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Skybrud.Social.Json.Extensions.JObject;

namespace Skybrud.Social.BitBucket.Objects {
    
    public class BitBucketLink : BitBucketObject {

        #region Properties

        public string Name { get; private set; }

        public string Href { get; private set; }

        #endregion

        #region Constructors

        private BitBucketLink(JObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static Dictionary<string, BitBucketLink> ParseMultiple(JObject obj) {

            // Check if NULL
            if (obj == null) return null;

            // Initialize the dictionary
            Dictionary<string, BitBucketLink> links = new Dictionary<string, BitBucketLink>();

            // Iterate through the specified object
            foreach (JProperty property in obj.Properties()) {
                JObject value = obj.GetObject(property.Name);
                if (value == null) continue;
                links.Add(property.Name, new BitBucketLink(obj) {
                    Name = property.Name,
                    Href = value.GetString("href")
                });
            }
            
            // Return the dictionary
            return links;

        }

        #endregion

    }

}