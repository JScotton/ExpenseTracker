using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
[Authorize] // Requires authentication
public class ExpensesController : ControllerBase
{
    [HttpGet]
    public IActionResult GetExpenses()
    {
        return Ok(new { message = "You are authenticated!" });
    }
}
