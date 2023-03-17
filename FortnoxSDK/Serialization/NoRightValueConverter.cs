using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fortnox.SDK.Serialization
{
    /// <summary>
    /// Fortnox use a magic string value "API_NORIGHT" for when customer is missing a license to features.
    /// All those properties are nullable and we can simply parse those values as null.
    /// </summary>
    public class NoRightValueConverter : JsonConverter
    {
        readonly JsonSerializer defaultSerializer = new JsonSerializer();

        public override bool CanConvert(Type objectType)
            => Nullable.GetUnderlyingType(objectType) != null;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            => reader.TokenType == JsonToken.String && (string)reader.Value == "API_NORIGHT" ?
                null : defaultSerializer.Deserialize(reader, objectType);

        public override bool CanWrite 
            => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            => throw new NotImplementedException();
    }
}
