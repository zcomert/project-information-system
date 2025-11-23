namespace PIS.Repositories.Contracts;

public interface IRepositoryBase<T>
{
    IQueryable<T> GetAll();
    T? GetById(int id);
    void Create(T entity);
    void Update(T entity);
    void Delete(int id);
}
