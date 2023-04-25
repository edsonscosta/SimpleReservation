using System.Linq.Expressions;
using SimpleReservationSystem.Model;

namespace SimpleReservationSystem.Repository;

public class ReservationRepository : IRepository<Reservation>
{
    private readonly SimpleReservationSystemContext _context;

    public ReservationRepository(SimpleReservationSystemContext context)
    {
        _context = context;
    }
    public IEnumerable<Reservation> GetAll()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Reservation> GetBy(Expression<Func<Reservation, bool>> statement)
    {
        return _context.Set<Reservation>().Where(statement);
    }

    public Reservation? GetById(int id)
    { 
        return _context.Reservations.FirstOrDefault(r => r.Id == id);
    }

    public void Add(Reservation entity)
    {
        _context.Reservations.Add(entity);
        _context.SaveChanges();
    }

    public void Update(Reservation room)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
}