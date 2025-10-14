namespace PIS.Models
{
    public class ProjectManager
    {
        private List<Project> _list;
        public ProjectManager()
        {
            _list = new List<Project>()
            { 
                new Project()
                {
                    Id=1,
                    Title = "Hyperloop",
                    Budget = 100_000M
                },
                new Project()
                {
                    Id=2,
                    Title = "Starship",
                    Budget = 200_000
                },
                new Project()
                {
                    Id=3,
                    Title = "İnsansız Yaşam",
                    Budget = 50_000_000
                }
            };
        }
    }
}
