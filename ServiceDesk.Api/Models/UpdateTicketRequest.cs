using System.ComponentModel.DataAnnotations;

namespace ServiceDesk.Api.Models;
public class UpdateTicketRequest
{
     [Required]
    [MaxLength(100)]
    public string Title { get; set; } = string.Empty;
            [Required]
    [MaxLength(500)]
        public string Description { get; set; } = string.Empty;
}