namespace Domain.Entities.JoinEntities;

public class EmployeeRole
{
    private EmployeeRole()
    {

    }
    private EmployeeRole
        (
            Guid roleId, Guid employeeId,
            Role role, Employee employee
        )
    {
        RoleId = roleId;
        EmployeeId = employeeId;
        Role = role;
        Employee = employee;
    }

    public Guid RoleId { get; set; } = Guid.Empty;
    public Guid EmployeeId { get; set; } = Guid.Empty;

    // Navigation Properties
    public virtual Role Role { get; set; } = default!;
    public virtual Employee Employee { get; set; } = default!;

    public static EmployeeRole Create
        (
            Guid roleId, Guid employeeId,
            Role role, Employee employee
        )
        => new EmployeeRole
        (
            roleId, employeeId, role, employee
        );
}
