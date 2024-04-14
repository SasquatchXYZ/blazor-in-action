using Ardalis.ApiEndpoints;
using BlazingTrails.Api.Persistence;
using BlazingTrails.Shared.Features.ManageTrails.EditTrail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazingTrails.Api.Features.ManageTrails.EditTrail;

public class GetTrailEndpoint : EndpointBaseAsync.WithRequest<int>.WithActionResult<GetTrailRequest.Response>
{
    private readonly BlazingTrailsContext _database;

    public GetTrailEndpoint(BlazingTrailsContext database)
    {
        _database = database;
    }

    [HttpGet(GetTrailRequest.RouteTemplate)]
    public override async Task<ActionResult<GetTrailRequest.Response>> HandleAsync(int trailId,
        CancellationToken cancellationToken = default)
    {
        var trail = await _database.Trails
            .Include(x => x.Route)
            .SingleOrDefaultAsync(trail => trail.Id == trailId, cancellationToken: cancellationToken);

        if (trail is null)
        {
            return BadRequest("Trail could not be found.");
        }

        var response = new GetTrailRequest.Response(
            new GetTrailRequest.Trail(trail.Id,
                trail.Name,
                trail.Location,
                trail.Image,
                trail.TimeInMinutes,
                trail.Length,
                trail.Description,
                trail.Route.Select(routeInstruction => new GetTrailRequest.RouteInstruction(routeInstruction.Id,
                    routeInstruction.Stage, routeInstruction.Description))));

        return Ok(response);
    }
}
