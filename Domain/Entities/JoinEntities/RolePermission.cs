namespace Domain.Entities.JoinEntities;

public class RolePermission
{
    private RolePermission()
    {

    }
    private RolePermission
        (
            Guid roleId, Guid permissionId,
            Role role, Permission permission
        )
    {
        RoleId = roleId;
        PermissionId = permissionId;
        Role = role;
        Permission = permission;
    }

    public Guid RoleId { get; set; } = Guid.Empty;
    public Guid PermissionId { get; set; } = Guid.Empty;

    // Navigation Properties
    public virtual Role Role { get; set; } = default!;
    public virtual Permission Permission { get; set; } = default!;

    public static RolePermission Create
        (
            Guid roleId, Guid permissionId,
            Role role, Permission permission
        )
        => new RolePermission
        (
            roleId, permissionId, role, permission
        );
}
