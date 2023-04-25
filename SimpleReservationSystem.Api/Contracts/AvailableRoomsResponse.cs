using SimpleReservationSystem.Model;

namespace SimpleReservationSystem.Api.Contracts;

public class AvailableRoomsResponse
{
    public IList<Room> Rooms  { get; set; }
}