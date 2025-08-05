using Kaleidocode.Gists.Modules.Persistence.Entities.Base;
using Kaleidocode.Gists.Modules.Persistence.Models.Results;
using Kaleidocode.Gists.Modules.Persistence.Models.Results.Base;
using LiteBus.Commands.Abstractions;

namespace Kaleidocode.Gists.Modules.Persistence.Models.Commands;

public class CreateLookupCommand<TUserId> : BaseEntity<TUserId>, ICommand<BaseCommandResult<CreateLookupCommandResult>>
    where TUserId : struct
{
    public int? LookupTypeId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}
