namespace Microsoft.Net;
using System.Runtime.Serialization;
using static System.String;

public record struct GlobalJson
{
    public GlobalJson() { }
    public Sdk? Sdk { get; set; } = null;
    [JProp("msbuild-sdks")]
    public IDictionary<string, Version> ProjectSdks { get; set; } = new Dictionary<string, Version>();
}

public record struct Sdk
{
    public Sdk() { }

    public Version Version { get; set; }
    public bool AllowPrerelease { get; set; } = false;
    public RollForward RollForward { get; set; } = RollForward.Disable;
}

[RegexDto(@"^(?<Major:int?>\d+)(?:\.(?<Minor:int?>\d+))?(?:\.(?<Build:int?>\d+))?(?:\.(?<Revision:int?>\d+))?(-(?<Suffix:string?>\w+))?")]
[JConverter(typeof(VersionJsonConverter))]
public partial record struct Version
{
    public override string ToString() => $"{Major}.{Minor}{(Build.HasValue ? "." : "")}{Build}{(Revision.HasValue ? "." : "")}{Revision}{(!IsNullOrEmpty(Suffix) ? "-" : "")}{Suffix}";

    public static implicit operator Version(string s) => new Version(s);
    public static implicit operator string(Version v) => v.ToString();
}

public class VersionJsonConverter : System.Text.Json.Serialization.JsonConverter<Version>
{
    public override Version Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        if (value is null)
            return default;
        return Version.Parse(value);
    }

    public override void Write(Utf8JsonWriter writer, Version value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}

public enum RollForward
{
    [EnumMember(Value = "disable")]
    Disable,
    [EnumMember(Value = "patch")]
    Patch,
    [EnumMember(Value = "feature")]
    Feature,
    [EnumMember(Value = "minor")]
    Minor,
    [EnumMember(Value = "major")]
    Major,
    [EnumMember(Value = "latestPatch")]
    LatestPatch,
    [EnumMember(Value = "latestFeature")]
    LatestFeature,
    [EnumMember(Value = "latestMajor")]
    LatestMajor
}
