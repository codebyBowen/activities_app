using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers;

// primary constructor
public class ActivitiesController(AppDbContext context): BaseApiController
{
    //inject dependencies old way
    // private readonly AppDbContext context;
    // public ActivitiesController(AppDbContext context)
    // {
    //     this.context = context;
    // }
    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities()
    {
        return await context.Activities.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivityDetail(string id)
    {
        var activity = await context.Activities.FindAsync(id);

        if (activity == null) return NotFound();

        return activity;
    }

}
