using System.Linq.Expressions;

namespace SimpleReservationSystem.Repository;

using SimpleReservationSystem.Model;
public interface IRepository<T>
{
    IEnumerable<T> GetAll();
    IEnumerable<T> GetBy(Expression<Func<T, bool>> statement);
    T? GetById(int id);
    void Add(T entity);
    void Update(T entity);
    void Delete(int id);
}