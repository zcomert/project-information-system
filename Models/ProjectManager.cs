namespace PIS.Models
{
    public class ProjectManager
    {
        private static List<Project> _list;
        public ProjectManager()
        {
            if (_list == null)
            {
                _list = new List<Project>()
                {
                    new Project()
                    {
                        Id = 1,
                        Title = "Hyperloop",
                        Budget = 100_000M
                    },
                    new Project()
                    {
                        Id = 2,
                        Title = "Starship",
                        Budget = 200_000
                    },
                    new Project()
                    {
                        Id = 3,
                        Title = "Insansiz Yasam",
                        Budget = 50_000_000
                    }
                };
            }
        }

        // READ: Tüm projeleri getir
        public List<Project> GetAll() => _list;

        // CREATE: Yeni proje ekle (Id dolu ve benzersiz değilse otomatik ata)
        public Project Create(Project project)
        {
            if (project is null)
                throw new ArgumentNullException(nameof(project));

            // Id yoksa veya çakışıyorsa bir sonrakini ata
            var idConflicts = project.Id <= 0 || _list.Any(p => p.Id == project.Id);
            if (idConflicts)
            {
                var next = _list.Count == 0 ? 1 : _list.Max(p => (int)p.Id) + 1;
                if (next > short.MaxValue)
                    throw new InvalidOperationException("Maksimum proje sayısına ulaşıldı.");
                project.Id = (short)next;
            }

            _list.Add(project);
            return project;
        }

        // READ: Id ile tek proje getir
        public Project? GetById(int id) => _list.FirstOrDefault(p => p.Id == id);

        // UPDATE: Var olan projeyi güncelle
        public bool Update(Project project)
        {
            if (project is null)
                throw new ArgumentNullException(nameof(project));

            var existing = _list
                .FirstOrDefault(p => p.Id == project.Id);

            if (existing is null)
                return false;

            existing.Title = project.Title;
            existing.Budget = project.Budget;
            return true;
        }

        // DELETE: Id ile sil
        public bool Delete(int id)
        {
            var existing = _list
                .FirstOrDefault(p => p.Id == id);

            if (existing is null)
                return false;

            _list.Remove(existing);

            return true;
        }
    }
}
