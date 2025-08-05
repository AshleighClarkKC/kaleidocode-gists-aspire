
namespace Kaleidocode.Gists.Modules.Persistence.Models.Results.Base;

public record BaseCommandResult<TCommandResult>
{
    public bool Success { get; set; }

    public int Status { get; set; }

    public string Message { get; set; } = string.Empty;

    public TCommandResult? Data { get; set; }
}