namespace JustinWritesCode.Functions.Arrays;

public class Sort
{
    public ILogger Logger { get; set; } = null!;

    public Sort(ILogger<Sort> logger) => Logger = logger;

    [FunctionAttribute(nameof(Sort))]
    [Op(operationId: nameof(Sort), tags: new[] { Tags.Arrays, Tags.Mutations })]
    [RequestBody(contentType: ApplicationMediaTypeNames.Json, bodyType: typeof(AnyOf<string[], ArrayPayload<string>>), Required = true, Description = "The array to be sorted")]
    [ResponseBody(statusCode: OK, contentType: "application/json", bodyType: typeof(ArrayPayload), Description = "The sorted array")]
    public async Task<IActionResult> SortAsync(
        [Http(AuthorizationLevel.Anonymous, "post", Route = Routes.Sort)] HttpRequest req)
    {
        Logger.LogInformation("C# HTTP trigger function processed a request.");

        var theArray = (await req.ReadArrayPayloadAsync<string>()).ToList();
        theArray.Sort();

        return new OkObjectResult(new ArrayPayload<string>(theArray.ToArray()));
    }
}
