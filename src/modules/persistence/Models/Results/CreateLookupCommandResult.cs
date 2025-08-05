using Kaleidocode.Gists.Modules.Persistence.Models.Results.Base;

namespace Kaleidocode.Gists.Modules.Persistence.Models.Results;

public record CreateLookupCommandResult
{
    public int GeneratedId { get; set; }
}
