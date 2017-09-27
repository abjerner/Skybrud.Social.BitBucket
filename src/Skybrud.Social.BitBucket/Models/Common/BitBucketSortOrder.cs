namespace Skybrud.Social.BitBucket.Models.Common {
    
    /// <summary>
    /// Enum class representing the sort order of a collection.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.atlassian.com/bitbucket/api/2/reference/meta/filtering</cref>
    /// </see>
    public enum BitBucketSortOrder {

        /// <summary>
        /// Indicates that items should be sorted in descending order.
        /// </summary>
        Ascending,

        /// <summary>
        /// Indicates that items should be sorted in ascending order.
        /// </summary>
        Descending

    }

}