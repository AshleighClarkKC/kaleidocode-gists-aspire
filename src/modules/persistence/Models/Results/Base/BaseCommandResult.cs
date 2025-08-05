
namespace Kaleidocode.Gists.Modules.Persistence.Models.Results.Base;

public record BaseCommandResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public List<string> ErrorList { get; set; } = [];
}