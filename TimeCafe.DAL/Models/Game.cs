namespace TimeCafe.DAL.Models;

public partial class Game
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string? Description { get; set; }

    public string? Image { get; set; }
}
