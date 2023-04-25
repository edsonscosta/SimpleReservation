using SimpleReservationSystem.Model;
using SimpleReservationSystem.Repository;

namespace SimpleReservationSystem.Service;

public interface IRoomService
{ 
    IEnumerable<Room> GetAll();
    Room GetById(int id);
    void Add(Room room);
    void Update(Room room);
    void Delete(int id); 
}