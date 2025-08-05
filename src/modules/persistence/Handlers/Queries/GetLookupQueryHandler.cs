using Kaleidocode.Gists.Modules.Persistence.Contracts.Base;
using Kaleidocode.Gists.Modules.Persistence.Entities.Lookups;
using Kaleidocode.Gists.Modules.Persistence.Models.Queries;
using Kaleidocode.Gists.Modules.Persistence.Models.Results;
using Kaleidocode.Gists.Modules.Persistence.Models.Results.Base;
using LiteBus.Queries.Abstractions;
using System.Net;

namespace Kaleidocode.Gists.Modules.Persistence.Handlers.Queries;

public class GetLookupQueryHandler<TUserId>(IBaseRepository<BaseItemLookupEntity<TUserId>, TUserId> repository) 
: IQueryHandler<GetLookupQuery<TUserId>, BaseQueryResult<LookupQueryResult<TUserId>>> where TUserId : struct
{
    private readonly IBaseRepository<BaseItemLookupEntity<TUserId>, TUserId> _repository = repository;

    public async Task<BaseQueryResult<LookupQueryResult<TUserId>>> HandleAsync(GetLookupQuery<TUserId> message, CancellationToken cancellationToken = default)
    {
        BaseQueryResult<LookupQueryResult<TUserId>> result = new ();

        try
        {
            var data = await _repository.GetByIdAsync(message.Id);

            if (data != null) 
            {
                result.Success = true;

                result.Data = new LookupQueryResult<TUserId>
                {
                    Id = data.Id,
                    Name = data.Name,
                    Description = data.Description,
                    LookupTypeId = data.LookupTypeId,
                    IsActive = data.IsActive,
                    IsDeleted = data.IsDeleted,
                    CreatedDate = data.CreatedDate,
                    CreatedBy = data.CreatedBy,
                    ModifiedDate = data.ModifiedDate,
                    ModifiedBy = data.ModifiedBy,
                    DeletedDate = data.DeletedDate,
                    DeletedBy = data.DeletedBy,
                };
                result.Status = (int) HttpStatusCode.OK;
            }
            else
            {
                result.Success = false;
                result.Status = (int) HttpStatusCode.NotFound;
            }
        }
        catch (Exception e) 
        {
            result.Success = false;
            result.Status = (int) HttpStatusCode.BadRequest;
            result.Message = e.Message;
        }

        return result;
    }
}
