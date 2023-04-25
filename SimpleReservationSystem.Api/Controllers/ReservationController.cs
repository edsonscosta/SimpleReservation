using Microsoft.AspNetCore.Mvc;
using SimpleReservationSystem.Api.Contracts;
using SimpleReservationSystem.Model;
using SimpleReservationSystem.Service;

namespace SimpleReservationSystem.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ReservationController : ControllerBase
{  
    private readonly IReservationService _reservationService;
 
    public ReservationController( IReservationService reservationService)
    {  
        _reservationService = reservationService;
    }
    
    [HttpPost(Name = "Perform Reservation")]
    public IActionResult Post(ReservationRequest body)
    {
        var reservation = new Reservation()
        {
            DateFrom = body.DateFrom,
            DateTo = body.DateTo,
            NumberOfPeople = body.ReservedPeople,
            ResourceId = body.RoomId
        };

        if (!_reservationService.CanPerformReservation(reservation))
            return Conflict();
        
        _reservationService.PerformReservation(new Reservation()
        {
            DateFrom = body.DateFrom,
            DateTo = body.DateTo,
            NumberOfPeople = body.ReservedPeople,
            ResourceId = body.RoomId
        });
         
        return Ok();
    }
}