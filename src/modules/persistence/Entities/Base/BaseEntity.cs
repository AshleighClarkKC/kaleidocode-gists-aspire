
namespace Kaleidocode.Gists.Modules.Persistence.Entities.Base;

/// <summary>
/// Base entity class for other types to derive from, to add auditing properties.
/// </summary>
/// <typeparam name="TUserId">Type variation for difference user ID types.</typeparam>
public class BaseEntity<TUserId> where TUserId : struct
{
    public int Id { get; set; }

    public bool IsActive { get; set; } = true;

    public bool IsDeleted { get; set; } = false;

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public TUserId CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public TUserId? ModifiedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public TUserId? DeletedBy { get; set; }
}

