using Ardalis.ApiEndpoints;
using BlazingTrails.Api.Persistence;
using BlazingTrails.Shared.Features.ManageTrails.EditTrail;
using Microsoft.AspNetCore.Authorization;
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

    [Authorize]
    [HttpGet(GetTrailRequest.RouteTemplate)]
    public override async Task<ActionResult<GetTrailRequest.Response>> HandleAsync(int trailId,
        CancellationToken cancellationToken = default)
    {
        var trail = await _database.Trails
            .Include(x => x.Waypoints)
            .SingleOrDefaultAsync(trail => trail.Id == trailId, cancellationToken: cancellationToken);

        if (trail is null)
            return BadRequest("Trail could not be found.");

        if (!trail.Owner.Equals(HttpContext.User.Identity!.Name, StringComparison.OrdinalIgnoreCase) && !HttpContext.User.IsInRole("Administrator"))
            return Unauthorized();


        var response = new GetTrailRequest.Response(
            new GetTrailRequest.Trail(trail.Id,
                trail.Name,
                trail.Location,
                trail.Image,
                trail.TimeInMinutes,
                trail.Length,
                trail.Description,
                trail.Waypoints.Select(waypoint =>
                    new GetTrailRequest.Waypoint(waypoint.Latitude, waypoint.Longitude))));

        return Ok(response);
    }
}
