namespace ivs.Domain.Constants;

public class ResponseObject
{
    public ResponseContents result { get; set; }
}


public class ResponseContents
{
    public int? code { get; set; } = 0;
    public bool? success { get; set; } = false;
    public string? message { get; set; }
    public string? token { get; set; }
    public string? refreshToken { get; set; }
    public dynamic? data { get; set; }
}