using Kaleidocode.Gists.Modules.Persistence.Models.Commands;
using Kaleidocode.Gists.Modules.Persistence.Models.Results;
using LiteBus.Commands.Abstractions;

namespace Kaleidocode.Gists.Modules.Persistence.Handlers.Commands;

public class CreateLookupCommandHandler<TUserId> : ICommandHandler<CreateLookupCommand<TUserId>, CreateLookupCommandResult<TUserId>> where TUserId : struct
{
    public Task<CreateLookupCommandResult<TUserId>> HandleAsync(CreateLookupCommand<TUserId> message, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException(message: "There is no Repository associated with this Command Handler.");
    }
}
