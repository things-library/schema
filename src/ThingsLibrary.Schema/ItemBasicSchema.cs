﻿using ThingsLibrary.Schema.Base;

namespace ThingsLibrary.Schema
{
    /// <summary>
    /// Item Schema - Flexible
    /// </summary>
    [DebuggerDisplay("{Name} (Key: {Key}, Type: {Type})")]
    public class ItemBasicSchema : Base.SchemaBase
    {
        /// <summary>
        /// Json Schema Definition
        /// </summary>
        [JsonPropertyName("$schema"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Uri? SchemaUrl { get; set; } = new Uri($"{SchemaBase.SchemaBaseUrl}/item.json");

        /// <summary>
        /// Resource Key
        /// </summary>  
        [JsonPropertyName("key")]
        [Display(Name = "Key"), StringLength(50, MinimumLength = 1)]
        [RegularExpression(Base.SchemaBase.KeyPattern, ErrorMessage = Base.SchemaBase.KeyPatternDescription)]
        public string? Key { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [JsonPropertyName("name")]
        [Display(Name = "Name"), StringLength(50, MinimumLength = 1), Required]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Date (If item is an 'event')
        /// </summary>
        /// <remarks>Designed for maintaining chronological listing</remarks>
        [JsonPropertyName("date")]
        public DateTime? Date { get; set; }
                
        /// <summary>
        /// Item Type 
        /// </summary>
        [JsonPropertyName("type")]
        [Display(Name = "Item Type"), StringLength(50, MinimumLength = 1), Required]        
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// Attributes
        /// </summary> 
        /// <remarks>Value must be a string or array of strings</remarks>
        [JsonPropertyName("attributes"), JsonConverter(typeof(ItemBasicAttributeConverter)), JsonIgnoreEmptyCollection]
        public Dictionary<string, ItemBasicAttributeSchema> Attributes { get; set; } = new();

        /// <summary>
        /// Attachments
        /// </summary>
        [ValidateObject<ItemBasicSchema>]
        [JsonPropertyName("attachments"), JsonIgnoreEmptyCollection]
        public List<ItemBasicSchema> Attachments { get; set; } = new();

        /// <summary>
        /// Version (Revision) Number
        /// </summary>
        [JsonPropertyName("version"), DefaultValue(1)]
        public int Version { get; set; } = 1;
        
        /// <summary>
        /// Constructor
        /// </summary>
        public ItemBasicSchema()
        {
            //nothing
        }
    }
}