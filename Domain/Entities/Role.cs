using Domain.Primitives;

namespace Domain.Entities;

public class Role : Enumeration<Role>
{
    protected Role(int id, string name)
        : base(id, name)
    {
    }

    public static Role Create(string name)
    {
        Role role = Role.FromName(name)!;
        return new(role.Id, role.Name);
    }


    public static readonly Role Admin = new AdminRole();
    public static readonly Role Unregistered = new UnregisteredRole();
    public static readonly Role Registered = new RegisteredRole();

    // Navigation Properties
    public virtual ICollection<Permission> Permissions { get; set; } = default!;
    public virtual ICollection<Employee>? Employees { get; set; } = default!;

    private sealed class AdminRole : Role
    {
        public AdminRole()
            : base(0, "Admin")
        {
        }

        public const string Description = "This user is an admin.";
    }

    private sealed class UnregisteredRole : Role
    {
        public UnregisteredRole()
            : base(1, "Unregistered")
        {
        }

        public const string Description = "This user is unregistered.";
    }

    private sealed class RegisteredRole : Role
    {
        public RegisteredRole()
            : base(2, "Registered")
        {
        }

        public const string Description = "This user is registered.";
    }
}
