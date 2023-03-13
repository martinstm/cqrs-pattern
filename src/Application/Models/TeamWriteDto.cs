using System.Collections.Generic;

namespace Application.Models
{
    public class TeamWriteDto
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public bool Active { get; set; }
        public List<string> UsersEmail { get; set; }
    }
}
