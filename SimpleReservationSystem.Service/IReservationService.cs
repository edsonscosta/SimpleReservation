using SimpleReservationSystem.Model;
using SimpleReservationSystem.Repository;

namespace SimpleReservationSystem.Service;

public interface IReservationService
{  
    bool CanPerformReservation(Reservation reservation);
    void PerformReservation(Reservation reservation); 
}