namespace ivs.Domain.Constants;

public class ResponseObject
{
    public ResponseContents result { get; set; }
}


public class ResponseContents
{
    public int? code { get; set; }
    public bool? success { get; set; }
    public string? message { get; set; }
    public string? token { get; set; }
    public dynamic? data { get; set; }
}