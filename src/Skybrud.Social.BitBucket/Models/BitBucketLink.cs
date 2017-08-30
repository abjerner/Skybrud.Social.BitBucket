using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.BitBucket.Models {
    
    public class BitBucketLink : BitBucketObject {

        #region Properties

        public string Name { get; private set; }

        public string Href { get; private set; }

        #endregion

        #region Constructors

        private BitBucketLink(JObject obj) : base(obj) {
            Name = ((JProperty) obj.Parent).Name;
            Href = obj.GetString("href");
        }

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

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="BitBucketLink"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="BitBucketLink"/>.</returns>
        public static BitBucketLink Parse(JObject obj) {
            return obj == null ? null : new BitBucketLink(obj);
        }

        #endregion

    }

}