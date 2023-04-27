using System.ComponentModel.DataAnnotations;

namespace GenericDomain;

public abstract class BaseClass
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string? Description { get; set; }

    public BaseClass()
    {
        
    }
}
