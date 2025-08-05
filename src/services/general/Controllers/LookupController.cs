using Kaleidocode.Gists.Modules.Persistence.Models.Commands;
using Kaleidocode.Gists.Modules.Persistence.Models.Queries;
using Kaleidocode.Gists.Modules.Persistence.Models.Results;
using Kaleidocode.Gists.Modules.Persistence.Models.Results.Base;
using LiteBus.Commands.Abstractions;
using LiteBus.Queries.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Kaleidocode.Gists.Services.General.Controllers;

[ApiController, Route("api/[controller]")]
public class LookupController(ICommandMediator commandMediator, IQueryMediator queryMediator, ILogger<LookupController> logger) : ControllerBase
{
    private readonly IQueryMediator _queryMediator = queryMediator;

    private readonly ICommandMediator _commandMediator = commandMediator;

    private readonly ILogger<LookupController> _logger = logger;

    [HttpGet, Route("Get/{id}")]
    public async Task<ActionResult> GetItemByIdAsync(int id)
    {
        GetLookupQuery<Guid> lookupQuery = new ()
        {
            Id = id
        };

        BaseQueryResult<LookupQueryResult<Guid>> result = new ();

        try
        {
            result = await _queryMediator.QueryAsync(lookupQuery);
        }
        catch (Exception e) 
        {
            _logger.Log(LogLevel.Error, e.Message);
        }

        var statusRes = result.Success
            ? StatusCode(result.Status, result.Data)
            : StatusCode(result.Status, result.Message);

        return statusRes;
    }

    [HttpPost, Route("Create")]
    public async Task<ActionResult> Create([FromBody] CreateLookupCommand<Guid> lookup)
    {
        CreateLookupCommand<Guid> lookupQuery = new()
        {
            LookupTypeId = lookup.LookupTypeId,
            Name = lookup.Name,
            Description = lookup.Description,
            CreatedBy = lookup.CreatedBy
        };

        BaseCommandResult<CreateLookupCommandResult> result = new ();

        try
        {
            result = await _commandMediator.SendAsync(lookupQuery);
        }
        catch (Exception e) 
        {
            _logger.Log(LogLevel.Error, e.Message);
        }

        var statusRes = result.Success
            ? StatusCode(result.Status, result.Data)
            : StatusCode(result.Status, result.Message);

        return statusRes;
    }
}
