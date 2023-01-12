namespace Microsoft.Net;
using System.Runtime.Serialization;

public record struct GlobalJson
{
    public GlobalJson() { }
    public IEnumerable<Sdk> Sdks { get; set; } = Array.Empty<Sdk>();
    public IDictionary<string, Version> ProjectSdks { get; set; } = new Dictionary<string, Version>();
}

public record struct Sdk
{
    public Sdk() { }

    public Version Version { get; set; }
    public bool AllowPrerelease { get; set; } = false;
    public RollForward RollForward { get; set; } = RollForward.Disable;
}

[RegexDto(@"^(?<Major>\d+)(?:\.(?<Minor>\d+))?(?:\.(?<Build>\d+))?(?:\.(?<Revision>\d+))?(-(?<Suffix>\w+))?")]
public partial record struct Version { }

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
