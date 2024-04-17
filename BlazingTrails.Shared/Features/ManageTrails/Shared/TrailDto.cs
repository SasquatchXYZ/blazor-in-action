namespace BlazingTrails.Shared.Features.ManageTrails.Shared;

public class TrailDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public int TimeInMinutes { get; set; }
    public int Length { get; set; }
    public List<WaypointDto> Waypoints { get; set; } = [];
    public string? Image { get; set; }
    public ImageAction ImageAction { get; set; }

    public record WaypointDto(decimal Latitude, decimal Longitude);
}
