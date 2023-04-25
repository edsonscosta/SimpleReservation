using SimpleReservationSystem.Model;
using SimpleReservationSystem.Repository;

namespace SimpleReservationSystem.Service;

public class RoomService : IRoomService
{ 
    private readonly IRepository<Room> _roomRepository;

    public RoomService(IRepository<Room> roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public IEnumerable<Room> GetAll()
    {
        return _roomRepository.GetAll();
    }

    public Room GetById(int id)
    {
        return _roomRepository.GetById(id);
    }

    public void Add(Room room)
    {
        _roomRepository.Add(room);
    }

    public void Update(Room room)
    {
        _roomRepository.Update(room);
    }

    public void Delete(int id)
    {
        _roomRepository.Delete(id);
    }
}