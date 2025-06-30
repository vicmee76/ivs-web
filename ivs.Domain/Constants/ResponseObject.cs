namespace ivs.Domain.Constants;

public class ResponseObject
{
    public ResponseContents result { get; set; }
}


public class ResponseContents
{
    public int? code { get; set; } = 0;
    public bool? success { get; set; } = false;
    public string? message { get; set; } = string.Empty;
    public string? token { get; set; } = string.Empty;
    public string? refreshToken { get; set; } = string.Empty;
    public dynamic? data { get; set; } = null;
}