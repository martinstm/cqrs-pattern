using System;
using System.Threading.Tasks;

namespace Application.Commands
{
    internal class CommandProcessor : ICommandProcessor
    {
        private readonly IServiceProvider _services;

        public CommandProcessor(IServiceProvider services)
        {
            _services = services;
        }

        public async Task ProcessAsync<T>(T command) where T : ICommand
        {
            var handler = _services.GetService(typeof(ICommandHandler<T>));
            if (handler != null)
                await ((ICommandHandler<T>)handler).HandleAsync(command);
            else
                throw new NotSupportedException($"Handler not found for {command.GetType().Name} command.");
        }
    }
}
