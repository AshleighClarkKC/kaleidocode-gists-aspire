using Kaleidocode.Gists.Modules.Persistence.Constants;
using Kaleidocode.Gists.Modules.Persistence.Models.Commands;
using LiteBus.Commands.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace Kaleidocode.Gists.Modules.Persistence.Validators;

public class CreateLookupCommandValidator<TUserId> : ICommandValidator<CreateLookupCommand<TUserId>> where TUserId : struct
{
    public Task ValidateAsync(CreateLookupCommand<TUserId> command, CancellationToken cancellationToken = default)
    {
        bool entryValidated =
            !string.IsNullOrEmpty(command.Name);

        return entryValidated
            ? Task.CompletedTask
            : throw new ValidationException(MessageConstants.LOOKUP_ENTRY_INCOMPLETE);
    }
}
