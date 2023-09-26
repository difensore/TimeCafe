namespace TimeCafe.DAL.Models;

public partial class TableGameReservation
{
    public string Id { get; set; } = null!;

    public string TableId { get; set; } = null!;

    public string GameId { get; set; } = null!;
}
