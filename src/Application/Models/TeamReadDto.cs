using System.Collections.Generic;

namespace Application.Models
{
    public class TeamReadDto
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public bool Active { get; set; }
        public List<UserReadDto> Users { get; set; }
    }
}
