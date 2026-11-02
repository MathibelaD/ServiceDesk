using Microsoft.AspNetCore.Mvc;

using ServiceDesk.Api.Models;

namespace ServiceDesk.Api.Controllers;



[ApiController]
[Route("api/tickets")]
public class TicketsController : ControllerBase
{

    [HttpGet]
    public IActionResult Get()
    {

    var tickets = new List<Ticket>{

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
        new Ticket
         {
            Id = 3,
            Title  = "lost my access key",
            Description = "i need a new access key to access the building i lost mine",
            Status = "Open",
            CreatedAt = DateTime.UtcNow
        },
        
    };

        return Ok(tickets);
    }
}