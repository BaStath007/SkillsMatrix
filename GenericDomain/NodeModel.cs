using System.ComponentModel.DataAnnotations;

namespace GenericDomain
{
    public abstract class NodeModel<T> where T : class
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public Dictionary<int, T>? Nodes { get; set; }

        public NodeModel()
        {

        }

    }
}