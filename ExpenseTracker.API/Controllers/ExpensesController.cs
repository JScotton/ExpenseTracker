using ExpenseTracker.API.Data;
using ExpenseTracker.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
[Authorize] // Requires authentication
public class ExpensesController : ControllerBase
{
    //[HttpGet]
    //public IActionResult GetExpenses()
    //{
    //    return Ok(new { message = "You are authenticated!" });
    //}

    private readonly AppDbContext _context;

    public ExpensesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetExpenses()
    {
        var expenses = await _context.Expenses.ToListAsync();
        return Ok(expenses);
    }

    [HttpPost]
    public async Task<IActionResult> AddExpense([FromBody] Expense expense)
    {
        _context.Expenses.Add(expense);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetExpenses), new { id = expense.Id }, expense);
    }
}
