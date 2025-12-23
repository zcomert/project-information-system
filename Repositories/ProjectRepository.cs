using PIS.Models;
using PIS.Repositories.Contracts;

namespace PIS.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly RepositoryContext _context;

    public ProjectRepository(RepositoryContext context)
    {
        _context = context;
    }

    public IQueryable<Project> GetAll()
    {
        return _context.Projects;
    }

    public Project? GetById(int id)
    {
        return _context.Projects.Find(id);
    }

    public void Create(Project project)
    {
        _context.Projects.Add(project);
        _context.SaveChanges();
    }

// ProjectRepository.cs içindeki Update metodu

public void Update(Project project)
{
    // 1. Veritabanındaki mevcut kaydı bul
    var existingProject = _context.Projects.Find(project.Id);

    if (existingProject != null)
    {
        // 2. Özellikleri TEK TEK güncelle
        // SetValues yerine bu yöntemi kullanıyoruz çünkü kontrol bizde olsun istiyoruz.
        
        existingProject.Title = project.Title;
        existingProject.Budget = project.Budget;
        
        // Diğer güncellenmesi gereken alanlarınız varsa buraya ekleyin (örn: existingProject.Description = project.Description;)

        // 3. KRİTİK KONTROL:
        // Eğer formdan gelen CategoryId geçerli bir sayı ise (0'dan büyükse) güncelle.
        // Eğer 0 gelmişse (hata veya boş seçim), eski kategoriye DOKUNMA.
        if (project.CategoryId > 0)
        {
            existingProject.CategoryId = project.CategoryId;
        }

        // 4. Kaydet
        _context.SaveChanges();
    }
}

    public void Delete(int id)
    {
        var project = GetById(id);
        if (project is not null)
        {
            _context.Projects.Remove(project);
            _context.SaveChanges();
        }
    }
}

