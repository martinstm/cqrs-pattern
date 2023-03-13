using System.Threading.Tasks;

namespace Application.Commands
{
    internal interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command);
    }
}
