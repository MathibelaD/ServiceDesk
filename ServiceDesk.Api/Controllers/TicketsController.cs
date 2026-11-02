using Microsoft.AspNetCore.Mvc;

using ServiceDesk.Api.Models;

namespace ServiceDesk.Api.Controllers;



[ApiController]
[Route("api/tickets")]
public class TicketsController : ControllerBase
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

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(tickets);
    }

    [HttpGet("{id}")]

    public IActionResult getTicketById(int id)
    {
        var ticket = tickets.Find(x => x.Id == id);

        if (ticket != null)
        {
            return Ok(ticket);
        }

        return NotFound();
    }


    [HttpPost]
    public IActionResult CreateTicket([FromBody] CreateTicketRequest request)
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
        return CreatedAtAction(
            nameof(getTicketById),
            new
            {
                id = newTicket.Id
            },
            newTicket
        );
    }
}