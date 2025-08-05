using Kaleidocode.Gists.Modules.Persistence.Contracts.Base;
using Kaleidocode.Gists.Modules.Persistence.Entities.Lookups;
using Kaleidocode.Gists.Modules.Persistence.Models.Commands;
using Kaleidocode.Gists.Modules.Persistence.Models.Results;
using Kaleidocode.Gists.Modules.Persistence.Models.Results.Base;
using LiteBus.Commands.Abstractions;
using System.Net;

namespace Kaleidocode.Gists.Modules.Persistence.Handlers.Commands;

public class CreateLookupCommandHandler<TUserId>(IBaseRepository<BaseItemLookupEntity<TUserId>, TUserId> repository) 
: ICommandHandler<CreateLookupCommand<TUserId>, BaseCommandResult<CreateLookupCommandResult>> where TUserId : struct
{
    private readonly IBaseRepository<BaseItemLookupEntity<TUserId>, TUserId> _repository = repository;

    public async Task<BaseCommandResult<CreateLookupCommandResult>> HandleAsync(CreateLookupCommand<TUserId> message, CancellationToken cancellationToken = default)
    {
        BaseItemLookupEntity<TUserId> entity = new()
        {
            LookupTypeId = message.LookupTypeId,
            Name = message.Name,
            Description = message.Description
        };

        BaseCommandResult<CreateLookupCommandResult> result = new ();
        try
        {
            await _repository.InsertAsync(entity);

            result.Data = new CreateLookupCommandResult
            {
                GeneratedId = entity.Id
            };

            result.Success = true;
            result.Status = (int) HttpStatusCode.Created;
        }
        catch (Exception e)
        {
            result.Success = false;
            result.Message = e.Message;
            result.Status = (int) HttpStatusCode.BadRequest;
        }

        return result;
    }
}
