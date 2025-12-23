using PIS.Models;

namespace PIS.Repositories.Contracts;

public interface ICategoryRepository
{
    IQueryable<Category> GetAll();
    Category? GetById(int id);
    void Create(Category category);
    void Update(Category category);
    void Delete(int id);
}