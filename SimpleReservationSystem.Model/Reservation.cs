namespace SimpleReservationSystem.Model;

public class Reservation
{
    public int Id { get; set;}
    public DateTime DateFrom { get; set;}
    public DateTime DateTo { get; set;}
    public int NumberOfPeople { get; set;}
    public int ResourceId { get; set; }
}