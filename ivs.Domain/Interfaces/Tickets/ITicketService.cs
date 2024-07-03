using ivs.Domain.Constants;
using ivs.Domain.Models.ViewModels.Tickets;

namespace ivs.Domain.Interfaces.Tickets;

public interface ITicketService
{
    public Task<ResponseObject> CreateTicket(CreateTicketVM model);
    public Task<ResponseObject> DeleteTicketById(string ticketId);
    public Task<ResponseObject> GetTicketByEventId(string eventId);
    public Task<ResponseObject> UpdateTicket(string ticketIdd, CreateTicketVM model);
}