using System.Threading.Tasks;

namespace Application.Commands
{
    public interface ICommandProcessor
    {
        Task ProcessAsync<T>(T command) where T : ICommand;
    }
}