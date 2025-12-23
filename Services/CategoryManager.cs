using PIS.Models;
using PIS.Repositories.Contracts;
using PIS.Services.Contracts;

namespace PIS.Services
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryManager(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Category> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public Category GetById(int id)
        {
            return _repository.GetById(id) ?? throw new KeyNotFoundException("Category not found.");
        }

        public Category Create(Category category)
        {
            _repository.Create(category);
            return category;
        }

        public bool Update(Category category)
        {
            var existingCategory = _repository.GetById(category.CategoryId);
            if (existingCategory == null) return false;

            _repository.Update(category);
            return true;
        }

        public bool Delete(int id)
        {
            var existingCategory = _repository.GetById(id);
            if (existingCategory == null) return false;

            _repository.Delete(id);
            return true;
        }

        public IEnumerable<Category> Search(string query)
        {
            return _repository.GetAll()
                .Where(c => c.CategoryName.Contains(query, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}