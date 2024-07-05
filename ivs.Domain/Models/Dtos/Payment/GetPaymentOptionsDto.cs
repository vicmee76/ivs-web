using Newtonsoft.Json;

namespace ivs.Domain.Models.Dtos.Payment;

public class GetPaymentOptionsDto
{
    public string? _id { get; set; }
    public string? name { get; set; }
    public string? description { get; set; }
    public string? createdAt { get; set; }
    public int? maxUsers { get; set; }
    public int? capAmount { get; set; }
    public bool? isDeleted { get; set; }
    public Amount? amount { get; set; }
    public MetaAmountPercentage? metaAmountPercentage { get; set; }
}

public class Amount
{
    [JsonProperty("$numberDecimal")]
    public string numberDecimal { get; set; }
}

public class MetaAmountPercentage
{
    [JsonProperty("$numberDecimal")]
    public string numberDecimal { get; set; }
}