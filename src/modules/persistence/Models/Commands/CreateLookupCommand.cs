using Kaleidocode.Gists.Modules.Persistence.Entities.Base;
using Kaleidocode.Gists.Modules.Persistence.Models.Results;
using LiteBus.Commands.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidocode.Gists.Modules.Persistence.Models.Commands
{
    public class CreateLookupCommand<TUserId> : BaseEntity<TUserId>, ICommand<CreateLookupCommandResult<TUserId>>
    where TUserId : struct
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}
