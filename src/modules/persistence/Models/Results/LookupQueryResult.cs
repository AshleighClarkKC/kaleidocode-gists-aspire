namespace Kaleidocode.Gists.Modules.Persistence.Models.Results;

public class LookupQueryResult<TUserId> where TUserId : struct
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int? LookupTypeId { get; set; }

    public bool IsActive { get; set; } = true;

    public bool IsDeleted { get; set; } = false;

    public DateTime CreatedDate { get; set; }

    public TUserId CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public TUserId? ModifiedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public TUserId? DeletedBy { get; set; }
}
