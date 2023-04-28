using Domain.Versions;
using GenericDomain;

namespace Domain;

public class Department : NodeModel<Department>,IDepartment_1_0
{
	public Department()
	{

	}

    // Navigation Properties
    public List<Application>? Applications { get; set; }
}
