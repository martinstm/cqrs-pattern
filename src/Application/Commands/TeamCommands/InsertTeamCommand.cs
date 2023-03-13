using System.Collections.Generic;

namespace Application.Commands.TeamCommands
{
    public class InsertTeamCommand : ICommand
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public bool Active { get; set; }
        public List<string> UsersEmail { get; set; }
    }
}
