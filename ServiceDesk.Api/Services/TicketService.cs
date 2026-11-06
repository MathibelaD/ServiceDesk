using ServiceDesk.Api.Models;

namespace ServiceDesk.Api.Services;

public class TicketService
{

    private readonly List<Ticket> tickets = new List<Ticket>{

    new Ticket
        {
            Id = 1,
            Title  = "Laptop wont start",
            Description = "Laptop wont power on",
            Status = "Open",
            CreatedAt = DateTime.UtcNow
        },
        new Ticket
         {
            Id = 2,
            Title  = "forgot my password",
            Description = "Forgot my password and i cant reset it",
            Status = "Open",
            CreatedAt = DateTime.UtcNow
        },
        new()
         {
            Id = 3,
            Title  = "lost my access key",
            Description = "i need a new access key to access the building i lost mine",
            Status = "Open",
            CreatedAt = DateTime.UtcNow
        },

    };


    public List<Ticket> GetAllTickets()
    {
        return tickets;
    }

    public Ticket? GetTicketById(int id)
    {
        return tickets.Find(x => x.Id == id);
    }


    public Ticket CreateNewTicket(CreateTicketRequest request)
    {
        int nextId = tickets.Any() ? tickets.Max(t => t.Id) + 1 : 1;
        var newTicket = new Ticket
        {
            Id = nextId,
            Title = request.Title,
            Description = request.Description,
            Status = "Open",
            CreatedAt = DateTime.UtcNow
        };

        tickets.Add(newTicket);
        return newTicket;
    }

    public Ticket? UpdateTicket(int id, UpdateTicketRequest data)
    {
        //find the ticket you need to update
        var ticket = tickets.Find(i => i.Id == id);

        if (ticket != null)
        {
            ticket.Title = data.Title;
            ticket.Description = data.Description;

            return ticket;
        }

        return null;
    }
}