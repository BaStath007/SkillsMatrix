using Domain.Primitives;

namespace Domain.Enums;

public abstract class SkillType : Enumeration<SkillType>
{
    protected SkillType(int id, string name)
        : base(id, name)
    {
    }

    public abstract List<string> Characteristics { get; }


    public static readonly SkillType None = new NoneSkillType();
    public static readonly SkillType Hard = new HardSkillType();
    public static readonly SkillType Soft = new SoftSkillType();


    private sealed class NoneSkillType : SkillType
    {
        public NoneSkillType()
            : base(0, "None")
        {
        }

        public override List<string> Characteristics => new();
    }

    private sealed class HardSkillType : SkillType
    {
        public HardSkillType()
            : base(1, "Hard")
        {
        }

        public override List<string> Characteristics => 
            new()
            {
               "Hard skills are technical skills required for a job.",
               "Hard skills are acquired through education and experience.",
               "Hard skills can be easily quantified."
            };
    }

    private sealed class SoftSkillType : SkillType
    {
        public SoftSkillType()
            : base(2, "Soft")
        {
        }

        public override List<string> Characteristics =>
            new()
            {
                "Soft skills have more to do with who people are than what they know, " +
                "they are non-technical skills.",
                "Soft skills include attributes and personality traits that help employees " +
                "interact with others and succeed in the workplace.",
                "Soft skills can be developed at work, school, volunteer activities, " +
                "and by participating in training programs and classes.",
                "In contrast to hard skills, soft skills are more difficult to acquire through training."
            };
    }
}

