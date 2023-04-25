using System.Linq.Expressions;
using SimpleReservationSystem.Model;
using SimpleReservationSystem.Repository;

namespace SimpleReservationSystem.Service;

public class ReservationService : IReservationService
{ 
    private readonly IRepository<Room> _roomRepository;
    private readonly IRepository<Reservation> _reservationRepository;

    public ReservationService(IRepository<Room> roomRepository, IRepository<Reservation> reservationRepository)
    {
        _roomRepository = roomRepository;
        _reservationRepository = reservationRepository;
    }
    
    private int GetRoomCapacity(int roomId)
    {
        var room = _roomRepository.GetById(roomId);
        return room?.NumberOfPeople ?? 0;
    }

    private bool IsReservationValid(Reservation reservation)
    {
        Expression<Func<Reservation, bool>> reservationStatement = x => x.DateFrom >= reservation.DateFrom 
                                                                        && x.DateTo <= reservation.DateTo
                                                                        && x.ResourceId == reservation.ResourceId;

        var reservations = _reservationRepository.GetBy(reservationStatement).ToList();

        var totalAlreadyReserved = reservations.Select(x => x.NumberOfPeople).Sum();
    
        return totalAlreadyReserved + reservation.NumberOfPeople <= GetRoomCapacity(reservation.ResourceId);
    }

    public bool CanPerformReservation(Reservation reservation)
    {
        return IsReservationValid(reservation);
    }
 
    public void PerformReservation(Reservation reservation)
    {
        _reservationRepository.Add(reservation);
    }
}