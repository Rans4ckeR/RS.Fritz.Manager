using System.Collections.ObjectModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RS.Fritz.Manager.API;

internal sealed class DeviceMeshStreamConfigurationArrayJsonConverter : JsonConverter<DeviceMeshStreamConfiguration[]>
{
    public override bool CanConvert(Type typeToConvert) =>
        typeof(DeviceMeshStreamConfiguration[]).IsAssignableFrom(typeToConvert);

    public override DeviceMeshStreamConfiguration[] Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType is not JsonTokenType.StartArray)
            throw new JsonException();

        var deviceMeshStreamConfigurations = new Collection<DeviceMeshStreamConfiguration>();

        while (reader.Read())
        {
            if (reader.TokenType is JsonTokenType.EndArray)
                return [.. deviceMeshStreamConfigurations];

            if (reader.TokenType is not JsonTokenType.StartArray)
                throw new JsonException();

            _ = reader.Read();

            if (reader.TokenType is not JsonTokenType.String)
                throw new JsonException();

            string channelWidth = reader.GetString()!;

            _ = reader.Read();

            if (reader.TokenType is not JsonTokenType.Number)
                throw new JsonException();

            int supportedStreamCount = reader.GetInt32();

            _ = reader.Read();

            if (reader.TokenType is not JsonTokenType.EndArray)
                throw new JsonException();

            deviceMeshStreamConfigurations.Add(new(channelWidth, supportedStreamCount));
        }

        throw new JsonException();
    }

    public override void Write(Utf8JsonWriter writer, DeviceMeshStreamConfiguration[] value, JsonSerializerOptions options)
        => throw new NotSupportedException();
}