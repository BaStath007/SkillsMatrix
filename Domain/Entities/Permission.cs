using Domain.Primitives;

namespace Domain.Entities;

public class Permission : Enumeration<Permission>
{
    protected Permission(int id, string name)
        : base(id, name)
    {
    }

    public static Permission Create(string name)
    {
        Permission permission = Permission.FromName(name)!;
        return new(permission.Id, permission.Name);
    }


    public static readonly Permission Read = new ReadPermission();
    public static readonly Permission Write = new WritePermission();
    public static readonly Permission Delete = new DeletePermission();
    public static readonly Permission FullControl = new FullControlPermission();
    public static readonly Permission AccessEmployees = new AccessEmployeesPermission();
    public static readonly Permission AccessSkills = new AccessSkillsPermission();

    // Navigation Properties
    public virtual ICollection<Role>? Roles { get; set; } = default!;

    private sealed class ReadPermission : Permission
    {
        public ReadPermission()
            : base(0, "Read")
        {
        }

        public const string Description = "This is the permission to read";
    }

    private sealed class WritePermission : Permission
    {
        public WritePermission()
            : base(1, "Write")
        {
        }

        public const string Description = "This is the permission to write";
    }
    private sealed class DeletePermission : Permission
    {
        public DeletePermission()
            : base(2, "Delete")
        {
        }

        public const string Description = "This is the permission to delete";
    }

    private sealed class FullControlPermission : Permission
    {
        public FullControlPermission()
            : base(3, "FullControl")
        {
        }

        public const string Description = "This is the permission to do everything";
    }

    private sealed class AccessEmployeesPermission : Permission
    {
        public AccessEmployeesPermission()
            : base(4, "AccessEmployees")
        {
        }

        public const string Description = "This is the permission to do access the employee entity";
    }

    private sealed class AccessSkillsPermission : Permission
    {
        public AccessSkillsPermission()
            : base(5, "AccessSkills")
        {
        }

        public const string Description = "This is the permission to do access the skill entity";
    }
}
