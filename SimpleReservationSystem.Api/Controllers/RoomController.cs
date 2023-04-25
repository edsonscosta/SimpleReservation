using Microsoft.AspNetCore.Mvc;
using SimpleReservationSystem.Api.Contracts;
using SimpleReservationSystem.Model;
using SimpleReservationSystem.Service;

namespace SimpleReservationSystem.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RoomController : ControllerBase
{
    private readonly IRoomService _roomService;
 
    public RoomController(IRoomService roomService)
    { 
        _roomService = roomService;
    }

    [HttpGet(Name = "GetAvailableRooms")]
    public AvailableRoomsResponse Get()
    {
        return new AvailableRoomsResponse() { Rooms = _roomService.GetAll().ToList() };
    }

    [HttpPost(Name = "AddRoom")]
    public IActionResult Post(AvailableRoomRequest body)
    {
        _roomService.Add(new Room()
        {
            Name = body.Name,
            NumberOfPeople = body.NumberOfPeople
        });
        return Ok();
    }
}