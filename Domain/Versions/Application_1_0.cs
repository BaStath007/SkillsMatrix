using GenericDomain;

namespace Domain.Versions;

public class Application_1_0 : BaseClass
{
    // Navigation Properties
    public virtual List<Department>? Departments { get; set; }
}
