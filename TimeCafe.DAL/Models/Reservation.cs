namespace TimeCafe.DAL.Models;

public partial class Reservation
{
    public string Id { get; set; } = null!;

    public string? TableGameId { get; set; }

    public DateTime TimeStart { get; set; }

    public DateTime TimeEnd { get; set; }
}
