using SimpleReservationSystem.Model;

namespace SimpleReservationSystem.Api.Contracts;

public class AvailableRoomRequest 
{
    public string Name { get; set; }
    public int NumberOfPeople { get; set; }
}