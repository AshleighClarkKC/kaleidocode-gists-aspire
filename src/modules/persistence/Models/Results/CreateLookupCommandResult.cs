using Kaleidocode.Gists.Modules.Persistence.Entities.Base;
using Kaleidocode.Gists.Modules.Persistence.Models.Results.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidocode.Gists.Modules.Persistence.Models.Results;

public record CreateLookupCommandResult : BaseCommandResult
{
    public int GeneratedId { get; set; }
}
