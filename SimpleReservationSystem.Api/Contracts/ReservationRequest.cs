namespace SimpleReservationSystem.Api.Contracts;

public class ReservationRequest
{
    public int RoomId { get; set; } //ResourceId
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public int ReservedPeople { get; set; }
}