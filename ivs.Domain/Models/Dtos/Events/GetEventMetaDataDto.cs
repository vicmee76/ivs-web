namespace ivs.Domain.Models.Dtos.Events;

public class GetEventMetaDataDto
{
    public string? _id { get; set; }
    public string? eventName { get; set; }
    public string? eventDescription { get; set; }
    public string? eventAddress { get; set; }
    public string? eventState { get; set; }
    public string? adressPin { get; set; }
    public string? status { get; set; }
    public string? eventOption { get; set; }
    public string? eventTypeId { get; set; }
    public string? paymentOption { get; set; }
    public string? webLink { get; set; }
    public string? facebookLink { get; set; }
    public string? twitterLink { get; set; }
    public string? instagramLink { get; set; }
    public string? createdAt { get; set; }
    public string? eventLongLink { get; set; }
    public string? eventShortLink { get; set; }
    public string? qrCodeLink { get; set; }
    public string? updatedAt { get; set; }
    public string? eventImageName { get; set; }
    public string? eventImagePath { get; set; }
}