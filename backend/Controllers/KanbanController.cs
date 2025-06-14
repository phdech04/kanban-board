using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

[ApiController]
[Route("api/[controller]")]
public class KanbanController : ControllerBase
{
    private readonly KanbanService _service;
    private readonly IHubContext<KanbanHub> _hub;

    public KanbanController(KanbanService service, IHubContext<KanbanHub> hub)
    {
        _service = service;
        _hub = hub;
    }

    [HttpGet]
    public IActionResult Get() => Ok(_service.Columns);

    [HttpPost("move")]
    public async Task<IActionResult> Move([FromBody] MoveRequest req)
    {
        _service.MoveCard(req.CardId, req.FromCol, req.ToCol);
        await _hub.Clients.All.SendAsync("BoardUpdated", _service.Columns);
        return Ok();
    }
}

public class MoveRequest
{
    public int CardId { get; set; }
    public int FromCol { get; set; }
    public int ToCol { get; set; }
}