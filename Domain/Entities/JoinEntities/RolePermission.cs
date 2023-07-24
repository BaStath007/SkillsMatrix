namespace Domain.Entities.JoinEntities;

public class RolePermission
{
    private RolePermission()
    {
    }
    private RolePermission(Role role, Permission permission)
    {
        RoleId = role.Id;
        PermissionId = permission.Id;
        Role = role;
        Permission = permission;
    }

    public int RoleId { get; set; }
    public int PermissionId { get; set; }

    // Navigation Properties
    public virtual Role Role { get; set; } = default!;
    public virtual Permission Permission { get; set; } = default!;

    public static RolePermission Create(Role role, Permission permission) => new(role, permission);
}
