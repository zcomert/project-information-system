using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace PIS.Models
{
    public class ProjectCreateViewModel
    {
        public Project Project { get; set; } = new();
        public List<SelectListItem> AllPersons { get; set; } = new();
        public List<SelectListItem> AllRoles { get; set; } = new();
        
        // This will hold the IDs of the selected persons from the multi-select list
        public List<int> SelectedPersonIds { get; set; } = new List<int>();
        
        // This will hold the ID of the selected role for all assigned persons
        public int SelectedRoleId { get; set; }
    }
}
