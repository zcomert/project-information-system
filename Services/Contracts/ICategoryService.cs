using PIS.Models;
using System.Collections.Generic;

namespace PIS.Services.Contracts
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAll();
        Category? GetById(int id);
        Category Create(Category category);
        bool Update(Category category);
        bool Delete(int id);
        IEnumerable<Category> Search(string query);
    }
}
