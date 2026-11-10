using Microsoft.AspNetCore.Mvc;

using ServiceDesk.Api.Models;
using ServiceDesk.Api.Services;

namespace ServiceDesk.Api.Controllers;



[ApiController]
[Route("api/tickets")]
public class TicketsController : ControllerBase
{

    private readonly TicketService ticketService;

    public TicketsController(TicketService ticketService)
    {
        this.ticketService = ticketService;
    }
    [HttpGet]
    public IActionResult Get()
    {
        var tickets = ticketService.GetAllTickets();
        return Ok(tickets);
    }

    [HttpGet("{id}")]

    public IActionResult getTicketById(int id)
    {
        var ticket = ticketService.GetTicketById(id);

        if (ticket != null)
        {
            return Ok(ticket);
        }

        return NotFound();
    }


    [HttpPost]
    public IActionResult CreateTicket([FromBody] CreateTicketRequest request)
    {
        var newTicket = ticketService.CreateNewTicket(request);
        return CreatedAtAction(
            nameof(ticketService.GetTicketById),
            new
            {
                id = newTicket.Id
            },
            newTicket
        );
    }

    [HttpPut("{id}")]
    public IActionResult UpdateTicket(int id, UpdateTicketRequest request)
    {

        var updatedTicket = ticketService.UpdateTicket(id, request);

        if (updatedTicket == null)
        {
            return NotFound();
        }

        return Ok(updatedTicket);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTicket(int id){

        var deleted = ticketService.DeleteTicket(id);
        if (deleted)
        {
            return NoContent();
        }
        else
        {
            return NotFound();
        }
    }
}