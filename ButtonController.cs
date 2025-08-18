using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ButtonController : ControllerBase
{
    [HttpPost]
    public IActionResult Post([FromBody] ButtonState state)
    {
        // Do something with the state (e.g., log, update DB, etc.)
        return Ok(new { message = "State received!", active = state.Active });
    }
}

public class ButtonState
{
    public bool Active { get; set; }
}