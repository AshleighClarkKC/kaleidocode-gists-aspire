using Kaleidocode.Gists.Modules.Persistence.Models.Results;
using Kaleidocode.Gists.Modules.Persistence.Models.Results.Base;
using LiteBus.Queries.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidocode.Gists.Modules.Persistence.Models.Queries;

public class GetLookupQuery<TUserId> : IQuery<BaseQueryResult<LookupQueryResult<TUserId>>> where TUserId : struct
{
    public int Id { get; set; }
}

