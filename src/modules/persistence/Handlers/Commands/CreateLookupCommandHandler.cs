using Kaleidocode.Gists.Modules.Persistence.Contracts.Base;
using Kaleidocode.Gists.Modules.Persistence.Entities.Lookups;
using Kaleidocode.Gists.Modules.Persistence.Models.Commands;
using Kaleidocode.Gists.Modules.Persistence.Models.Results;
using LiteBus.Commands.Abstractions;

namespace Kaleidocode.Gists.Modules.Persistence.Handlers.Commands;

public class CreateLookupCommandHandler<TUserId>(IBaseRepository<BaseItemLookupEntity<TUserId>, TUserId> repository) 
: ICommandHandler<CreateLookupCommand<TUserId>, CreateLookupCommandResult> where TUserId : struct
{
    private readonly IBaseRepository<BaseItemLookupEntity<TUserId>, TUserId> _repository = repository;

    public async Task<CreateLookupCommandResult> HandleAsync(CreateLookupCommand<TUserId> message, CancellationToken cancellationToken = default)
    {
        BaseItemLookupEntity<TUserId> entity = new()
        {
            LookupTypeId = message.LookupTypeId,
            Name = message.Name,
            Description = message.Description
        };

        CreateLookupCommandResult result = new ();
        try
        {
            await _repository.InsertAsync(entity);
            result.GeneratedId = entity.Id;
            result.Success = true;
        }
        catch (Exception e)
        {
            result.Success = false;
            result.ErrorList.Add(e.Message);
        }

        return result;
    }
}
