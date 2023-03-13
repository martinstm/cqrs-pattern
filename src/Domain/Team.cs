using System;
using System.Collections.Generic;

namespace Domain
{
    public class Team
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public bool Active { get; set; }
        public List<User> Users { get; set; }
    }
}
