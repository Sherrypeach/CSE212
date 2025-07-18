using System.Collections.Generic;
using System.Text.Json.Serialization;

// This class represents the root of the JSON object from the USGS API
public class FeatureCollection
{
    // The list of earthquake records is under the "features" property in the JSON
    [JsonPropertyName("features")]
    public List<Feature> Features { get; set; }
}

// Each earthquake entry is called a "feature" in the USGS data
public class Feature
{
    // Each feature has a "properties" object that holds the useful data
    [JsonPropertyName("properties")]
    public Properties Properties { get; set; }
}

// The properties we care about: location (place) and magnitude (mag)
public class Properties
{
    // The "place" where the earthquake happened
    [JsonPropertyName("place")]
    public string Place { get; set; }

    // The "mag" is the magnitude of the earthquake (can be null sometimes)
    [JsonPropertyName("mag")]
    public double? Magnitude { get; set; }
}
