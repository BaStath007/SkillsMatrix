namespace Application.DTOs;

public sealed class HardSkillDeleteDTO
{
    public int Id { get; set; }

    public HardSkillDeleteDTO()
    {

    }
    public HardSkillDeleteDTO
        (
            int id
        )
    {
        Id = id;
    }
}
