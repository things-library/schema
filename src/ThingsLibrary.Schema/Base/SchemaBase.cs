﻿
namespace ThingsLibrary.Schema.Base
{
    /// <summary>
    /// Base Schema Attributes
    /// </summary>
    public class SchemaBase
    {
        #region --- Static ---

        // Should be sent with mime type: "application/schema+json"

        /// <summary>
        /// Version string
        /// </summary>
        public const string CurrentVersion = "1.0";

        /// <summary>
        /// Current Version
        /// </summary>
        public static Version SchemaVersion { get; } = new Version(CurrentVersion);

        /// <summary>
        /// Json Schema Definition
        /// </summary>
        public static string SchemaBaseUrl { get; } = $"https://schema.thingslibrary.io/{CurrentVersion}";

        /// <summary>
        /// Pattern to use for all non-root library keys
        /// </summary>
        public const string KeyPattern = "^[a-z0-9_-]{1,50}$";

        /// <summary>
        /// Key pattern description
        /// </summary>
        public const string KeyPatternDescription = "Invalid Characters.  Please only use lowercase letters, numeric, underscores and hyphens.";
                
 
        /// <summary>
        /// Standard json serialization settings for our libraray objects
        /// </summary>        
        public static JsonSerializerOptions JsonSerializerOptions { get; } = new JsonSerializerOptions()
        {
            AllowTrailingCommas = true,
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            PropertyNameCaseInsensitive = true,
            TypeInfoResolver = new DefaultJsonTypeInfoResolver
            {
                Modifiers = { JsonIgnoreEmptyCollection.IgnoreEmptyCollections }
            }
        };

        #endregion


        /// <summary>
        /// Generic metadata which is a simple key-value dictionary
        /// </summary>
        [JsonPropertyName("metadata"), JsonIgnoreEmptyCollection]
        public Dictionary<string, string> Metadata { get; set; } = new();


        /// <summary>
        /// Revision Number (1 = first)
        /// </summary>
        [JsonPropertyName("version"), DefaultValue(1), Range(1, int.MaxValue)]
        public int Version { get; set; } = 1;
    }
}
