using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace KarTime.Sessions;

public class EndSessionInputDto
{
    public IFormFile? PhotoFinish { get; set; }
}