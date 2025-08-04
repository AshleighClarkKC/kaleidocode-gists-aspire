using Kaleidocode.Gists.Modules.Persistence.Models.Commands;
using LiteBus.Commands.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidocode.Gists.Modules.Persistence.Validators
{
    public class CreateLookupCommandValidator<TUserId> : ICommandValidator<CreateLookupCommand<TUserId>> where TUserId : struct
    {
        public Task ValidateAsync(CreateLookupCommand<TUserId> command, CancellationToken cancellationToken = default)
        {
            bool entryValidated = true;

            entryValidated = !string.IsNullOrEmpty(command.Name) && !string.IsNullOrEmpty(command.Description);

            if (!entryValidated)
            {
                throw new ValidationException("The lookup is incomplete. Name & Description fields are required.");
            }

            return Task.CompletedTask;
        }
    }
}