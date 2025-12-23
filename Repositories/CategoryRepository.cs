using Microsoft.EntityFrameworkCore;
using PIS.Models;
using PIS.Repositories.Contracts;

namespace PIS.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly RepositoryContext _context;

    public CategoryRepository(RepositoryContext context)
    {
        _context = context;
    }

    public IQueryable<Category> GetAll()
    {
        return _context.Categories.Include(c => c.Projects);
    }

    public Category? GetById(int id)
    {
        return _context.Categories
            .Include(c => c.Projects)
            .FirstOrDefault(c => c.CategoryId == id);
    }

    public void Create(Category category)
    {
        _context.Categories.Add(category);
        _context.SaveChanges();
    }

    public void Update(Category category)
    {
        var existingCategory = _context.Categories.Find(category.CategoryId);
        if (existingCategory != null)
        {
            _context.Entry(existingCategory).CurrentValues.SetValues(category);
            _context.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        var category = _context.Categories.Find(id);
        if (category != null)
        {
            // First delete all related projects
            var relatedProjects = _context.Projects.Where(p => p.CategoryId == id).ToList();
            foreach (var project in relatedProjects)
            {
                _context.Projects.Remove(project);
            }
            
            // Then delete the category
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
    }
}
