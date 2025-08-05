using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidocode.Gists.Modules.Persistence.Models.Results.Base
{
    public class BaseQueryResult<TQueryResult>
    {
        public bool Success { get; set; }

        public int Status { get; set; }

        public string Message { get; set; } = string.Empty;

        public TQueryResult? Data { get; set; }
    }
}
