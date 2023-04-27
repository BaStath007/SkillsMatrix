using GenericDomain;

namespace Domain.Versions;

public class DepartmentNode_1_0 : NodeModel<DepartmentNode_1_0>
{
    // Navigation Properties
    public virtual List<Application>? Applications { get; set; }
    public DepartmentNode_1_0()
    {
        
    }
}
