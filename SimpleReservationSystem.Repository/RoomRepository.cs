using System.Linq.Expressions;
using SimpleReservationSystem.Model;

namespace SimpleReservationSystem.Repository;

public class RoomRepository : IRepository<Room>
{
    private readonly SimpleReservationSystemContext _context;

    public RoomRepository(SimpleReservationSystemContext context)
    {
        _context = context;
    }
    public IEnumerable<Room> GetAll()
    {
        return _context.Rooms.ToList();
    }

    public IEnumerable<Room> GetBy(Expression<Func<Room, bool>> statement)
    {
        return _context.Set<Room>().Where(statement);
    }

    public Room? GetById(int id)
    {
        return _context.Rooms.FirstOrDefault(r => r.Id == id);
    }

    public void Add(Room entity)
    {
        _context.Rooms.Add(entity);
        _context.SaveChanges();
    }

    public void Update(Room entity)
    {
        _context.Rooms.Update(entity);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var room = GetById(id);
        _context.Rooms.Remove(room);
    }
}